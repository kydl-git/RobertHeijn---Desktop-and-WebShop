

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_Enums;
using BusinessLogic.BL_Exceptions;
using TestProject.Builders;

namespace TestProject.Entities;

public class OrderTests
{
	[Theory]
	[InlineData(1, 2, 3,15,15)]
	[InlineData(2, 3, 3,0,15)]
	[InlineData(3, 4, 2,15,15)]
	[InlineData(4, 5, 6,30,15)]
	public void CreateOrder_WithValidData(int id, int daysAdded, int hour, int min, int duration)
	{
		var timeSlot = new TimeSlot(new TimeOnly(hour, min), new TimeSpan(0, duration, 0));
		var deliveryDay = DateOnly.FromDateTime(DateTime.Now.AddDays(daysAdded));
		var orderDate = DateTime.Now;
		var order = new Order(id, new PersonBuilder().WithDefaultValues(),new HomeDelivery(new PersonBuilder().WithDefaultValues(),deliveryDay, new AddressBuilder().WithDefaultValues()),timeSlot, 
		new AddressBuilder().WithDefaultValues(), OrderStatus.New,orderDate  );
		Assert.Equal(id, order.Id);
		Assert.Equal(deliveryDay, order.DeliveryOption.GetDeliveryDay());
		Assert.Equal(duration, order.DeliveryOption.GetSlotDuration());
	}
	
	[Theory]
	[InlineData(1, 2, 3,15,15, 1, 3, 2)]
	[InlineData(2, 3, 3,0,15,2,4, 2)]
	[InlineData(3, 4, 2,15,15,3,5, 2)]
	[InlineData(4, 5, 6,30,15,4,6, 2)]
	public void AddItemsToOrder_WithValidData(int id, int daysAdded, int hour, int min, int duration, int amount, int value, int newItemAmount)
	{
		var timeSlot = new TimeSlot(new TimeOnly(hour, min), new TimeSpan(0, duration, 0));
		var deliveryDay = DateOnly.FromDateTime(DateTime.Now.AddDays(daysAdded));
		var orderDate = DateTime.Now;
		var order = new Order(id, new PersonBuilder().WithDefaultValues(),new HomeDelivery(new PersonBuilder().WithDefaultValues(),deliveryDay, new AddressBuilder().WithDefaultValues()),timeSlot, 
			new AddressBuilder().WithDefaultValues(), OrderStatus.New,orderDate  );
		var item = new Item(new ProductBuilder().Build(value), amount);
		var newItem = new Item(new ProductBuilder().WithDefaultValues(), newItemAmount);
		order.AddItem(item);
		order.AddItem(newItem);
		order.Items.Count.Should().Be(2);
	}
	[Theory]
	[InlineData(1, 2, 3,15,15, 1, 3, 2)]
	[InlineData(2, 3, 3,0,15,2,4, 2)]
	[InlineData(3, 4, 2,15,15,3,5, 2)]
	[InlineData(4, 5, 6,30,15,4,6, 2)]
	public void AddItemsToOrder_InValidData_ShouldThrowException_WhenAddingSameProduct(int id, int daysAdded, int hour, int min, int duration, int amount, int value, int newItemId)
	{
		var timeSlot = new TimeSlot(new TimeOnly(hour, min), new TimeSpan(0, duration, 0));
		var deliveryDay = DateOnly.FromDateTime(DateTime.Now.AddDays(daysAdded));
		var orderDate = DateTime.Now;
		var order = new Order(id, new PersonBuilder().WithDefaultValues(),new HomeDelivery(new PersonBuilder().WithDefaultValues(),deliveryDay, new AddressBuilder().WithDefaultValues()),timeSlot, 
			new AddressBuilder().WithDefaultValues(), OrderStatus.New,orderDate  );
		var item = new Item(new ProductBuilder().Build(value), amount);
		var newItem = new Item(new ProductBuilder().Build(value), newItemId);
		order.AddItem(item);
		Action act = () => order.AddItem(newItem);
		act.Should().Throw<InvalidValueException>();
	}
	
	[Theory]
	[InlineData(1, 2, 3,15,15, 1, 3, 2)]
	[InlineData(2, 3, 3,0,15,2,4, 2)]
	[InlineData(3, 4, 2,15,15,3,5, 2)]
	[InlineData(4, 5, 6,30,15,4,6, 2)]
	public void AddItemsToOrder_InValidOrderStatus_ShouldThrowException_WhenAddingItems(int id, int daysAdded, int hour, int min, int duration, int amount, int value, int newItemId)
	{
		var timeSlot = new TimeSlot(new TimeOnly(hour, min), new TimeSpan(0, duration, 0));
		var deliveryDay = DateOnly.FromDateTime(DateTime.Now.AddDays(daysAdded));
		var orderDate = DateTime.Now;
		var order = new Order(id, new PersonBuilder().WithDefaultValues(),new HomeDelivery(new PersonBuilder().WithDefaultValues(),deliveryDay, new AddressBuilder().WithDefaultValues()),timeSlot, 
			new AddressBuilder().WithDefaultValues(), OrderStatus.Delivered,orderDate  );
		var item = new Item(new ProductBuilder().WithDefaultValues(), amount);
		var newItem = new Item(new ProductBuilder().Build(value), newItemId);
		Action act1 = () => order.AddItem(item);
		Action act2 = () => order.AddItem(newItem);
		act1.Should().Throw<OrderStatusException>();
		act2.Should().Throw<OrderStatusException>();
	}
	
	[Theory]
	[InlineData(1, 2, 3,15,15, 1, 3, 2)]
	[InlineData(2, 3, 3,0,15,2,4, 2)]
	[InlineData(3, 4, 2,15,15,3,5, 2)]
	[InlineData(4, 5, 6,30,15,4,6, 2)]
	public void AddItemsToOrder_WithValidData_CheckItemAmount(int id, int daysAdded, int hour, int min, int duration, int amount, int value, int newAmount)
	{
		var timeSlot = new TimeSlot(new TimeOnly(hour, min), new TimeSpan(0, duration, 0));
		var deliveryDay = DateOnly.FromDateTime(DateTime.Now.AddDays(daysAdded));
		var orderDate = DateTime.Now;
		var order = new Order(id, new PersonBuilder().WithDefaultValues(),new HomeDelivery(new PersonBuilder().WithDefaultValues(),deliveryDay, new AddressBuilder().WithDefaultValues()),timeSlot, 
			new AddressBuilder().WithDefaultValues(), OrderStatus.New,orderDate  );
		var item = new Item(new ProductBuilder().Build(value), amount);
		order.AddItem(item);
		order.Items.First(i => i == item).Amount.Should().Be(amount);
	}

}