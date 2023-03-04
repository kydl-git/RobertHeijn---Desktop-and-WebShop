#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Exceptions;
using BusinessLogic.BL_Managers;
using BusinessLogic.Data_Exceptions;
using Humanizer;
using Microsoft.Extensions.Logging;
using RobertHeijn_Management_App.Models;
using System.ComponentModel;

#endregion

namespace RobertHeijn_Management_App.Controls.ShopUserControls;

public partial class StockManagementUc : UserControl
{
	private readonly ICategoryActionable _categoryService;
	private readonly IInventoryActionable _inventoryService;
	private readonly ILogger<StockManagementUc> _logger;
	private readonly IPersonActionable _personService;
	private readonly IProductActionable _productService;
	private InventoryProduct? _product = new();
	public Inventory _inventory = new();

	private List<InventoryProductModel> _listOfProducts = new();

	public StockManagementUc(ICategoryActionable categoryService, IProductActionable productService, IInventoryActionable inventoryService, IPersonActionable personService, ILoggerFactory factory)
	{
		_categoryService = categoryService;
		_productService = productService;
		_inventoryService = inventoryService;
		_personService = personService;
		_logger = factory.CreateLogger<StockManagementUc>();
		InitializeComponent();
		nudMaxPrice.Enabled = false;
		nudMinPrice.Enabled = false;
		FillComboBoxes();
		try
		{
			_inventory.GetInventory(_inventoryService);
			_listOfProducts = _inventory.Products.Select(x => new InventoryProductModel(x)).ToList();
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

		FillDgv(_listOfProducts);
	}

	public void FillDgv(List<InventoryProductModel> products)
	{
		List<DgvProductModel> dgvModelList;
		if (products.Count == 0)
		{
			_inventory.GetInventory(_inventoryService);
			dgvModelList = _inventory.Products.Select(x => new InventoryProductModel(x)).Select(x => new DgvProductModel(x)).ToList();
		}
		else
		{
			dgvModelList = products.Select(x => new DgvProductModel(x)).ToList();
		}
		dgvProductsList.DataSource = null;
		dgvProductsList.DataBindings.Clear();
		var bindingList = new BindingList<DgvProductModel>(dgvModelList);
		var bindingSource = new BindingSource(bindingList, null);
		dgvProductsList.DataSource = bindingSource;
		RemoveColumns();
		GenerateColumns();
	}

	private void GenerateColumns()
	{
		var idColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "ProductId",
			Name = "Product Id",
			HeaderText = @"Id",
			ReadOnly = true
		};
		var nameColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "ProductName",
			Name = "Product Name",
			HeaderText = @"Name",
			ReadOnly = true
		};
		var priceColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "Price",
			Name = "Product Price",
			HeaderText = @"Price(€)",
			ReadOnly = true
		};
		var categoryColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "Category",
			Name = "Product Category",
			HeaderText = @"Category",
			ReadOnly = true
		};
		var subCategoryColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "SubCategory",
			Name = "Product Sub-category",
			HeaderText = @"Sub-category",
			ReadOnly = true
		};
		var quantityColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "Unit",
			Name = "Quantity",
			HeaderText = @"Unit",
			ReadOnly = true
		};
		var availableAmountColumn = new DataGridViewTextBoxColumn
		{
			DataPropertyName = "Amount",
			Name = "Available Amount",
			HeaderText = @"Available Amount",
			ReadOnly = true
		};
		dgvProductsList.Columns.Add(idColumn);
		dgvProductsList.Columns.Add(nameColumn);
		dgvProductsList.Columns.Add(priceColumn);
		dgvProductsList.Columns.Add(categoryColumn);
		dgvProductsList.Columns.Add(subCategoryColumn);
		dgvProductsList.Columns.Add(quantityColumn);
		dgvProductsList.Columns.Add(availableAmountColumn);
	}

	private void RemoveColumns()
	{
		for (var i = dgvProductsList.Columns.Count - 1; i >= 0; i--)
			dgvProductsList.Columns.RemoveAt(i);
	}

	private void DgvProductsList_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0)
			_product = GetProduct((int)dgvProductsList[0, e.RowIndex].Value);
	}

	private void dgvProductsList_DataBindingComplete(object sender, EventArgs e)
	{
		dgvProductsList.ClearSelection();
	}

	private InventoryProduct GetProduct(int productId)
	{
		var product = new InventoryProduct();
		try
		{
			_inventory.GetInventory(_inventoryService);
			product = _inventory.Products.First(p => p.Product!.Id == productId);
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

		return product!;
	}

	private void BtnSearch_Click(object sender, EventArgs e)
	{
		var category = new Category();
		var subCategory = new Category();
		var minPrice = 0M;
		var maxPrice = 0M;
		if (cmbCategoryName.SelectedIndex > 0)
			category = ((KeyValuePair<string, Category>)cmbCategoryName.SelectedItem).Value;
		if (cmbSubCategoryName.SelectedIndex > 0)
			subCategory = ((KeyValuePair<string, Category>)cmbSubCategoryName.SelectedItem).Value;
		if (cbxMinPrice.Checked && nudMinPrice.Value > 0)
			minPrice = nudMinPrice.Value;
		if (cbxMaxPrice.Checked && nudMaxPrice.Value > 0)
			maxPrice = nudMaxPrice.Value;
		_listOfProducts.Clear();
		try
		{
			_listOfProducts = _inventoryService.FilterInventory(category.Name, subCategory.Name, minPrice, maxPrice, cbxHighestPrice.Checked).Select(x => new InventoryProductModel(x)).ToList();
		}
		catch (NoDataFoundException ndf)
		{
			_logger.LogError("{PageName} => \n{Error}, parameters: {Category}, {Subcategory},{MinPrice},{MaxPrice},{Highest}", Name, ndf.Message, category.Name, subCategory.Name, minPrice, maxPrice, cbxHighestPrice.Checked);
			MessageBox.Show(ndf.Message);
		}
		catch (Exception ex)
		{
			_logger.LogCritical("{PageName} => \n{Error}", Name, ex.Message);
			MessageBox.Show(@"Something went wrong");
		}
		finally
		{
			FillDgv(_listOfProducts);
		}
	}

	private void FillComboBoxes()
	{
		cmbCategoryName.Enabled = false;
		cmbSubCategoryName.Enabled = false;
		cmbCategoryName.Items.Clear();
		cmbSubCategoryName.Items.Clear();
		cmbCategoryName.Items.Insert(0, "Check to select");
		cmbSubCategoryName.Items.Insert(0, "Check to select");
		var categories = new List<Category>();
		try
		{
			categories = _categoryService.GetCategories();
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

		foreach (var kv in categories.ToLookup(c => c.Name)
					 .ToDictionary(c => c.Key.Humanize(LetterCasing.Title),
						 cat => cat.First(x => x.Name == cat.Key)))
			cmbCategoryName.Items.Add(kv);
		foreach (var kv in categories.SelectMany(c => c.SubCategories!)
					 .ToLookup(subCateg => subCateg.Name).ToDictionary(grouping => grouping.Key.Humanize(LetterCasing.Title),
						 sub => sub.First(c => c.Name == sub.Key)))
			cmbSubCategoryName.Items.Add(kv);

		cmbCategoryName.SelectedIndex = 0;
		cmbSubCategoryName.SelectedIndex = 0;
		cmbCategoryName.DisplayMember = "Key";
		cmbCategoryName.ValueMember = "Value";
		cmbSubCategoryName.DisplayMember = "Key";
		cmbSubCategoryName.ValueMember = "Value";
	}

	private void CbxCategoryName_CheckedChanged(object sender, EventArgs e)
	{
		cmbCategoryName.Enabled = cbxCategoryName.Checked;
		if (!cmbCategoryName.Enabled)
			cmbCategoryName.SelectedIndex = 0;
	}

	private void CbxSubCategoryName_CheckedChanged(object sender, EventArgs e)
	{
		cmbSubCategoryName.Enabled = cbxSubCategoryName.Checked;
		if (!cmbSubCategoryName.Enabled)
			cmbSubCategoryName.SelectedIndex = 0;
	}

	private void CbxMaxPrice_CheckedChanged(object sender, EventArgs e)
	{
		nudMaxPrice.Enabled = cbxMaxPrice.Checked;
	}

	private void CbxMinPrice_CheckedChanged(object sender, EventArgs e)
	{
		nudMinPrice.Enabled = cbxMinPrice.Checked;
	}

	private void BtnRemoveProduct_Click(object sender, EventArgs e)
	{
		try
		{
			if (_product != null && dgvProductsList.SelectedCells.Count > 0 && dgvProductsList.CurrentCell != null)
			{
				switch (MessageBox.Show(@$"Are you sure that you want to set available amount to 0 for {_product!.Product!.Name}?", @"Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						if(_product.UpdateAvailableAmount(_inventoryService, 0))
							MessageBox.Show(@"Product available amount was set to 0!");
						break;
					case DialogResult.No:
						break;
				}
			}
			else
			{
				MessageBox.Show(@"Select a product!");
			}
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
		finally
		{
			FillDgv(new List<InventoryProductModel>());
		}
	}
	private void BtnEditProduct_Click(object sender, EventArgs e)
	{
		try
		{
			if (_product != null && dgvProductsList.SelectedCells.Count > 0 && dgvProductsList.CurrentCell != null)
			{
				var addProductForm = new FormFactory.FormFactory().CreateAddProductPopUp();
				addProductForm.TitleText = "Edit Product";
				addProductForm.ButtonText = "Edit";
				addProductForm.InventoryProduct = _product;
				addProductForm.ShowDialog();
				if (addProductForm.DialogResult == DialogResult.OK)
					MessageBox.Show(@"Product edited successfully");
			}
			else
			{
				MessageBox.Show(@"Select a row to edit!");
			}
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
		finally
		{
			FillDgv(new List<InventoryProductModel>());
		}
	}
}