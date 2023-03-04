#region

using System.Data;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using static System.Convert;

#endregion

namespace DataAccessLayer.RepositoryClasses;

public class PersonRepository : IPersonActionable
{
    private readonly DbQueries _dbQueries;

    /// <summary>
    ///     Initializes a new instance of the <see cref="PersonRepository" />
    ///     class.
    /// </summary>
    public PersonRepository(DbQueries dbQueries)
    {
        _dbQueries = dbQueries;
    }


    private string SqlString { get; set; } = null!;
    private Dictionary<string, string?> Parameters { get; } = new();
    private DataSet DataSet { get; set; } = new();

    public Person GetPerson(string? email)
    {
        Clear();
        SqlString = "SELECT pe.id, pe.email, pe.password, pe.firstname, pe.lastname, pe.phone, pe.role_id, pe.isCustomer, " +
                    "a.id address_id, a.street, CONVERT(a.street_number, char) street_number, a.zipCode,a.city, " +
                    "h.address_id home_id, ra.street home_street, CONVERT(ra.street_number, char) home_number, " +
                    "ra.zipCode home_code, ra.city home_city FROM rh_person pe " +
                    "LEFT JOIN rh_role r on r.id = pe.role_id " +
                    "LEFT JOIN rh_address a ON a.id = r.shop_address_id " +
                    "LEFT JOIN rh_home_addresses h ON h.customer_id = r.id " +
                    "LEFT JOIN rh_address ra ON ra.id = h.address_id " +
                    "WHERE pe.email= @Email";
        Parameters.Add("@Email", email);
        DataSet = _dbQueries.Select(SqlString, Parameters);
        var row = DataSet.Tables[0].Rows[0];
        var returnedPerson = new Person(new Credentials((string)row["email"], (string)row["password"]),
            (string)row["firstname"], (string)row["lastname"], (string)row["phone"], (int)row["id"],
            (bool)row["isCustomer"]
                ? new Customer((int)row["role_id"],
                    IsDBNull(row["address_id"]) ? null : new Address((int)row["address_id"], (string)row["street"], (string)row["street_number"], (string)row["zipCode"], (string)row["city"]))
                : new ShopWorker(
                    IsDBNull(row["address_id"]) ? null : new Address((int)row["address_id"], (string)row["street"], (string)row["street_number"], (string)row["zipCode"], (string)row["city"]), (int)row["role_id"]));
        if (returnedPerson.Role is not Customer customer) return returnedPerson;
        for (var i = 0; i < DataSet.Tables[0].Rows.Count; i++)
        {
            row = DataSet.Tables[0].Rows[i];
            if (!IsDBNull(row["home_id"])) customer.AddAddress(new Address((int)row["home_id"], (string)row["home_street"], (string)row["home_number"], (string)row["home_code"], (string)row["home_city"]));
        }

        return returnedPerson;
    }

    public List<Person> GetPersons()
    {
        List<Person> persons = new();
        Clear();
        SqlString = "SELECT pe.id, pe.email, pe.password, pe.firstname, pe.lastname, pe.phone, pe.role_id, pe.isCustomer, " +
                    "a.id address_id, a.street, CONVERT(a.street_number, char) street_number, a.zipCode,a.city, " +
                    "h.address_id home_id, ra.street home_street, CONVERT(ra.street_number, char) home_number, " +
                    "ra.zipCode home_code, ra.city home_city FROM rh_person pe " +
                    "LEFT JOIN rh_role r on r.id = pe.role_id " +
                    "LEFT JOIN rh_address a ON a.id = r.shop_address_id " +
                    "LEFT JOIN rh_home_addresses h ON h.customer_id = r.id " +
                    "LEFT JOIN rh_address ra ON ra.id = h.address_id ";
        DataSet = _dbQueries.Select(SqlString, Parameters);
        for (var i = 0; i < DataSet.Tables[0].Rows.Count; i++)
        {
            var row = DataSet.Tables[0].Rows[i];
            var person = new Person(new Credentials((string)row["email"], (string)row["password"]),
                (string)row["firstname"], (string)row["lastname"], (string)row["phone"], (int)row["id"],
                (bool)row["isCustomer"]
                    ? new Customer((int)row["role_id"],
                        IsDBNull(row["address_id"]) ? null : new Address((int)row["address_id"], (string)row["street"], (string)row["street_number"], (string)row["zipCode"], (string)row["city"]))
                    : new ShopWorker(
                        IsDBNull(row["address_id"]) ? null : new Address((int)row["address_id"], (string)row["street"], (string)row["street_number"], (string)row["zipCode"], (string)row["city"]), (int)row["role_id"]));
            for (var j = 0; j < DataSet.Tables[0].Rows.Count; j++)
            {
                row = DataSet.Tables[0].Rows[j];
                if (person.Id != (int)row["id"]) continue;
                if (!IsDBNull(row["home_id"]) && person.Role is Customer customer) customer.AddAddress(new Address((int)row["home_id"], (string)row["home_street"], (string)row["home_number"], (string)row["home_code"], (string)row["home_city"]));
            }

            persons.Add(person);
        }

        return persons;
    }

    public bool CreatePerson(Person person)
    {
        Clear();
        SqlString = @"UPDATE rh_person SET firstname = @FirstName, lastname = @LastName, phone = @PhoneNumber WHERE email = @Email";
        Parameters.Add("@FirstName", person.FirstName);
        Parameters.Add("@LastName", person.LastName);
        Parameters.Add("@PhoneNumber", person.Phone);
        Parameters.Add("@Email", person.Credentials.Email);
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool UpdatePhone(Person person, string phone)
    {
        Clear();
        SqlString = @"UPDATE rh_person SET phone = @PhoneNumber WHERE email = @Email";
        Parameters.Add("@PhoneNumber", phone);
        Parameters.Add("@Email", person.Credentials.Email);
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool DeletePerson(Person person)
    {
        Clear();
        SqlString = @"DELETE FROM rh_person WHERE email = @Email";
        Parameters.Add("@Email", person.Credentials.Email);
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool IsPersonAlreadyRegistered(string email)
    {
        Clear();
        SqlString = "SELECT pe.firstname, pe.lastname, pe.phone FROM rh_person pe WHERE pe.email = @Email";
        Parameters.Add("@Email", email);
        DataSet = _dbQueries.Select(SqlString, Parameters);
        var row = DataSet.Tables[0].Rows[0];
        var firstName = IsDBNull(row["firstname"]) ? null : row["firstname"].ToString();
        var lastName = IsDBNull(row["lastname"]) ? null : row["firstname"].ToString();
        var phone = IsDBNull(row["phone"]) ? null : row["firstname"].ToString();
        return firstName != null && lastName != null && phone != null;
    }

    private void Clear()
    {
        Parameters.Clear();
        DataSet.Clear();
        SqlString = string.Empty;
    }
}