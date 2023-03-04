namespace BusinessLogic.BL_Classes;

public abstract class DeliveryOption
{
    protected DeliveryOption(DateOnly deliveryDay, Address? address)
    {
        DeliveryDay = deliveryDay;
        Address = address;
    }

    protected DeliveryOption(DateOnly deliveryDay)
    {
        DeliveryDay = deliveryDay;
    }
    protected DeliveryOption()
	{
	}

    public DeliveryHoursRange HoursRange { get; protected set; }
    protected DateOnly DeliveryDay { get; set; }
    protected Address? Address { get; set; }

    public bool SetAddress(Address? address)
    {
        if (address == null) return false;
        Address = address;
        return true;
    }

    public int GetSlotDuration()
    {
        return HoursRange.TimeSlots.First().Value.First().Value.GetSlotDuration();
    }

    public void SetDeliveryDay(DateOnly deliveryDay)
    {
        DeliveryDay = deliveryDay;
    }

    public DateOnly GetDeliveryDay()
    {
        return DeliveryDay;
    }
}