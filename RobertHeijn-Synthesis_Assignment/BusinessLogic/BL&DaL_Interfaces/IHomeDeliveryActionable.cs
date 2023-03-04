#region

using BusinessLogic.BL_Classes;

#endregion

namespace BusinessLogic.BL_DaL_Interfaces;

public interface IHomeDeliveryActionable
{
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
    protected internal int CountOrdersByTimeSlot(TimeSlot slot, DateOnly deliveryDay);
}