#region

using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace BusinessLogic.BL_Classes;

public sealed class HomeDelivery : DeliveryOption
{
    private const int NoOfSlots = 4;

    public HomeDelivery(Person customer, DateOnly deliveryDay, Address? address) : base(deliveryDay, address)
    {
        Customer = customer;
        HoursRange = new DeliveryHoursRange(new TimeOnly(9, 0, 0), new TimeOnly(21, 0, 0), NoOfSlots);
        DeliveryDay = deliveryDay;
        Address = address;
    }

    public HomeDelivery(Person customer, DateOnly deliveryDay) : base(deliveryDay)
    {
        Customer = customer;
        HoursRange = new DeliveryHoursRange(new TimeOnly(9, 0, 0), new TimeOnly(21, 0, 0), NoOfSlots);
        DeliveryDay = deliveryDay;
    }
    public HomeDelivery():base()
	{
		HoursRange = new DeliveryHoursRange(new TimeOnly(9, 0, 0), new TimeOnly(21, 0, 0), NoOfSlots);
	}

    public Person Customer { get; }

    public void SetAvailableTimeSlots(IHomeDeliveryActionable deliveryService)
    {
        var time = HoursRange.TimeSlots.ToDictionary(dit => dit.Key, dit => dit.Value.Where(it => deliveryService.CountOrdersByTimeSlot(it.Value, DeliveryDay) <= 4).ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
        HoursRange = new DeliveryHoursRange(HoursRange.Start, HoursRange.End, time);
    }
}