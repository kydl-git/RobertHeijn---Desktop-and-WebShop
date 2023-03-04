using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.Data_Exceptions;
using Microsoft.Extensions.Logging;
using RobertHeijn_Management_App.Models;

namespace RobertHeijn_Management_App.Controls.ShopUserControls;
public partial class OrderManagementUc : UserControl
{
	private readonly IOrderActionable _orderActionable;
	private readonly ILogger<OrderManagementUc> _logger;
	private Order? _selectedOrder;
	private List<Order>? _orders;
	public OrderManagementUc(IOrderActionable orderActionable, ILoggerFactory factory)
	{
		InitializeComponent();
		_logger = factory.CreateLogger<OrderManagementUc>();
		_orderActionable = orderActionable;
		FillDgv();
	}
	public void FillDgv()
	{
		try
		{
			_orders = _orderActionable.GetAll();
		}
		catch (DataAccessException data)
		{
			_logger.LogError("{PageName} => \n{Error}", Name, data.Message);
			MessageBox.Show(data.Message);
		}
		catch (Exception ex)
		{
			_logger.LogWarning("{PageName} => \n{Error}", Name, ex.Message);
			MessageBox.Show(@"Something went wrong");
		}
		dgvOrdersList.DataSource = null;
		dgvOrdersList.DataBindings.Clear();
		var bindingList = new BindingList<OrderModel>(_orders!.Select(x => new OrderModel(x)).ToList());
		var bindingSource = new BindingSource(bindingList, null);
		dgvOrdersList.DataSource = bindingSource;
		RemoveColumns();
		GenerateColumns();
	}
	
	private void GenerateColumns()
	{
		var idColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "Id",
			Name = "OrderID",
			HeaderText = @"Order ID",
			ReadOnly = true
		};
		var createColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "OrderDate",
			Name = "OrderDate",
			HeaderText = @"Order Date",
			ReadOnly = true
		};
		var customerColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "CustomerName",
			Name = "CustomerName",
			HeaderText = @"Customer Name",
			ReadOnly = true
		};
		var priceColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "TotalPrice",
			Name = "TotalPrice",
			HeaderText = @"Total Price",
			ReadOnly = true
		};
		var deliveryDayColumn = new DataGridViewTextBoxColumn()
		{
			DataPropertyName = "DeliveryDay",
			Name = "DeliveryDay",
			HeaderText = @"Delivery Day",
			ReadOnly = true
		};
		var deliveryTimeColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "DeliveryTime",
			Name = "DeliveryTime",
			HeaderText = @"Delivery Time",
			ReadOnly = true
		};
		var statusColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "Status",
			Name = "OrderStatus",
			HeaderText = @"Order Status",
			ReadOnly = true
		};
		dgvOrdersList.Columns.Add(idColumn);
		dgvOrdersList.Columns.Add(createColumn);
		dgvOrdersList.Columns.Add(customerColumn);
		dgvOrdersList.Columns.Add(priceColumn);
		dgvOrdersList.Columns.Add(deliveryDayColumn);
		dgvOrdersList.Columns.Add(deliveryTimeColumn);
		dgvOrdersList.Columns.Add(statusColumn);
	}

	private void RemoveColumns()
	{
		for (var i = dgvOrdersList.Columns.Count - 1; i >= 0; i--)
			dgvOrdersList.Columns.RemoveAt(i);
	}
	private void DgvOrdersList_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0) 
			_selectedOrder = GetOrder((int)dgvOrdersList[0, e.RowIndex].Value);
	}

	private Order? GetOrder(int orderId)
	{
		var order = new Order();
		try
		{
			_orders = _orderActionable.GetAll();
			order = _orders.First(p => p.Id == orderId);
		}
		catch (NoDataFoundException ndf)
		{
			_logger.LogError("{PageName} => \n{Error}", Name, ndf.Message);
			MessageBox.Show(ndf.Message);
		}
		catch (Exception ex)
		{
			_logger.LogCritical("{PageName} => \n{Error}", Name, ex.Message);
			MessageBox.Show(@"Something went wrong");
		}

		return order!;
	}
	private void DgvOrdersList_DataBindingComplete(object sender, EventArgs e)
	{
		dgvOrdersList.ClearSelection();
	}

	private void BtnEditOrderStatus_Click(object sender, EventArgs e)
	{
		if (_selectedOrder != null && dgvOrdersList.SelectedCells.Count > 0 && dgvOrdersList.CurrentCell != null)
		{
			var changeOrderStatusPopUp = new FormFactory.FormFactory().CreateChangeOrderStatusPopUp(_selectedOrder);
			changeOrderStatusPopUp.ShowDialog();
			FillDgv();
		}
		else
		{
			MessageBox.Show(@"Select a row to edit!");
		}
	}
}
