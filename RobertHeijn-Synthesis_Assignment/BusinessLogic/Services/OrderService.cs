#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Enums;

#endregion

namespace BusinessLogic.Services;

public sealed class OrderService : IOrderActionable
{
	private readonly IOrderActionable _orderRepository;

	/// <summary>Initializes a new instance of the <see cref="OrderService" /> class.</summary>
	public OrderService(IOrderActionable orderRepository)
	{
		_orderRepository = orderRepository;
	}


	public bool CreateOrder(Order order)
	{
		return _orderRepository.CreateOrder(order);
	}

	public bool UpdateOrderDeliveryDay(Order order, DateTime deliveryDay)
	{
		return _orderRepository.UpdateOrderDeliveryDay(order, deliveryDay);
	}

	public bool UpdateOrderStatus(Order order, OrderStatus status)
	{
		return _orderRepository.UpdateOrderStatus(order, status);
	}

	public List<Order>? GetAll(DateTime? date = null, DeliveryOption? deliveryOption = null)
	{
		return _orderRepository.GetAll(date, deliveryOption);
	}

	public List<Order> GetAllOrdersByCustomer(Person customer)
	{
		return _orderRepository.GetAllOrdersByCustomer(customer);
	}

	public Order GetOrder(Order order)
	{
		return _orderRepository.GetOrder(order);
	}
}