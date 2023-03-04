using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Enums;
using BusinessLogic.BL_Exceptions;
using BusinessLogic.Data_Exceptions;
using Humanizer;
using Microsoft.Extensions.Logging;

namespace RobertHeijn_Management_App.Forms.Popups;
public partial class ChangeOrderStatus : Form
{
	private readonly ILogger<ChangeOrderStatus> _logger;
	private readonly IOrderActionable _orderService;
	private Order _order;
	public ChangeOrderStatus(Order order, IOrderActionable orderService, ILoggerFactory logger)
	{
		InitializeComponent();
		_order = order;
		_orderService = orderService;
		_logger = logger.CreateLogger<ChangeOrderStatus>();
		FillOrderDetails();
		FillCombobox();
	}

	private void BtnConfirm_Click(object sender, EventArgs e)
	{
		if (cmbStatus.SelectedIndex == 0) return;
		 var status = ((KeyValuePair<string, OrderStatus>)cmbStatus.SelectedItem).Value;
		 try
		 {
			 if (!_order.UpdateStatus(_orderService, status)) return;
			 MessageBox.Show(@$"Status for order {_order.Id} was changed to {status.Humanize(LetterCasing.Title)}", @"Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
			 DialogResult = DialogResult.OK;
			 _logger.LogInformation("Order with id {OrderId} has been updated to status {Humanize}", _order.Id, status.Humanize());
			 Close();
		 }
		 catch (DataAccessException con)
		 {
			 _logger.LogCritical("{PageName} => {Error}", Name, con.Message);
			 MessageBox.Show(@$"{con.Message}");
		 }
		 catch (LogicLayerException logic)
		 {
			 _logger.LogCritical("{PageName} => {Error}", Name, logic.Message);
			 MessageBox.Show(@$"{logic.Message}");
		 }
		 catch (Exception ex)
		 {
			 _logger.LogCritical("{PageName} => At product creation: {Error}", Name, ex.Message);
			 MessageBox.Show(@"Something went wrong, please try again later.");
		 }
	}

	private void FillCombobox()
	{
		cmbStatus.Items.Clear();
		cmbStatus.Items.Insert(0, "Unit");
		foreach (var kv in (from OrderStatus status in Enum.GetValues(typeof(OrderStatus)) select new KeyValuePair<string, OrderStatus>(status.Humanize(LetterCasing.Title), status)).ToDictionary(x => x.Key, x 
		=> x.Value))
			cmbStatus.Items.Add(kv);
		cmbStatus.SelectedIndex = 0;
		cmbStatus.DisplayMember = "Key";
		cmbStatus.ValueMember = "Value";
	}

	private void FillOrderDetails()
	{
		lblOrderIdValue.Text = _order.Id.ToString();
		lblCustomerNameValue.Text = @$"{_order.Customer!.FirstName} {_order.Customer.LastName}";
	}
}


