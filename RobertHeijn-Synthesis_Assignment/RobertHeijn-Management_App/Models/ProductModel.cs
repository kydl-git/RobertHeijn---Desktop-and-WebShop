using BusinessLogic.BL_Classes;
using Humanizer;
using System.ComponentModel;

namespace RobertHeijn_Management_App.Models
{
	public class ProductModel
	{
		[DisplayName("Id")]
		public int Id { get; }
		[DisplayName("Product Name")]
		public string? Name { get; }
		[DisplayName("Price (€)")]
		public decimal Price { get; }

		[Browsable(false)] public Category? SubCategory { get; }

		[DisplayName("Sub-category")] public string SubCategoryName => SubCategory!.Name;

		[Browsable(false)] public Quantity? Quantity { get; set; }

		[DisplayName("Unit")] public string Unit => Quantity!.Value == 1 ? $"{Quantity!.Value} {Quantity!.Unit.Humanize(LetterCasing.LowerCase)}" : $"{Quantity!.Value} {Quantity!.Unit.Humanize(LetterCasing.LowerCase)}s";

		[DisplayName("Category")] public string ParentCategoryName => SubCategory!.ParentCategory!.Name;

		public ProductModel(Product product)
		{
			Id = product.Id;
			Name = product.Name;
			Price = product.Price;
			SubCategory = product.SubCategory;
			Quantity = product.Quantity;
		}
		public Product MapProduct()
		{
			return new Product(Id, Name, Price, SubCategory, Quantity);
		}
	}
}
