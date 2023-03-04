#region

using System.Data;
using System.Globalization;
using BusinessLogic.Data_Exceptions;
using MySqlConnector;

#endregion

namespace DataAccessLayer;

public sealed class DbQueries
{
    private readonly MySqlConnection _connection;

    public DbQueries(string connectionString)
    {
        _connection = new MySqlConnection(connectionString);
    }

    /// <summary>
    ///     Method for Create/Update/Delete operations
    /// </summary>
    /// <param name="sqlString">The sql string.</param>
    /// <param name="paramDictionary"></param>
    /// <returns>A Task.</returns>
    internal bool InsertUpdateDelete(string sqlString, Dictionary<string, string?>? paramDictionary)
    {
        bool result;
        try
        {
            var cmd = new MySqlCommand
            {
                Connection = _connection,
                CommandType = CommandType.Text,
                CommandText = sqlString
            };
            if (paramDictionary != null && paramDictionary.Count != 0)
                foreach (var s in paramDictionary)
                    cmd.Parameters.AddWithValue($"{s.Key}", $"{s.Value}");
            OpenConnection(_connection);
            var affectedRows = cmd.ExecuteNonQuery();
            if (affectedRows == 0)
                throw new SqlNoChangesMadeException("No changes were made to the database.\n" +
                                                    "Please check your input and try again.");
            result = true;
        }
        catch (MySqlException e)
        {
            throw new IncorrectSqlQueryException("Check your sql query, the following error was found:\n" +
                                                 $"{e.Message}");
        }
        catch (InvalidOperationException ex)
        {
            throw new GeneralQueryException(ex.Message);
        }
        finally
        {
            _connection.Close();
        }

        return result;
    }

    /// <summary>
    ///     Method for reading data from the database
    /// </summary>
    /// <param name="sqlString">The sql string.</param>
    /// <param name="paramDictionary">The param dictionary.</param>
    /// <returns>A Dataset which contains the results.</returns>
    internal DataSet Select(string sqlString, Dictionary<string, string?>? paramDictionary)
    {
        DataSet result = new();
        try
        {
            var cmd = new MySqlCommand
            {
                Connection = _connection,
                CommandType = CommandType.Text,
                CommandText = sqlString
            };
            if (paramDictionary != null && paramDictionary.Count != 0)
                foreach (var s in paramDictionary)
                    cmd.Parameters.AddWithValue($"{s.Key}", $"{s.Value}");
            OpenConnection(_connection);
            var da = new MySqlDataAdapter(cmd);
            result.Clear();
            da.Fill(result);
            // Added the check for paramDictionary.Count != 0 to allow the forms to load at start of program.
            if ((result.Tables.Count == 0 || result.Tables[0].Rows.Count == 0 ) && paramDictionary!.Count != 0)
                throw new NoDataFoundException("Invalid input, check input fields and try again.");
        }
        catch (MySqlException e)
        {
            throw new IncorrectSqlQueryException("Check your sql query, the following error was found:\n" +
                                                 $"{e.Message}");
        }
        catch (InvalidOperationException ex)
        {
            throw new GeneralQueryException(ex.Message);
        }
        finally
        {
            _connection.Close();
        }

        return result;
    }

    /// <summary>
    ///     Method for filtering data from the database based on a stored procedure
    /// </summary>
    /// <param name="sqlString">The sql string.</param>
    /// <param name="paramDictionary">The param dictionary.</param>
    /// <returns>A Dataset which contains the results.</returns>
    internal DataSet FilterWithStoredProcedure(string sqlString, Dictionary<string, string?>? paramDictionary)
    {
        DataSet result = new();
        try
        {
            using var cmd = new MySqlCommand
            {
                Connection = _connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = sqlString
            };
            if (paramDictionary != null && paramDictionary.Count != 0)
                foreach (var s in paramDictionary)
                    cmd.Parameters.AddWithValue($"{s.Key}", s.Value == null ? DBNull.Value.ToString(CultureInfo.InvariantCulture) : $"{s.Value}");
            OpenConnection(_connection);
            var da = new MySqlDataAdapter(cmd);
            result.Clear();
            da.Fill(result);
            if (result.Tables.Count == 0 || result.Tables[0].Rows.Count == 0)
                throw new NoDataFoundException("No data was found with selected parameters\n" +
                                               "\tCheck your input and try again.");
        }
        catch (MySqlException e)
        {
            throw new IncorrectSqlQueryException("Check your sql query, the following error was found:\n" +
                                                 $"{e.Message}");
        }
        catch (InvalidOperationException ex)
        {
            throw new GeneralQueryException(ex.Message);
        }
        finally
        {
            _connection.Close();
        }

        return result;
    }

    private static void OpenConnection(MySqlConnection connection)
    {
        try
        {
            connection.Open();
        }
        catch (MySqlException)
        {
            throw new ConnectionUnavailableException("\tDatabase connection unavailable!\n" +
                                                     "Check your internet connection or connect to VPN!");
        }
    }
}