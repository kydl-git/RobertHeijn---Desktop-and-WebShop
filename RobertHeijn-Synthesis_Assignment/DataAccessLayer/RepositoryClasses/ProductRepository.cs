#region

using System.Data;
using System.Globalization;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Enums;

#endregion

namespace DataAccessLayer.RepositoryClasses;

public class ProductRepository : IProductActionable
{
    private readonly DbQueries _dbQueries;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ProductRepository" /> class.
    /// </summary>
    /// <param name="dbQueries"></param>
    public ProductRepository(DbQueries dbQueries)
    {
        _dbQueries = dbQueries;
    }

    private string SqlString { get; set; } = null!;
    private Dictionary<string, string?> Parameters { get; } = new();
    private DataSet DataSet { get; set; } = new();

    public int CreateProduct(Product product)
    {
        Clear();
        var productId = 0;
        SqlString = @"INSERT INTO rh_product (name, subcategory_id, price,  quantity, unit_id) VALUES (@name, @subcategory_id, @price, @quantity, @unit_id)";
        Parameters.Add("@name", product.Name);
        Parameters.Add("@subcategory_id", product.SubCategory!.Id.ToString());
        Parameters.Add("@price", product.Price.ToString(CultureInfo.InvariantCulture));
        Parameters.Add("@quantity", product.Quantity!.Value.ToString());
        Parameters.Add("@unit_id", ((int)product.Quantity.Unit).ToString());
        if (_dbQueries.InsertUpdateDelete(SqlString, Parameters))
        {
            SqlString = "SELECT MAX(id) product_id FROM rh_product";
            DataSet = _dbQueries.Select(SqlString, Parameters);
            productId = (int)DataSet.Tables[0].Rows[0]["product_id"];
        }

        return productId;
    }

    public bool UpdateProductPrice(Product product, decimal newPrice)
    {
        Clear();
        SqlString = @"UPDATE rh_product SET price = @price WHERE id = @id";
        Parameters.Add("@price", newPrice.ToString(CultureInfo.InvariantCulture));
        Parameters.Add("@id", product.Id.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool UpdateProductQuantity(Product product, int newQuantityValue)
    {
        Clear();
        SqlString = @"UPDATE rh_product SET quantity = @quantity WHERE id = @id";
        Parameters.Add("@quantity", newQuantityValue.ToString());
        Parameters.Add("@id", product.Id.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public List<Product> GetAllProducts()
    {
        Clear();
        List<Product> products = new();
        SqlString = "SELECT p.id, p.name, p.subcategory_id, c.name SubCategory,rc.id CategId, rc.name Category, p.price, p.quantity, p.unit_id, u.name Unit " +
                    "FROM rh_product p " +
                    "INNER JOIN rh_category c ON c.id = p.subcategory_id " +
                    "INNER JOIN rh_unit u ON u.id = p.unit_id " +
                    "INNER JOIN rh_category rc ON rc.id = c.parent_id";
        DataSet = _dbQueries.Select(SqlString, Parameters);
        for (var i = 0; i < DataSet.Tables[0].Rows.Count; i++)
        {
            var row = DataSet.Tables[0].Rows[i];
            products.Add(new Product(
                (int)row["id"],
                (string)row["name"],
                (decimal)row["price"],
                new Category((int)row["subcategory_id"], (string)row["SubCategory"],
                    new Category((int)row["CategId"], (string)row["Category"])),
                new Quantity((int)row["quantity"], (QuantityUnit)(int)row["unit_id"])));
        }

        return products;
    }

    private void Clear()
    {
        Parameters.Clear();
        DataSet.Clear();
        SqlString = string.Empty;
    }
}