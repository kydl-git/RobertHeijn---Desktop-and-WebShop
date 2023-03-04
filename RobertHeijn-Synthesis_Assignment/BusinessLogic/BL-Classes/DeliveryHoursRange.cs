namespace BusinessLogic.BL_Classes;

public sealed class DeliveryHoursRange
{
    public DeliveryHoursRange(TimeOnly start, TimeOnly end, int noOfSlots)
    {
        Start = start;
        End = end;
        TimeSlots = SetTimeSlots(start, end, noOfSlots);
    }

    public DeliveryHoursRange(TimeOnly start, TimeOnly end, Dictionary<TimeOnly, Dictionary<int, TimeSlot>> timeSlot)
    {
        Start = start;
        End = end;
        TimeSlots = timeSlot;
    }

    public TimeOnly Start { get; }
    public TimeOnly End { get; }
    public Dictionary<TimeOnly, Dictionary<int, TimeSlot>> TimeSlots { get; }

    private static Dictionary<TimeOnly, Dictionary<int, TimeSlot>> SetTimeSlots(TimeOnly start, TimeOnly end, int noOfSlots)
    {
        var timeSlots = new Dictionary<TimeOnly, Dictionary<int, TimeSlot>>();
        var timeDiff = end - start;
        var hours = timeDiff.Hours;
        if(noOfSlots <= 0)
			throw new ArgumentException("Number of slots must be greater than 0");
        var slotDuration = noOfSlots > 1 ? TimeSpan.FromMinutes(60) / noOfSlots : TimeSpan.FromMinutes(60);
        var minutes = timeDiff.Minutes;
        // handling possible future cases in which the time difference is something like 9h:30min and not only 9h.
        if (minutes >= (int)slotDuration.TotalMinutes)
        {
	        var endTimeOnly = new TimeOnly(end.Hour, 0);
            timeSlots.Add(endTimeOnly, new Dictionary<int, TimeSlot>());
            timeSlots[endTimeOnly].Add(1, new TimeSlot(endTimeOnly, slotDuration));
            if (minutes / slotDuration.Minutes == 1) return timeSlots;
            for (var x = 2; x <= minutes /slotDuration.Minutes ; x++) timeSlots[endTimeOnly].Add(x, new TimeSlot(endTimeOnly.Add(slotDuration), slotDuration));
        }

        // if the time difference in hours is 0 then return the already created timeslots dictionary.
        if (start.Hour == end.Hour)
            return timeSlots;
        // if the time difference is more than 1 hour, we need to add the time slots for the hours in between.
        for (var i = 0; i < hours; i++)
        {
	        timeSlots.Add(start.AddHours(i), new Dictionary<int, TimeSlot>());
	        for (var j = 1; j <= noOfSlots; j++)
	        {
		        timeSlots[start.AddHours(i)].Add(j, j == 1 ? new TimeSlot(start.AddHours(i), slotDuration) : new TimeSlot(start.AddHours(i).Add(new TimeSpan(slotDuration.Ticks * (j-1))), slotDuration));
	        }
        }

        return timeSlots;
		}
}