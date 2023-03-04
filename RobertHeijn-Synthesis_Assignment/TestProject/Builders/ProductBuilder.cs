using BusinessLogic.BL_Classes;
using BusinessLogic.BL_Enums;

namespace TestProject.Builders;

public class ProductBuilder
{
	private Product _product;
	public const string DefaultName = "DefaultName";
	public const decimal DefaultPrice = 10.0m;
	public Category DefaultCategory = new("DefaultCategory");
	public int Quantity = 1;
	public QuantityUnit Unit = QuantityUnit.Kilogram;

	
	public Product Build(int value)
	{
		_product = new Product($"DefaultName{value}", DefaultPrice + value, DefaultCategory, new Quantity(Quantity + value, Unit));
		return _product;
	}
	public ProductBuilder()
	{
		_product = WithDefaultValues();
	}
	public Product WithDefaultValues()
	{
		_product = new Product(DefaultName, DefaultPrice, DefaultCategory, new Quantity(Quantity, Unit));
		return _product;
	}
	
}