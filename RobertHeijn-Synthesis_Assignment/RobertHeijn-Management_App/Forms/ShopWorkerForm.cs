#region


#endregion

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Exceptions;
using BusinessLogic.Data_Exceptions;
using Humanizer;
using Microsoft.Extensions.Logging;
using RobertHeijn_Management_App.Behaviours;
using RobertHeijn_Management_App.Controls.ShopUserControls;
using RobertHeijn_Management_App.Models;
using System.ComponentModel;

namespace RobertHeijn_Management_App.Forms;

public partial class ShopWorkerForm : Form
{
	private readonly ICategoryActionable _categoryService;
	private readonly IInventoryActionable _inventoryService;
	private readonly Person _loggedInWorker;
	private readonly ILogger<ShopWorkerForm> _logger;
	private readonly IOrderActionable _orderService;
	private readonly Form _parentForm;
	private readonly IPersonActionable _personService;
	private readonly IProductActionable _productService;
	private readonly Responsive _responsive;
	private readonly StockManagementUc _stockManagementUc;
	private readonly OrderManagementUc _orderManagementUc;

	public ShopWorkerForm(
		Form parentForm,
		Person user,
		ICategoryActionable categoryService,
		IProductActionable productService,
		IInventoryActionable inventoryService,
		IOrderActionable orderService,
		IPersonActionable personService,
		ILoggerFactory factory)
	{
		InitializeComponent();
		_responsive = new Responsive(Screen.PrimaryScreen.Bounds);
		_responsive.SetMultiplicationFactor();
		_loggedInWorker = user;
		_categoryService = categoryService;
		_productService = productService;
		_inventoryService = inventoryService;
		_orderService = orderService;
		_personService = personService;
		_logger = factory.CreateLogger<ShopWorkerForm>();
		_orderManagementUc = new OrderManagementUc(_orderService, factory);
		_stockManagementUc = new StockManagementUc(_categoryService, _productService, _inventoryService, _personService, factory);
		tabOrders.Controls.Add(_orderManagementUc);
		_orderManagementUc.Dock = DockStyle.Fill;
		tabStockManagement.Controls.Add(_stockManagementUc);
		_stockManagementUc.Dock = DockStyle.Fill;
		_parentForm = parentForm;
		lblWelcome.Text = $@"Welcome {_loggedInWorker.FirstName}!";
		lblRoleTitle.Text = $@"{_loggedInWorker.Role!.GetType().Name.Humanize(LetterCasing.Title)}";
	}

	private void Logout(CancelEventArgs e)
	{
		var window = MessageBox.Show(
			@"Log Out?", @"Log Out", MessageBoxButtons.OKCancel);

		if (window == DialogResult.OK)
			_parentForm.Show();
		else
			e.Cancel = true;
	}

	private void ShopWorkerForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		Logout(e);
	}

	private void ShopWorkerForm_Load(object sender, EventArgs e)
	{
		Width = _responsive.GetMetrics(Width, "Width");
		Height = _responsive.GetMetrics(Height, "Height");
		Left = Screen.GetBounds(this).Width / 2 - Width / 2;
		Top = Screen.GetBounds(this).Height / 2 - Height / 2 - 30;
		foreach (Control ctl in Controls)
		{
			if (ctl is not PictureBox)
				ctl.Font = new Font("Segoe UI", _responsive.GetMetrics((int)ctl.Font.Size), FontStyle.Regular, GraphicsUnit.Point);
			ctl.Width = _responsive.GetMetrics(ctl.Width, "Width");
			ctl.Height = _responsive.GetMetrics(ctl.Height, "Height");
			ctl.Top = _responsive.GetMetrics(ctl.Top, "Top");
			ctl.Left = _responsive.GetMetrics(ctl.Left, "Left");
		}

		_logger.LogInformation("Shop worker form loaded");
	}
	private void BtnAddProduct_Click(object sender, EventArgs e)
	{
		var addProductForm = new FormFactory.FormFactory().CreateAddProductPopUp();
		addProductForm.TitleText = "Create Product";
		addProductForm.ButtonText = "Add";
		addProductForm.ShowDialog();
		if (addProductForm.DialogResult == DialogResult.OK)
		{
			var product = addProductForm.InventoryProduct;
			try
			{
				if (!product!.Product!.CreateProduct(_productService)) return;
				if (!_stockManagementUc._inventory.AddProduct(product, _inventoryService)) return;
				_stockManagementUc._inventory.GetInventory(_inventoryService);
				_stockManagementUc.FillDgv(_stockManagementUc._inventory.Products.Select(p => new InventoryProductModel(p)).ToList());
				_logger.LogInformation("New product was added to the inventory, values:\n{Name}, {Price}, {Amount}", product.Product.Name, product.Product.Price, product.AvailableAmount);
			}
			catch (DataAccessException con)
			{
				_logger.LogCritical("{PageName} => At product creation: {Error}", Name, con.Message);
				MessageBox.Show(@$"{con.Message}");
			}
			catch (LogicLayerException logic)
			{
				_logger.LogCritical("{PageName} => At product creation: {Error}", Name, logic.Message);
				MessageBox.Show(@$"{logic.Message}");
			}
			catch (Exception ex)
			{
				_logger.LogCritical("{PageName} => At product creation: {Error}", Name, ex.Message);
				MessageBox.Show(@"Something went wrong, please try again later.");
			}
		}
	}

	private void btnViewOrders_Click(object sender, EventArgs e)
	{
		tbcStockManagement.SelectedTab = tabOrders;
	}
	private void btnStockManagement_Click(object sender, EventArgs e)
	{
		tbcStockManagement.SelectedTab = tabStockManagement;
	}
}