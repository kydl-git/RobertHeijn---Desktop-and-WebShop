#region

using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Enums;
using BusinessLogic.BL_Exceptions;

#endregion

namespace BusinessLogic.BL_Classes;

public sealed class Order
{
	private readonly List<Item> _orderItems = new();

	public Order(int id, Person? customer, DeliveryOption deliveryOption, TimeSlot timeSlot, Address deliveryAddress, OrderStatus status, DateTime orderDate)
	{
		Id = id;
		Customer = customer;
		DeliveryOption = deliveryOption;
		TimeSlot = timeSlot;
		DeliveryAddress = deliveryAddress;
		Status = status;
		CreateDate = orderDate;
	}

	public Order()
	{
		
	}
	public Order(Person customer, DeliveryOption deliveryOption, TimeSlot timeSlot, Address deliveryAddress)
	{
		Customer = customer;
		DeliveryOption = deliveryOption;
		TimeSlot = timeSlot;
		DeliveryAddress = deliveryAddress;
		Status = OrderStatus.New;
		CreateDate = DateTime.Now;
	}

	public int? Id { get; }
	public DateTime CreateDate { get; }
	public Person? Customer { get; }
	public IReadOnlyList<Item> Items => _orderItems.AsReadOnly();
	public decimal TotalPrice => _orderItems.Sum(i => i.Amount * i.Product!.Price);
	public DeliveryOption DeliveryOption { get; }
	public TimeSlot TimeSlot { get; private set; }
	public Address DeliveryAddress { get; private set; }
	public OrderStatus Status { get; private set; }

	public bool CreateOrder(IOrderActionable orderService)
	{
		return orderService.CreateOrder(this);
	}
	
	public bool AddItem( Item item)
	{
		if (item == null) throw new ArgumentNullException(nameof(item));

		if (Status != OrderStatus.New) throw new OrderStatusException("Cannot add item to order that is not new");
		if(_orderItems.Any() && _orderItems.Any(x => x.Product == item.Product)) 
			throw new InvalidValueException("Item already exists in order");
		_orderItems.Add(item);
		return _orderItems.Contains(item);
	}

	public bool UpdateStatus(IOrderActionable orderService, OrderStatus status)
	{
		if ((int)status <= (int)Status)
			throw new InvalidOrSameOrderStatusException("Order status cannot be less or same as current status");
		if(orderService.UpdateOrderStatus(this, status)) 
			Status = status;
		return Status == status;
	}

	public bool UpdateDeliveryDayAndTimeSlot(IOrderActionable orderService, DateTime deliveryDay)
	{
		if (DeliveryOption.GetDeliveryDay() >= DateOnly.FromDateTime(deliveryDay))
			throw new InvalidOrSameDeliveryDayException("Delivery day must be bigger than initial delivery day");
		if(deliveryDay < DateTime.Now)
			throw new InvalidOrSameDeliveryDayException("Delivery day must be bigger than current day");
		if (!orderService.UpdateOrderDeliveryDay(this, deliveryDay)) return TimeSlot.StartTime == new TimeOnly(deliveryDay.Hour, deliveryDay.Minute, deliveryDay.Second);
		DeliveryOption.SetDeliveryDay(DateOnly.FromDateTime(deliveryDay));
		TimeSlot.UpdateTimeSlot(deliveryDay);
		return TimeSlot.StartTime == new TimeOnly(deliveryDay.Hour, deliveryDay.Minute, deliveryDay.Second);
	}
	public Order GetOrder(IOrderActionable orderService)
	{
		return orderService.GetOrder(this);
	}
}