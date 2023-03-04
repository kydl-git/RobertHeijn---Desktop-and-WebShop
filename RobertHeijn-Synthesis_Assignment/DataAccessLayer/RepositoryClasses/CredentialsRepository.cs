#region

using System.Data;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace DataAccessLayer.RepositoryClasses;

public class CredentialsRepository : ICredentialsActionable
{
    private readonly DbQueries _dbQueries;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CredentialsRepository" />
    ///     class.
    /// </summary>
    /// <param name="dbQueries"></param>
    public CredentialsRepository(DbQueries dbQueries)
    {
        _dbQueries = dbQueries;
    }

    private string SqlString { get; set; } = null!;
    private Dictionary<string, string?> Parameters { get; } = new();
    private DataSet DataSet { get; set; } = new();

    public Credentials ReadCredentials(string? email)
    {
        Clear();
        SqlString = "SELECT pe.email, pe.password FROM rh_person pe WHERE pe.email = @Email";
        Parameters.Add("@Email", email);
        DataSet = _dbQueries.Select(SqlString, Parameters);
        var row = DataSet.Tables[0].Rows[0];
        return new Credentials((string)row["email"], (string)row["password"]);
    }

    public bool Create(Credentials credentials, bool isCustomer)
    {
        Clear();
        SqlString = @"INSERT INTO rh_role VALUES (null,null); "+
                    "SELECT @role_id := LAST_INSERT_ID(); "+
                    "INSERT INTO rh_person (email, password,role_id, isCustomer) VALUES (@Email, @Password,@role_id, @IsCustomer)";
        Parameters.Add("@Email", credentials.Email);
        Parameters.Add("@Password", credentials.Password);
        Parameters.Add("@IsCustomer", isCustomer ? "1" : "0");
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool UpdateEmail(Credentials credentials, string? newEmail)
    {
	    Clear();
	    SqlString = @"SELECT @id := (SELECT id FROM rh_person WHERE email=@Email); "+
	                "UPDATE rh_person SET email=@newEmail WHERE id=@id;";
	    Parameters.Add("@Email", credentials.Email);
	    Parameters.Add("@newEmail", newEmail);
	    return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool UpdatePassword(Credentials credentials, string? newPassword)
    {
        Clear();
        SqlString = @"UPDATE rh_person SET password = @Password WHERE email = @Email";
        Parameters.Add("@Email", credentials.Email);
        Parameters.Add("@Password", newPassword);
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool CheckEmailDuplicate(string? email)
    {
        Clear();
        SqlString = "SELECT Count(pe.email) Value FROM rh_person pe WHERE pe.email = @Email";
        Parameters.Add("@Email", email);
        DataSet = _dbQueries.Select(SqlString, Parameters);
        var row = DataSet.Tables[0].Rows[0];
        return (row["Value"] is long ? (long)row["Value"] : 0) == 0;
    }


    private void Clear()
    {
        Parameters.Clear();
        DataSet.Clear();
        SqlString = string.Empty;
    }
}