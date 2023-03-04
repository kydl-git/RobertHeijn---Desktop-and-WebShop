namespace BusinessLogic.BL_Classes;

public sealed class PickUpDelivery : DeliveryOption
{
    private const int NoOfSlots = 2;

    public PickUpDelivery(DateOnly deliveryDay, Address? address) : base(deliveryDay, address)
    {
        HoursRange = new DeliveryHoursRange(new TimeOnly(8, 0, 0), new TimeOnly(22, 0, 0), NoOfSlots);
        DeliveryDay = deliveryDay;
        Address = address;
    }public PickUpDelivery(DateOnly deliveryDay) : base(deliveryDay)
    {
	    HoursRange = new DeliveryHoursRange(new TimeOnly(8, 0, 0), new TimeOnly(22, 0, 0), NoOfSlots);
	    DeliveryDay = deliveryDay;
    }
    public PickUpDelivery(): base()
	{
		HoursRange = new DeliveryHoursRange(new TimeOnly(8, 0, 0), new TimeOnly(22, 0, 0), NoOfSlots);
	}
}