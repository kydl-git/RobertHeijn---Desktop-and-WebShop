#region

using System.Data;
using System.Globalization;
using System.Text;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Enums;
using BusinessLogic.BL_Managers;
using static System.Convert;
using DBNull = System.DBNull;

#endregion

namespace DataAccessLayer.RepositoryClasses;

public class ShoppingCartRepository : IShoppingCartActionable
{
    private readonly DbQueries _dbQueries;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ShoppingCartRepository" />
    ///     class.
    /// </summary>
    /// <param name="dbQueries"></param>
    public ShoppingCartRepository(DbQueries dbQueries)
    {
        _dbQueries = dbQueries;
    }

    private string SqlString { get; set; } = null!;
    private Dictionary<string, string?> Parameters { get; } = new();
    private DataSet DataSet { get; set; } = new();

    public ShoppingCart GetCart(ShoppingCart cart)
    {
        SqlString = "SELECT c.id, c.person_id, i.product_id, i.amount, p.name, pe.email, pe.password, pe.firstname, pe.lastname, " +
                    "pe.phone, pe.role_id, a.id address_id, a.street, a.street_number, a.zipCode,a.city, " +
                    "h.address_id home_id, ra.street home_street, ra.street_number home_number, ra.zipCode home_code, " +
                    "ra.city home_city, p.subcategory_id, ca.name SubCategory,rc.id CategId, rc.name Category, p.price, " +
                    "p.quantity, p.unit_id, u.name Unit " +
                    "FROM rh_shoppingcart c " +
                    "LEFT JOIN rh_cart_items i ON i.cart_id = c.id " +
                    "LEFT JOIN rh_product p ON p.id = i.product_id " +
                    "LEFT JOIN rh_person pe ON pe.id = c.person_id " +
                    "LEFT JOIN rh_category ca ON ca.id = p.subcategory_id " +
                    "LEFT JOIN rh_unit u ON u.id = p.unit_id " +
                    "LEFT JOIN rh_category rc ON rc.id = ca.parent_id " +
                    "LEFT JOIN rh_role r on r.id = pe.role_id " +
                    "LEFT JOIN rh_address a ON a.id = r.shop_address_id " +
                    "LEFT JOIN rh_home_addresses h ON h.customer_id = r.id " +
                    "LEFT JOIN rh_address ra ON ra.id = h.address_id " +
                    "WHERE c.id = @id";
        Parameters.Add("@id", cart.CartId.ToString());
        DataSet = _dbQueries.Select(SqlString, Parameters);
        var row = DataSet.Tables[0].Rows[0];
        cart = new ShoppingCart(cart.CartId, IsDBNull(row["person_id"])
            ? null
            : new Person(new Credentials((string)row["email"], (string)row["password"]),
                (string)row["firstname"], (string)row["lastname"], (string)row["phone"], (int)row["person_id"],
                new Customer((int)row["role_id"], IsDBNull(row["address_id"]) ? null : new Address((int)row["address_id"], (string)row["street"], (string)row["street_number"], (string)row["zipCode"], (string)row["city"]))));
        if (!IsDBNull(row["person_id"]))
            for (var i = 0; i < DataSet.Tables[0].Rows.Count; i++)
            {
                row = DataSet.Tables[0].Rows[i];
                if (!IsDBNull(row["home_id"]) && cart.Customer!.Role is Customer customer) customer.AddAddress(new Address((int)row["home_id"], (string)row["home_street"], (string)row["home_number"], (string)row["home_code"], (string)row["home_city"]));
            }

        if (IsDBNull(row["product_id"])) return cart;
        for (var i = 0; i < DataSet.Tables[0].Rows.Count; i++)
        {
            row = DataSet.Tables[0].Rows[i];
            cart.AdjustItemAmount(new Item(
                new Product((int)row["product_id"], (string)row["name"], (decimal)row["price"],
                    new Category((int)row["subcategory_id"], (string)row["SubCategory"],
                        new Category((int)row["CategId"], (string)row["Category"])),
                    new Quantity((int)row["quantity"], (QuantityUnit)(int)row["unit_id"])), (int)row["amount"]));
        }

        return cart;
    }

