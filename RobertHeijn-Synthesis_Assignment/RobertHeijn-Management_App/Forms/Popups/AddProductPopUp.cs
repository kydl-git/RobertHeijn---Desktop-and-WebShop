using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Enums;
using Humanizer;
using Microsoft.Extensions.Logging;
using RobertHeijn_Management_App.Behaviours;
using RobertHeijn_Management_App.UI_Validation;
using System.Globalization;
using static System.Windows.Forms.Screen;

namespace RobertHeijn_Management_App.Forms.Popups;
public partial class AddProductPopUp : Form
{

	private readonly Responsive _responsive;
	private readonly ICategoryActionable _categoryService;
	private readonly IProductActionable _productService;
	private readonly ILogger<AddProductPopUp> _logger;
	private readonly IInventoryActionable _inventoryService;
	public string TitleText;
	public string ButtonText;
	public InventoryProduct? InventoryProduct;
	private List<Category> categories = new();
	public AddProductPopUp(ICategoryActionable categoryService, IProductActionable productService, IInventoryActionable inventoryService, ILogger<AddProductPopUp> logger)
	{
		InitializeComponent();
		tbProductName.Focus();
		cbxEditPrice.Visible = false;
		cbxEditQuantity.Visible = false;
		_responsive = new Responsive(PrimaryScreen.Bounds);
		_responsive.SetMultiplicationFactor();
		_categoryService = categoryService;
		_productService = productService;
		_inventoryService = inventoryService;
		_logger = logger;
		categories = _categoryService.GetCategories();
		FillCategoryCmb();
		FillUnitCmb();
	}

	private void AddProductPopUp_Load(object sender, EventArgs e)
	{
		Text = TitleText;
		btnOk.Text = ButtonText;
		Width = _responsive.GetMetrics(Width, "Width");
		Height = _responsive.GetMetrics(Height, "Height");
		Left = (GetBounds(this).Width / 2) - (Width / 2);
		Top = (GetBounds(this).Height / 2) - (Height / 2) - 30;
		foreach (Control ctl in Controls)
		{
			if (ctl is not PictureBox)
				ctl.Font = new Font("Segoe UI", _responsive.GetMetrics((int)ctl.Font.Size), FontStyle.Regular, GraphicsUnit.Point);
			if (ctl is not ComboBox)
				ctl.Height = _responsive.GetMetrics(ctl.Height, "Height");
			ctl.Width = _responsive.GetMetrics(ctl.Width, "Width");
			ctl.Top = _responsive.GetMetrics(ctl.Top, "Top");
			ctl.Left = _responsive.GetMetrics(ctl.Left, "Left");
		}
		if (ButtonText != "Edit") return;
		PopulateFields();
		tbProductName.Enabled = false;
		cmbProductCategory.Enabled = false;
		cmbProductSubCategory.Enabled = false;
		nudProductQuantity.Enabled = false;
		cmbUnit.Enabled = false;
		nudProductPrice.Enabled = false;
		nudAvailableAmount.Focus();
		cbxEditPrice.Visible = true;
		cbxEditQuantity.Visible = true;
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		var quantity = (int)nudProductQuantity.Value;
		if (ButtonText == "Add" || cbxEditQuantity.Checked)
		{
			if (!quantity.CheckNotDefault(lblProductQuantityError))
			{
				cbxEditQuantity.Checked = false;
				return;
			}
		}
		var amount = (int)nudAvailableAmount.Value;
		if (!amount.CheckNotDefault(lblProductAmountError)) return;
		var price = nudProductPrice.Value;
		if (ButtonText == "Add" || cbxEditPrice.Checked)
		{
			if (!price.CheckNotDefault(lblProductPriceError))
			{
				cbxEditPrice.Checked = false;
				return;
			}
		}
		if (ButtonText == "Edit")
		{
			switch (MessageBox.Show(@$"Are you sure that you want to edit product {InventoryProduct!.Product!.Name}?", @"Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				case DialogResult.Yes:
					if (cbxEditPrice.Checked)
					{
						InventoryProduct.Product.UpdateProductPrice(_productService, price);
					}
					if (cbxEditQuantity.Checked)
					{
						InventoryProduct.Product.UpdateProductQuantity(_productService, quantity);
					}
					InventoryProduct.UpdateAvailableAmount(_inventoryService, amount);
					_logger.LogInformation("{PageName} => Product edited: {Name} => Price: {Price}; Quantity {}, Amount {}", Name, InventoryProduct.Product.Name, InventoryProduct.Product.Price.ToString(CultureInfo.InvariantCulture), InventoryProduct.Product.Quantity!.Value.ToString(), InventoryProduct.AvailableAmount.ToString());
					DialogResult = DialogResult.OK;
					Close();
					break;
				case DialogResult.No:
					DialogResult = DialogResult.Cancel;
					Close();
					break;
			}
		}
		var name = tbProductName.Text;
		if (ButtonText != "Edit")
		{
			if (!name.ValidateNotNullOrEmpty(lblProductNameError)) return;
			if (cmbProductCategory.SelectedIndex == 0) return;
			var category = ((KeyValuePair<string, Category>)cmbProductCategory.SelectedItem).Value;
			if (cmbProductSubCategory.SelectedIndex == 0) return;
			var subCategory = ((KeyValuePair<string, Category>)cmbProductSubCategory.SelectedItem).Value;
			if (cmbUnit.SelectedIndex == 0) return;
			var unit = ((KeyValuePair<string, QuantityUnit>)cmbUnit.SelectedItem).Value;
		}
		var product = new Product(tbProductName.Text, price, ((KeyValuePair<string, Category>)cmbProductSubCategory.SelectedItem).Value, new Quantity(quantity, ((KeyValuePair<string, QuantityUnit>)cmbUnit.SelectedItem).Value));
		InventoryProduct = new InventoryProduct(product, amount);
		DialogResult = DialogResult.OK;
		Close();
	}
	

	private void PopulateFields()
	{
		tbProductName.Text = InventoryProduct!.Product!.Name;
		cmbProductCategory.SelectedIndex = categories.FindIndex(x => x.Name == InventoryProduct!.Product!.SubCategory!.ParentCategory!.Name) + 1;
		cmbProductSubCategory.SelectedIndex = categories.First(c => c.Name == InventoryProduct!.Product!.SubCategory!.ParentCategory!.Name).SubCategories!.FindIndex(x => x.Name == InventoryProduct!.Product!.SubCategory!.Name) + 1;
		nudProductPrice.Text = InventoryProduct!.Product!.Price.ToString(CultureInfo.CurrentCulture);
		cmbUnit.SelectedIndex = (int)InventoryProduct!.Product!.Quantity!.Unit;
		nudAvailableAmount.Text = InventoryProduct!.AvailableAmount.ToString();
		nudProductQuantity.Text = InventoryProduct!.Product!.Quantity!.Value.ToString();
	}

	private void cmbProductCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		ResetSubCategoryCmb();
		if (cmbProductCategory.SelectedIndex == 0) return;
		foreach (var kv in categories.First(category => category.Name == ((KeyValuePair<string, Category>)cmbProductCategory.SelectedItem).Value.Name).SubCategories!.ToLookup(subCateg => subCateg.Name).ToDictionary(grouping => grouping.Key.Humanize(LetterCasing.Title), subcategories => subcategories.First(subcategory => subcategory.Name == subcategories.Key)))
			cmbProductSubCategory.Items.Add(kv);
		cmbProductSubCategory.Enabled = true;
	}

