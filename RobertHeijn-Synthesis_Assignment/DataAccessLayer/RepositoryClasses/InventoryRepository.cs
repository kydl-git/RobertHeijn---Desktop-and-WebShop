#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Enums;
using System.Data;
using System.Globalization;

#endregion

namespace DataAccessLayer.RepositoryClasses;

public class InventoryRepository : IInventoryActionable
{
	private readonly DbQueries _dbQueries;

	/// <summary>
	///     Initializes a new instance of the <see cref="InventoryRepository" />
	///     object.
	/// </summary>
	/// <param name="dbQueries"></param>
	public InventoryRepository(DbQueries dbQueries)
	{
		_dbQueries = dbQueries;
	}

	private string SqlString { get; set; } = null!;
	private Dictionary<string, string?> Parameters { get; } = new();
	private DataSet DataSet { get; set; } = new();

	public bool AddItemToInventory(InventoryProduct item)
	{
		Clear();
		SqlString = @"INSERT INTO rh_inventory_product (product_id, amount) VALUES (@product_id, @amount)";
		Parameters.Add("@product_id", item.Product!.Id.ToString());
		Parameters.Add("@amount", item.AvailableAmount.ToString());
		return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
	}

	public bool RemoveItemFromInventory(InventoryProduct item)
	{
		Clear();
		SqlString = @"DELETE FROM rh_inventory_product WHERE product_id = @product_id";
		Parameters.Add("@product_id", item.Product!.Id.ToString());
		return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
	}

	public bool UpdateItemQuantityInInventory(InventoryProduct item)
	{
		Clear();
		SqlString = @"UPDATE rh_inventory_product SET amount = @amount WHERE product_id = @product_id";
		Parameters.Add("@product_id", item.Product!.Id.ToString());
		Parameters.Add("@amount", item.AvailableAmount.ToString());
		return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
	}

	public InventoryProduct GetItemFromInventory(InventoryProduct item)
	{
		Clear();
		SqlString = "SELECT i.id, i.product_id, p.name, p.subcategory_id, c.name SubCategory,rc.id CategId, " +
					"rc.name Category, p.price, p.quantity, p.unit_id, u.name Unit, i.amount " +
					"FROM rh_inventory_product i " +
					"INNER JOIN rh_product p ON i.product_id = p.id " +
					"INNER JOIN rh_category c ON c.id = p.subcategory_id " +
					"INNER JOIN rh_unit u ON u.id = p.unit_id " +
					"INNER JOIN rh_category rc ON rc.id = c.parent_id " +
					"WHERE i.product_id = @product_id";
		DataSet = _dbQueries.Select(SqlString, Parameters);
		var row = DataSet.Tables[0].Rows[0];
		var returnItem = new InventoryProduct(new Product(
			(int)row["product_id"],
			(string)row["name"],
			(decimal)row["price"],
			new Category((int)row["subcategory_id"], (string)row["SubCategory"],
				new Category((int)row["CategId"], (string)row["Category"])),
			new Quantity((int)row["quantity"], (QuantityUnit)(int)row["unit_id"])), (int)row["amount"], (int)row["id"]);
		return returnItem;
	}

	public List<InventoryProduct> GetInventory()
	{
		Clear();
		List<InventoryProduct> inventoryProducts = new();
		SqlString = "SELECT i.id, i.product_id, p.name, p.subcategory_id, c.name SubCategory,rc.id CategId, " +
					"rc.name Category, p.price, p.quantity, p.unit_id, u.name Unit, i.amount " +
					"FROM rh_inventory_product i " +
					"INNER JOIN rh_product p ON i.product_id = p.id " +
					"INNER JOIN rh_category c ON c.id = p.subcategory_id " +
					"INNER JOIN rh_unit u ON u.id = p.unit_id " +
					"INNER JOIN rh_category rc ON rc.id = c.parent_id";
		DataSet = _dbQueries.Select(SqlString, Parameters);
		for (var i = 0; i < DataSet.Tables[0].Rows.Count; i++)
		{
			var row = DataSet.Tables[0].Rows[i];
			inventoryProducts.Add(new InventoryProduct(new Product(
				(int)row["product_id"],
				(string)row["name"],
				(decimal)row["price"],
				new Category((int)row["subcategory_id"], (string)row["SubCategory"],
					new Category((int)row["CategId"], (string)row["Category"])),
				new Quantity((int)row["quantity"], (QuantityUnit)(int)row["unit_id"])), (int)row["amount"], (int)row["id"]));
		}

		return inventoryProducts;
	}
	public List<InventoryProduct> FilterInventory(string? categoryName = null, string? subcategoryName = null, decimal minPrice = 0, decimal maxPrice = 0, bool getMostExpensive = true)
	{
		Clear();
		List<InventoryProduct> inventoryProducts = new();
		SqlString = "filter_products";
		Parameters.Add("@p_category", string.IsNullOrEmpty(categoryName) ? DBNull.Value.ToString(CultureInfo.CurrentCulture) : categoryName);
		Parameters.Add("@p_subcategory", string.IsNullOrEmpty(subcategoryName) ? DBNull.Value.ToString(CultureInfo.CurrentCulture) : subcategoryName);
		Parameters.Add("p_min_price", minPrice.ToString(CultureInfo.InvariantCulture));
		Parameters.Add("p_max_price", maxPrice.ToString(CultureInfo.InvariantCulture));
		Parameters.Add("p_get_highest_price", getMostExpensive ? "1" : "0");
		DataSet = _dbQueries.FilterWithStoredProcedure(SqlString, Parameters);
		for (var i = 0; i < DataSet.Tables[0].Rows.Count; i++)
		{
			var row = DataSet.Tables[0].Rows[i];
			inventoryProducts.Add(new InventoryProduct(new Product(
				(int)row["product_id"],
				(string)row["name"],
				(decimal)row["price"],
				new Category((int)row["subcategory_id"], (string)row["SubCategory"],
					new Category((int)row["CategId"], (string)row["Category"])),
				new Quantity((int)row["quantity"], (QuantityUnit)(int)row["unit_id"])), (int)row["amount"], (int)row["inventoryId"]));
		}

		return inventoryProducts;
	}

	public bool IsItemInStock(Product product)
	{
		Clear();
		SqlString = "SELECT i.id, i.product_id, i.amount " +
					"FROM rh_inventory_product i " +
					"WHERE i.product_id = @product_id";
		DataSet = _dbQueries.Select(SqlString, Parameters);
		var row = DataSet.Tables[0].Rows[0];
		return (int)row["amount"] > 0;
	}

	private void Clear()
	{
		Parameters.Clear();
		DataSet.Clear();
		SqlString = string.Empty;
	}
}