    public bool TransferAnonymousCartToUser(int cartId, string? userEmail)
    {
        Clear();
        SqlString = "SELECT @person_id := id FROM rh_person WHERE email = @userEmail;" +
                    "UPDATE rh_shoppingcart SET person_id = @person_id WHERE id = @cart_id";
        Parameters.Add("@userEmail", userEmail);
        Parameters.Add("@cart_id", cartId.ToString(CultureInfo.InvariantCulture));
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public int CreateCart(ShoppingCart cart)
    {
        Clear();
        var cartId = 0;
        SqlString = "SELECT @cart_id := id FROM rh_shoppingcart WHERE id = @shop_cart_id;" +
                    "REPLACE INTO rh_shoppingcart (id, person_id) VALUES (@cart_id, @person_id);" +
                    "SELECT LAST_INSERT_ID() cart_id;";
        Parameters.Add("@shop_cart_id", cart.CartId.ToString(CultureInfo.InvariantCulture));
        Parameters.Add("@person_id", cart.Customer == null ? DBNull.Value.ToString(CultureInfo.CurrentCulture) : cart.Customer.Id.ToString());
        DataSet = _dbQueries.Select(SqlString, Parameters);
        cartId = (int)DataSet.Tables[0].Rows[0]["cart_id"];
        return cartId;
    }
	public bool UpdateCartItemsAmount(ShoppingCart cart, Dictionary<int, int> items)
	{
		Clear();
		var batch = 0;
		var stringBuilder = new StringBuilder();
		for (var i = 0; i < items.Count; i++)
		{
			var cartId = $"@cartId{i}";
			var productId = $"@product{i}";
			var amount = $"@amount{i}";
			SqlString = "UPDATE rh_cart_items SET amount = @amount WHERE cart_id = @cartId AND product_id = @productId;";
			if (batch > 0) stringBuilder.AppendLine();
			stringBuilder.Append(SqlString);
			batch++;
			Parameters.Add(cartId, cart.CartId.ToString(CultureInfo.InvariantCulture));
			Parameters.Add(productId, items.ElementAt(i).Key.ToString(CultureInfo.InvariantCulture));
			Parameters.Add(amount, items.ElementAt(i).Value.ToString(CultureInfo.InvariantCulture));
		}

		return _dbQueries.InsertUpdateDelete(stringBuilder.ToString(), Parameters);
	}
    public bool AdjustItemAmount(ShoppingCart cart, Item item, bool increase = true)
    {
        Clear();
        SqlString = "SELECT @id := id FROM rh_cart_items WHERE cart_id = @cart_id AND product_id = @product_id;" +
                    "REPLACE INTO rh_cart_items (id, cart_id, product_id, amount) " +
                    "VALUES (@id, @cart_id, @product_id, @amount)";
        Parameters.Add("@cart_id", cart.CartId.ToString());
        Parameters.Add("@product_id", item.Product!.Id.ToString());
        Parameters.Add("@amount", item.Amount.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool RemoveItemFromCart(ShoppingCart cart, Item item)
    {
        Clear();
        SqlString = "DELETE FROM rh_cart_items WHERE cart_id = @cart_id AND product_id = @product_id";
        Parameters.Add("@cart_id", cart.CartId.ToString());
        Parameters.Add("@product_id", item.Product!.Id.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool DeleteCart(ShoppingCart cart)
    {
        Clear();
        SqlString = "DELETE FROM rh_cart_items WHERE cart_id = @cart_id; DELETE FROM rh_shoppingcart WHERE id = @cart_id";
        Parameters.Add("@cart_id", cart.CartId.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool RemoveEmptyItemsFromCart(ShoppingCart cart)
    {
        Clear();
        SqlString = "DELETE FROM rh_cart_items WHERE cart_id = @cart_id AND amount = 0";
        Parameters.Add("@cart_id", cart.CartId.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    private void Clear()
    {
        Parameters.Clear();
        DataSet.Clear();
        SqlString = string.Empty;
    }
}