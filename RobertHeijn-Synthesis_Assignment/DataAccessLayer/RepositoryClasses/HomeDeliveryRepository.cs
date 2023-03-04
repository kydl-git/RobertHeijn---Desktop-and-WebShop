#region

using System.Data;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace DataAccessLayer.RepositoryClasses;

public class HomeDeliveryRepository : IHomeDeliveryActionable
{
    private readonly DbQueries _dbQueries;

    /// <summary>
    ///     Initializes a new instance of the <see cref="HomeDeliveryRepository" />
    ///     class.
    /// </summary>
    /// <param name="dbQueries"></param>
    public HomeDeliveryRepository(DbQueries dbQueries)
    {
        _dbQueries = dbQueries;
    }

    private string SqlString { get; set; } = null!;
    private Dictionary<string, string?> Parameters { get; } = new();
    private DataSet DataSet { get; set; } = new();

    /// <summary>
    ///     Count number of orders which are set to be home delivered in a given time
    ///     slot and return that value.
    /// </summary>
    /// <param name="slot">
    ///     The <see cref="TimeSlot" /> for which the orders are
    ///     counted.
    /// </param>
    /// <param name="deliveryDay">
    ///     The day (as <see cref="DateOnly" />) in which to
    ///     search the <see cref="TimeSlot" />.
    /// </param>
    /// <returns></returns>
    public int CountOrdersByTimeSlot(TimeSlot slot, DateOnly deliveryDay)
    {
        Clear();
        SqlString = "SELECT COUNT(*) count FROM rh_order o WHERE o.deliveryDay = @deliveryDay";
        Parameters.Add("@deliveryDay", slot.ToDateTime(deliveryDay).ToString("yyyy-MM-dd HH:mm:ss"));
        DataSet = _dbQueries.Select(SqlString, Parameters);
        var row = DataSet.Tables[0].Rows[0];
        return (int)row["count"];
    }

    private void Clear()
    {
        Parameters.Clear();
        DataSet.Clear();
        SqlString = string.Empty;
    }
}