#region

using System.Data;
using System.Globalization;
using System.Text;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Enums;
using static System.Convert;

#endregion

namespace DataAccessLayer.RepositoryClasses;

public class OrderRepository : IOrderActionable
{
    private readonly DbQueries _dbQueries;

    /// <summary>
    ///     Initializes a new instance of the <see cref="OrderRepository" />
    ///     class.
    /// </summary>
    public OrderRepository(DbQueries dbQueries)
    {
        _dbQueries = dbQueries;
    }

    private string SqlString { get; set; } = null!;
    private Dictionary<string, string?> Parameters { get; } = new();
    private DataSet DataSet { get; set; } = new();

    public bool CreateOrder(Order order)
    {
        Clear();
        var result = false;
        SqlString = @"INSERT INTO rh_order (createdDate, person_id, deliveryDay, address_id, slotDuration, status_id) VALUES (@createdDate, @person_id, @deliveryDay, @address_id, @slotDuration, @status_id)";
        Parameters.Add("@createdDate", order.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"));
        Parameters.Add("@person_id", order.Customer!.Id.ToString());
        Parameters.Add("@deliveryDay", order.TimeSlot.ToDateTime(order.DeliveryOption.GetDeliveryDay()).ToString("yyyy-MM-dd HH:mm:ss"));
        Parameters.Add("@address_id", order.DeliveryAddress.Id.ToString());
        Parameters.Add("@slotDuration", order.TimeSlot.GetSlotDuration().ToString());
        Parameters.Add("@status_id", ((int)order.Status).ToString());
        if (!_dbQueries.InsertUpdateDelete(SqlString, Parameters)) return result;
        Clear();
        var selectedOrderId = (int)_dbQueries.Select("SELECT MAX(id) order_id FROM rh_order", Parameters).Tables[0].Rows[0]["order_id"];
        var stringBuilder = new StringBuilder();
        // with batchSize we split the query into multiple queries(to not exceed the max_allowed_packet size)
        var batchSize = 0;
        for (var i = 0; i < order.Items.Count; i++)
        {
            var item = order.Items[i];
            // order id is the same for all items, I just add a number to the parameter name so that Add to dictionary does not throw an exception
            var orderId = $"@orderId{i}";
            var productId = $"@product{i}";
            var amount = $"@amount{i}";
            var paidPrice = $"@price{i}";
            var row = $"({orderId}, {productId}, {amount}, {paidPrice})";
            if (batchSize > 0)
                stringBuilder.AppendLine(",");
            stringBuilder.Append(row);
            batchSize += 1;
            Parameters.Add(orderId, selectedOrderId.ToString());
            Parameters.Add(productId, item.Product!.Id.ToString());
            Parameters.Add(amount, item.Amount.ToString());
            Parameters.Add(paidPrice, item.Product.Price.ToString(CultureInfo.CurrentCulture));
            if (batchSize < 5) continue;
            var sql = "INSERT INTO rh_order_products (order_id, product_id, amount, paid_price) VALUES\r\n" +
                      stringBuilder + ";";
            result = _dbQueries.InsertUpdateDelete(sql, Parameters);
            Parameters.Clear();
            stringBuilder.Clear();
            batchSize = 0;
        }

        // if there are still items left in the order(or there were less then 5 items), we execute this query
        if (batchSize > 0)
        {
            var sql = "INSERT INTO rh_order_products (order_id, product_id, amount, paid_price) VALUES" + "\r\n" +
                      stringBuilder + ";";
            result = _dbQueries.InsertUpdateDelete(sql, Parameters);
        }

        return result;
    }
    
    public bool UpdateOrderDeliveryDay(Order order, DateTime deliveryDay)
    {
        Clear();
        SqlString = @"UPDATE rh_order deliveryDay = @deliveryDay WHERE id = @id";
        Parameters.Add("@deliveryDay", deliveryDay.ToString("yyyy-MM-dd HH:mm:ss"));
        Parameters.Add("@id", order.Id.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool UpdateOrderStatus(Order order, OrderStatus status)
    {
	    Clear();
	    SqlString = @"UPDATE rh_order status_id = @status_id WHERE id = @id";
	    Parameters.Add("@status_id", ((int)status).ToString());
	    Parameters.Add("@id", order.Id.ToString());
	    return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public List<Order>? GetAll(DateTime? date = null, DeliveryOption? deliveryOption = null)
    {
        Clear();
        // using HashSet to prevent duplicate orders
        var orders = new HashSet<Order>();

        SqlString = "SELECT o.id, o.person_id, o.createdDate, o.deliveryDay, o.slotDuration, o.status_id, " +
                    "op.product_id, op.amount, p.name, pe.email, pe.password, pe.firstname, " +
                    "pe.lastname, pe.phone, pe.role_id, a.id address_id, a.street, a.street_number, a.zipCode,a.city, " +
                    "a.is_pickup_address, h.address_id home_id, ra.street home_street, ra.street_number home_number, " +
                    "ra.zipCode home_code, ra.city home_city,o.address_id delivered_id, rha.street delivered_street, " +
                    "rha.street_number delivered_number, rha.zipCode delivered_code, rha.city delivered_city, " +
                    "rha.is_pickup_address delivered_pickup , p.subcategory_id, ca.name SubCategory,rc.id CategId, " +
                    "rc.name Category, op.paid_price, p.quantity, p.unit_id, u.name Unit " +
                    "FROM rh_order o " +
                    "LEFT JOIN rh_order_products op ON op.order_id = o.id " +
                    "LEFT JOIN rh_product p ON p.id = op.product_id " +
                    "LEFT JOIN rh_person pe ON pe.id = o.person_id " +
                    "LEFT JOIN rh_category ca ON ca.id = p.subcategory_id " +
                    "LEFT JOIN rh_unit u ON u.id = p.unit_id " +
                    "LEFT JOIN rh_category rc ON rc.id = ca.parent_id " +
                    "LEFT JOIN rh_role r on r.id = pe.role_id " +
                    "LEFT JOIN rh_address a ON a.id = r.shop_address_id " +
                    "LEFT JOIN rh_home_addresses h ON h.customer_id = r.id " +
                    "LEFT JOIN rh_address ra ON ra.id = h.address_id " +
                    "LEFT JOIN rh_home_addresses ha ON ha.address_id = o.address_id " +
                    "LEFT JOIN rh_address rha ON rha.id = ha.address_id " +
                    "WHERE 1 = 1";
        if (date != null)
        {
            SqlString += " AND o.deliveryDay = @deliveryDay";
            Parameters.Add("@deliveryDay", date.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        if (deliveryOption != null)
        {
            SqlString += " AND o.slotDuration = @slotDuration";
            Parameters.Add("@slotDuration", deliveryOption.GetSlotDuration().ToString());
        }

        DataSet = _dbQueries.Select(SqlString, Parameters);
        for (var i = 0; i < DataSet.Tables[0].Rows.Count; i++)
        {
            var row = DataSet.Tables[0].Rows[i];
            var orderId = (int)row["id"];
            if (orders.Any(o => o.Id == (int)row["id"])) continue; // if the order is already in the hashset, we skip it so that the method does not take too much time
            var person = new Person(new Credentials((string)row["email"], (string)row["password"]),
                (string)row["firstname"], (string)row["lastname"], (string)row["phone"], (int)row["person_id"],
                new Customer((int)row["role_id"], IsDBNull(row["address_id"]) ? null : new Address((int)row["address_id"], (string)row["street"], (string)row["street_number"], (string)row["zipCode"], (string)row["city"])));
            var deliveryAddress = new Address((int)row["delivered_id"], (string)row["delivered_street"], (string)row["delivered_number"], (string)row["delivered_code"], (string)row["delivered_city"]);
            for (var j = 0; j < DataSet.Tables[0].Rows.Count; j++)
            {
                row = DataSet.Tables[0].Rows[j];
                if (orderId == (int)row["id"] && !IsDBNull(row["home_id"]))
                    ((Customer)person.Role!).AddAddress(new Address((int)row["home_id"], (string)row["home_street"], (string)row["home_number"], (string)row["home_code"], (string)row["home_city"]));
            }

            // reassign row to the first row of the data table(was changed in for)
            row = DataSet.Tables[0].Rows[i];
            var order = new Order(orderId, person, (bool)row["delivered_pickup"] ? new PickUpDelivery(DateOnly.FromDateTime((DateTime)row["deliveryDay"]), deliveryAddress) : new HomeDelivery(person, DateOnly.FromDateTime((DateTime)row["deliveryDay"]), deliveryAddress),
                new TimeSlot((DateTime)row["deliveryDay"], (int)row["slotDuration"]), deliveryAddress,
                (OrderStatus)(int)row["status_id"], (DateTime)row["createdDate"]);
            for (var j = 0; j < DataSet.Tables[0].Rows.Count; j++)
            {
                row = DataSet.Tables[0].Rows[j];
                if (IsDBNull(row["product_id"]) || orderId != (int)row["id"]) continue;
                order.AddItem(new Item(
                    new Product((int)row["product_id"], (string)row["name"], (decimal)row["paid_price"],
                        new Category((int)row["subcategory_id"], (string)row["SubCategory"],
                            new Category((int)row["CategId"], (string)row["Category"])),
                        new Quantity((int)row["quantity"], (QuantityUnit)(int)row["unit_id"])), (int)row["amount"]));
            }

            orders.Add(order);
        }

        return orders.ToList();
    }

    public List<Order> GetAllOrdersByCustomer(Person customer)
    {
        Clear();
        // using HashSet to prevent duplicate orders
        var orders = new List<Order>();

        SqlString = "SELECT o.id, o.person_id, o.createdDate, o.deliveryDay, o.slotDuration, o.status_id, " +
                    "op.product_id, op.amount, o.address_id delivered_id, rha.street delivered_street, " +
                    "rha.street_number delivered_number, rha.zipCode delivered_code, rha.city delivered_city, " +
                    "rha.is_pickup_address delivered_pickup , p.subcategory_id, ca.name SubCategory,rc.id CategId, " +
                    "rc.name Category, op.paid_price, p.quantity, p.unit_id, u.name Unit " +
                    "FROM rh_order o " +
                    "LEFT JOIN rh_order_products op ON op.order_id = o.id " +
                    "LEFT JOIN rh_product p ON p.id = op.product_id " +
                    "LEFT JOIN rh_person pe ON pe.id = o.person_id " +
                    "LEFT JOIN rh_category ca ON ca.id = p.subcategory_id " +
                    "LEFT JOIN rh_unit u ON u.id = p.unit_id " +
                    "LEFT JOIN rh_category rc ON rc.id = ca.parent_id " +
                    "LEFT JOIN rh_home_addresses ha ON ha.address_id = o.address_id " +
                    "LEFT JOIN rh_address rha ON rha.id = ha.address_id " +
                    "WHERE o.person_id = @person_id";
        Parameters.Add("@person_id", customer.Id.ToString());
        DataSet = _dbQueries.Select(SqlString, Parameters);

        for (var i = 0; i < DataSet.Tables[0].Rows.Count; i++)
        {
            var row = DataSet.Tables[0].Rows[i];
            var orderId = (int)row["id"];
            if (orders.Any(o => o.Id == (int)row["id"])) continue; // if the order is already in the hashset, we skip it so that the method does not take too much time
            var deliveryAddress = new Address((int)row["delivered_id"], (string)row["delivered_street"], (string)row["delivered_number"], (string)row["delivered_code"], (string)row["delivered_city"]);
            var order = new Order(orderId, customer, (bool)row["delivered_pickup"] ? new PickUpDelivery(DateOnly.FromDateTime((DateTime)row["deliveryDay"]), deliveryAddress) : new HomeDelivery(customer, DateOnly.FromDateTime((DateTime)row["deliveryDay"]), deliveryAddress),
                new TimeSlot((DateTime)row["deliveryDay"], (int)row["slotDuration"]), deliveryAddress,
                (OrderStatus)(int)row["status_id"], (DateTime)row["createdDate"]);
            for (var j = 0; j < DataSet.Tables[0].Rows.Count; j++)
            {
                row = DataSet.Tables[0].Rows[j];
                if (IsDBNull(row["product_id"]) || orderId != (int)row["id"]) continue;
                order.AddItem(new Item(
                    new Product((int)row["product_id"], (string)row["name"], (decimal)row["paid_price"],
                        new Category((int)row["subcategory_id"], (string)row["SubCategory"],
                            new Category((int)row["CategId"], (string)row["Category"])),
                        new Quantity((int)row["quantity"], (QuantityUnit)(int)row["unit_id"])), (int)row["amount"]));
            }

            orders.Add(order);
        }

        return orders;
    }

    public Order GetOrder(Order order)
    {
        Clear();
        SqlString = "SELECT o.id, o.person_id, o.createdDate, o.deliveryDay, o.slotDuration, o.status_id, " +
                    "op.product_id, op.amount, p.name, pe.email, pe.password, pe.firstname, " +
                    "pe.lastname, pe.phone, pe.role_id, a.id address_id, a.street, a.street_number, a.zipCode,a.city, " +
                    "a.is_pickup_address, h.address_id home_id, ra.street home_street, ra.street_number home_number, " +
                    "ra.zipCode home_code, ra.city home_city,o.address_id delivered_id, rha.street delivered_street, " +
                    "rha.street_number delivered_number, rha.zipCode delivered_code, rha.city delivered_city, " +
                    "rha.is_pickup_address delivered_pickup , p.subcategory_id, ca.name SubCategory,rc.id CategId, " +
                    "rc.name Category, op.paid_price, p.quantity, p.unit_id, u.name Unit " +
                    "FROM rh_order o " +
                    "LEFT JOIN rh_order_products op ON op.order_id = o.id " +
                    "LEFT JOIN rh_product p ON p.id = op.product_id " +
                    "LEFT JOIN rh_person pe ON pe.id = o.person_id " +
                    "LEFT JOIN rh_category ca ON ca.id = p.subcategory_id " +
                    "LEFT JOIN rh_unit u ON u.id = p.unit_id " +
                    "LEFT JOIN rh_category rc ON rc.id = ca.parent_id " +
                    "LEFT JOIN rh_role r on r.id = pe.role_id " +
                    "LEFT JOIN rh_address a ON a.id = r.shop_address_id " +
                    "LEFT JOIN rh_home_addresses h ON h.customer_id = r.id " +
                    "LEFT JOIN rh_address ra ON ra.id = h.address_id " +
                    "LEFT JOIN rh_home_addresses ha ON ha.address_id = o.address_id " +
                    "LEFT JOIN rh_address rha ON rha.id = ha.address_id " +
                    "WHERE o.id = @id";
        Parameters.Add("@id", order.Id.ToString());
        DataSet = _dbQueries.Select(SqlString, Parameters);
        var row = DataSet.Tables[0].Rows[0];
        var orderId = (int)row["id"];
        var person = new Person(new Credentials((string)row["email"], (string)row["password"]),
            (string)row["firstname"], (string)row["lastname"], (string)row["phone"], (int)row["person_id"],
            new Customer((int)row["role_id"], IsDBNull(row["address_id"]) ? null : new Address((int)row["address_id"], (string)row["street"], (string)row["street_number"], (string)row["zipCode"], (string)row["city"])));
        var deliveryAddress = new Address((int)row["delivered_id"], (string)row["delivered_street"], (string)row["delivered_number"], (string)row["delivered_code"], (string)row["delivered_city"]);
        for (var j = 0; j < DataSet.Tables[0].Rows.Count; j++)
        {
            row = DataSet.Tables[0].Rows[j];
            if (!IsDBNull(row["home_id"]))
                ((Customer)person.Role!).AddAddress(new Address((int)row["home_id"], (string)row["home_street"], (string)row["home_number"], (string)row["home_code"], (string)row["home_city"]));
        }

        row = DataSet.Tables[0].Rows[0];
        order = new Order(orderId, person, (bool)row["delivered_pickup"] ? new PickUpDelivery(DateOnly.FromDateTime((DateTime)row["deliveryDay"]), deliveryAddress) : new HomeDelivery(person, DateOnly.FromDateTime((DateTime)row["deliveryDay"]), deliveryAddress),
            new TimeSlot((DateTime)row["deliveryDay"], (int)row["slotDuration"]), deliveryAddress,
            (OrderStatus)(int)row["status_id"], (DateTime)row["createdDate"]);
        for (var j = 0; j < DataSet.Tables[0].Rows.Count; j++)
        {
            row = DataSet.Tables[0].Rows[j];
            if (IsDBNull(row["product_id"]) || orderId != (int)row["id"]) continue;
            order.AddItem(new Item(
                new Product((int)row["product_id"], (string)row["name"], (decimal)row["paid_price"],
                    new Category((int)row["subcategory_id"], (string)row["SubCategory"],
                        new Category((int)row["CategId"], (string)row["Category"])),
                    new Quantity((int)row["quantity"], (QuantityUnit)(int)row["unit_id"])), (int)row["amount"]));
        }

        return order;
    }

    private void Clear()
    {
        Parameters.Clear();
        DataSet.Clear();
        SqlString = string.Empty;
    }
}