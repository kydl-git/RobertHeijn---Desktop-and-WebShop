#region

using System.Data;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Interfaces;

#endregion

namespace DataAccessLayer.RepositoryClasses;

public class AddressRepository : IAddressActionable
{
    private readonly DbQueries _dbQueries;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressRepository" />
    ///     class.
    /// </summary>
    public AddressRepository(DbQueries dbQueries)
    {
        _dbQueries = dbQueries;
    }

    private string SqlString { get; set; } = null!;
    private Dictionary<string, string?> Parameters { get; } = new();
    private DataSet DataSet { get; set; } = new();

    public bool CreatePickUpAddress(Address address)
    {
        Clear();
        SqlString = @"INSERT INTO rh_address (street, street_number, zipCode, city, is_pickup_address) VALUES (@street, @street_number, @zipCode, @city, @is_pickup_address)";
        Parameters.Add("@street", address.Street);
        Parameters.Add("@street_number", address.StreetNumber);
        Parameters.Add("@zipCode", address.ZipCode);
        Parameters.Add("@city", address.City);
        Parameters.Add("@is_pickup_address", "1");
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool UpdateAddress(Address address)
    {
        Clear();
        SqlString = @"UPDATE rh_address SET street = @street, street_number=@street_number, zipCode=@zipCode, city=@city WHERE id = @id";
        Parameters.Add("@street", address.Street);
        Parameters.Add("@street_number", address.StreetNumber);
        Parameters.Add("@zipCode", address.ZipCode);
        Parameters.Add("@city", address.City);
        Parameters.Add("@id", address.Id.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool DeleteAddress(Address address)
    {
        Clear();
        SqlString = @"DELETE FROM rh_address WHERE id = @id";
        Parameters.Add("@id", address.Id.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public List<Address> GetPickUpAddresses()
    {
        List<Address> addresses = new();
        Clear();
        SqlString = "SELECT a.id address_id, a.street, a.street_number, a.zipCode,a.city FROM rh_address a WHERE a.is_pickup_address = 1";
        DataSet = _dbQueries.Select(SqlString, Parameters);
        for (var i = 0; i < DataSet.Tables[0].Rows.Count; i++)
        {
            var row = DataSet.Tables[0].Rows[i];
            addresses.Add(new Address((int)row["id"], (string)row["street"], (string)row["street_number"], (string)row["zipCode"], (string)row["city"]));
        }

        return addresses;
    }


    public bool SetShopAddress(IRole role, Address? address)
    {
        Clear();
        SqlString = "SET @shop_address_id = (SELECT a.id FROM rh_address a " +
                    "WHERE a.street = @street AND a.street_number = @street_number " +
                    "AND a.zipCode = @zipCode AND a.city = @city AND a.is_pickup_address = 1); " +
                    "UPDATE rh_role r SET r.shop_address_id = @shop_address_id WHERE AND r.id = @id";
        Parameters.Add("@street", address?.Street);
        Parameters.Add("@street_number", address?.StreetNumber);
        Parameters.Add("@zipCode", address?.ZipCode);
        Parameters.Add("@city", address?.City);
        Parameters.Add("@id", role.RoleId.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public Address GetShopAddress(IRole role)
    {
        Clear();
        SqlString = "SELECT r.id, r.shop_address_id, a.street, a.street_number, a.zipCode,a.city FROM rh_role r " +
                    "LEFT JOIN rh_address a ON a.id = r.shop_address_id WHERE a.is_pickup_address = 1 AND r.id = @id";
        Parameters.Add("@id", role.RoleId.ToString());
        DataSet = _dbQueries.Select(SqlString, Parameters);
        var row = DataSet.Tables[0].Rows[0];
        return new Address((int)row["shop_address_id"], (string)row["street"], (string)row["street_number"], (string)row["zipCode"], (string)row["city"]);
    }

    private void Clear()
    {
        Parameters.Clear();
        DataSet.Clear();
        SqlString = string.Empty;
    }
}