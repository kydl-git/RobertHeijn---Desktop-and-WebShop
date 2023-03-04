#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace BusinessLogic.Services;

public sealed class HomeDeliveryService : IHomeDeliveryActionable
{
    private readonly IHomeDeliveryActionable _homeDeliveryRepository;

    public HomeDeliveryService(IHomeDeliveryActionable homeDeliveryRepository)
    {
        _homeDeliveryRepository = homeDeliveryRepository;
    }


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
        return _homeDeliveryRepository.CountOrdersByTimeSlot(slot, deliveryDay);
    }
}