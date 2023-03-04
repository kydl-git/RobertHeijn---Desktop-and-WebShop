#region

using System.Data;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Interfaces;

#endregion

namespace DataAccessLayer.RepositoryClasses;

public class RolesRepository : IRolesActionable, ICustomerActionable
{
    private readonly DbQueries _dbQueries;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RolesRepository" /> class.
    /// </summary>
    /// <param name="dbQueries"></param>
    public RolesRepository(DbQueries dbQueries)
    {
        _dbQueries = dbQueries;
    }

    private string SqlString { get; set; } = null!;
    private Dictionary<string, string?> Parameters { get; } = new();
    private DataSet DataSet { get; } = new();


    /// <summary>
    ///     Add a <see cref="T:BusinessLogic.BL_Classes.Address" />  to the
    ///     <see cref="T:BusinessLogic.BL_Classes.Customer" />
    /// </summary>
    /// <param name="customer">
    ///     The <see cref="T:BusinessLogic.BL_Classes.Customer" />
    ///     object.
    /// </param>
    /// <param name="address">
    ///     The <see cref="T:BusinessLogic.BL_Classes.Address" />
    ///     object.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the specified
    ///     <see cref="T:BusinessLogic.BL_Classes.Address" /> was added successfully,
    ///     otherwise <see langword="false" />.
    /// </returns>
    public bool AddHomeDeliveryAddress(Customer customer, Address address)
    {
        Clear();
        SqlString = @"INSERT INTO rh_home_addresses (customer_id, address_id) VALUES (@customer_id ,@address_id)";
        Parameters.Add("@customer_id", customer.RoleId.ToString());
        Parameters.Add("@address_id", address.Id.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    /// <summary>
    ///     Remove a <see cref="T:BusinessLogic.BL_Classes.Address" />  from the
    ///     <see cref="T:BusinessLogic.BL_Classes.Customer" />
    /// </summary>
    /// <param name="customer">
    ///     The <see cref="T:BusinessLogic.BL_Classes.Customer" />
    ///     object.
    /// </param>
    /// <param name="address">
    ///     The <see cref="T:BusinessLogic.BL_Classes.Address" />
    ///     object.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the specified
    ///     <see cref="T:BusinessLogic.BL_Classes.Address" /> was removed successfully,
    ///     otherwise <see langword="false" />.
    /// </returns>
    public bool RemoveHomeDeliveryAddressFromCustomer(Customer customer, Address address)
    {
        Clear();
        SqlString = @"DELETE FROM rh_home_addresses WHERE customer_id = @customer_id AND address_id = @address_id";
        Parameters.Add("@customer_id", customer.RoleId.ToString());
        Parameters.Add("@address_id", address.Id.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    /// <summary>
    ///     Updates the shop <see cref="T:BusinessLogic.BL_Classes.Address" /> for a
    ///     <see cref="T:BusinessLogic.BL_Classes.Customer" /> or
    ///     <see cref="T:BusinessLogic.BL_Classes.ShopWorker" />object.
    /// </summary>
    /// <param name="role">
    ///     An object of type
    ///     <see cref="T:BusinessLogic.BL_Classes.Customer" /> or
    ///     <see cref="T:BusinessLogic.BL_Classes.ShopWorker" />,both implementations
    ///     of  <see cref="T:BusinessLogic.BL_Interfaces.IRole" />
    /// </param>
    /// <param name="address">
    ///     The  <see cref="T:BusinessLogic.BL_Classes.Address" />
    ///     which will be set.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the specified
    ///     <see cref="T:BusinessLogic.BL_Interfaces.IRole" /> was updated
    ///     successfully, otherwise <see langword="false" />.
    /// </returns>
    public bool UpdateShopAddress(IRole role, Address address)
    {
        Clear();
        SqlString = @"UPDATE rh_role SET shop_address_id = @address_id WHERE id = @role_id";
        Parameters.Add("@address_id", role.ShopAddress!.Id.ToString());
        Parameters.Add("@role_id", role.RoleId.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }


    private void Clear()
    {
        Parameters.Clear();
        DataSet.Clear();
        SqlString = string.Empty;
    }
}