	private void FillCategoryCmb()
	{
		cmbProductCategory.Items.Clear();
		cmbProductCategory.Items.Insert(0, "Select a category");
		foreach (var kv in categories.ToLookup(c => c.Name).ToDictionary(c => c.Key.Humanize(LetterCasing.Title), cat => cat.First(x => x.Name == cat.Key)))
			cmbProductCategory.Items.Add(kv);
		cmbProductCategory.SelectedIndex = 0;
		cmbProductCategory.DisplayMember = "Key";
		cmbProductCategory.ValueMember = "Value";
	}
	private void FillUnitCmb()
	{
		cmbUnit.Items.Clear();
		cmbUnit.Items.Insert(0, "Unit");
		foreach (var kv in (from QuantityUnit unit in Enum.GetValues(typeof(QuantityUnit)) select new KeyValuePair<string, QuantityUnit>(unit.Humanize(LetterCasing.Title), unit)).ToDictionary(x => x.Key, x => x.Value))
			cmbUnit.Items.Add(kv);
		cmbUnit.SelectedIndex = 0;
		cmbUnit.DisplayMember = "Key";
		cmbUnit.ValueMember = "Value";
	}

	private void ResetSubCategoryCmb()
	{
		cmbProductSubCategory.Items.Clear();
		cmbProductSubCategory.Items.Insert(0, "First select a category");
		cmbProductSubCategory.SelectedIndex = 0;
		cmbProductSubCategory.Enabled = false;
		cmbProductSubCategory.DisplayMember = "Key";
		cmbProductSubCategory.ValueMember = "Value";
	}

	private void cbxEditQuantity_CheckedChanged(object sender, EventArgs e)
	{
		nudProductQuantity.Enabled = cbxEditQuantity.Checked;
		if (cbxEditQuantity.Checked)
			nudProductQuantity.Focus();
		if (nudProductQuantity.Value == default(decimal))
			nudProductQuantity.Value = InventoryProduct!.Product!.Quantity!.Value;
	}

	private void cbxEditPrice_CheckedChanged(object sender, EventArgs e)
	{
		nudProductPrice.Enabled = cbxEditPrice.Checked;
		if (cbxEditPrice.Checked)
			nudProductPrice.Focus();
		if (nudProductPrice.Value == default(decimal))
			nudProductPrice.Value = InventoryProduct!.Product!.Price;
	}
}
