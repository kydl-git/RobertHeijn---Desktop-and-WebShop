using System.ComponentModel;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_Enums;
using Humanizer;

namespace RobertHeijn_Management_App.Models;

public class OrderModel
{
	public int? Id { get; }
	[DisplayName("OrderDate")]
	public string OrderDate => CreateDate.ToString("dd/MM/yyyy");
	[Browsable(false)]
	public DateTime CreateDate { get; set; }
	[DisplayName("CustomerName")]
	public string? CustomerName  => $"{Customer.FirstName} {Customer.LastName}";
	[Browsable(false)]
	public Person Customer { get; set; }
	public decimal TotalPrice { get; set; }
	[Browsable(false)]
	public DeliveryOption DeliveryOption { get; }
	[DisplayName("DeliveryDay")]
	public string DeliveryDay => DeliveryOption.GetDeliveryDay().ToString("dd/MM/yyyy");
	[DisplayName("DeliveryTime")]
	public string DeliveryTime => TimeSlot.StartTime.ToString("HH:mm:ss") + " - " + TimeSlot.EndTime.ToString("HH:mm:ss");
	[Browsable(false)]
	public TimeSlot TimeSlot { get; set; }
	public string Status => OrderStatus.Humanize(LetterCasing.Title);
	
	[Browsable(false)]
	public OrderStatus OrderStatus { get; set; }
	
	public OrderModel(Order order)
	{
		Id = order.Id;
		CreateDate = order.CreateDate;
		Customer = order.Customer!;
		TotalPrice = order.TotalPrice;
		DeliveryOption = order.DeliveryOption;
		TimeSlot = order.TimeSlot;
		OrderStatus = order.Status;
	}
}