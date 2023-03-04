#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_Enums;

#endregion

namespace BusinessLogic.BL_DaL_Interfaces;

public interface IOrderActionable
{
	protected internal bool CreateOrder(Order order);
	protected internal bool UpdateOrderDeliveryDay(Order order, DateTime deliveryDay);
	protected internal bool UpdateOrderStatus(Order order, OrderStatus status);
    List<Order>? GetAll(DateTime? date = null, DeliveryOption? deliveryOption = null);
    List<Order> GetAllOrdersByCustomer(Person customer);
    protected internal Order GetOrder(Order order);
}