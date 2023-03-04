namespace BusinessLogic.BL_Classes;

public sealed class TimeSlot
{
    public TimeSlot(TimeOnly startTime, TimeSpan slotDuration)
    {
        StartTime = startTime;
        EndTime = startTime.Add(slotDuration);
    }

    public TimeSlot(DateTime deliveryDate, int slotDuration)
    {
        StartTime = ToTimeOnly(deliveryDate);
        EndTime = StartTime.Add(new TimeSpan(0, slotDuration, 0));
    }

    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }

    public DateTime ToDateTime(DateOnly deliveryDate)
    {
        return new DateTime(deliveryDate.Year, deliveryDate.Month, deliveryDate.Day, StartTime.Hour, StartTime.Minute, StartTime.Second);
    }

    private static TimeOnly ToTimeOnly(DateTime deliveryDate)
    {
        return new TimeOnly(deliveryDate.Hour, deliveryDate.Minute, deliveryDate.Second);
    }

    public bool UpdateTimeSlot(DateTime deliveryDate)
    {
	    var slotDuration = GetSlotDuration();
	    StartTime = ToTimeOnly(deliveryDate);
		EndTime = StartTime.Add(new TimeSpan(0, slotDuration, 0));
		return true;
    }
    public int GetSlotDuration()
    {
        return (int)(EndTime - StartTime).TotalMinutes;
    }
}