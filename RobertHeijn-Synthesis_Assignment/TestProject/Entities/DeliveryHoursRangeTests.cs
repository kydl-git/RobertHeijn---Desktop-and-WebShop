using BusinessLogic.BL_Classes;

namespace TestProject.Entities;
using FluentAssertions;
using Xunit;

public class DeliveryHoursRangeTests
{
	[Theory]
	[InlineData(1,2,4)]
	[InlineData(1,2,2)]
	[InlineData(8,22,4)]
	[InlineData(8,22,1)]
	public void DeliveryHoursRange_WhenValidRange_ShouldReturnCorrectNumberOfHours(int start, int end, int noOfSlots)
	{
		// Arrange
		var startTime = new TimeOnly(start, 0, 0);
		var endTime = new TimeOnly(end, 0, 0);
		// Act
		var range = new DeliveryHoursRange(startTime, endTime, noOfSlots);
		// Assert
		range.TimeSlots.First().Value.Count.Should().Be(noOfSlots);
	}
	[Theory]
	[InlineData(1,2,0)]
	[InlineData(1,2,-1)]
	public void DeliveryHoursRange_WhenInvalidRange_ShouldThrowException(int start, int end, int noOfSlots)
	{
		// Arrange
		var startTime = new TimeOnly(start, 0, 0);
		var endTime = new TimeOnly(end, 0, 0);
		// Act
		Action act = () => new DeliveryHoursRange(startTime, endTime, noOfSlots);
		// Assert
		act.Should().Throw<ArgumentException>();
	}
	[Theory]
	[InlineData(1,2,30,4,2)]
	[InlineData(8,9,45,4,3)]
	[InlineData(8,9,40,6,4)]
	public void DeliveryHoursRange_WhenValidRange_ShouldReturnCorrectNumberOfSlots(int start, int end, int endMinutes, int noOfSlots, int expectedNoOfSlots)
	{
		// Arrange
		var startTime = new TimeOnly(start, 0, 0);
		var endTime = new TimeOnly(end, endMinutes, 0);
		// Act
		var range = new DeliveryHoursRange(startTime, endTime, noOfSlots);
		// Assert
		range.TimeSlots.First().Value.Count.Should().Be(expectedNoOfSlots);
	}
	
	[Theory]
	[InlineData(1,2,4,15)]
	[InlineData(8,9,5,12)]
	[InlineData(8,9,6,10)]
	[InlineData(8,9,3,20)]
	public void DeliveryHoursRange_WhenValidRange_ShouldReturnCorrectSlotDuration(int start, int end, int noOfSlots, int expectedSlotDuration)
	{
		// Arrange
		var startTime = new TimeOnly(start, 0, 0);
		var endTime = new TimeOnly(end, 0, 0);
		// Act
		var range = new DeliveryHoursRange(startTime, endTime, noOfSlots);
		// Assert
		range.TimeSlots.First().Value.First().Value.GetSlotDuration().Should().Be(expectedSlotDuration);
	}
	[Theory]
	[InlineData(1,2,4)]
	[InlineData(8,9,5)]
	[InlineData(8,9,6)]
	[InlineData(8,9,3)]
	public void DeliveryHoursRange_WhenValidRange_StartTime_And_EndTime_ShouldBeAsProvided(int start, int end, int noOfSlots)
	{
		// Arrange
		var startTime = new TimeOnly(start, 0, 0);
		var endTime = new TimeOnly(end, 0, 0);
		// Act
		var range = new DeliveryHoursRange(startTime, endTime, noOfSlots);
		// Assert
		range.Start.Should().Be(startTime);
		range.End.Should().Be(endTime);
	}
}