#region

using System.ComponentModel.DataAnnotations;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_Enums;

#endregion

namespace RobertHeijn_Web_App.Models.Inventory;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category SubCategory { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be bigger than 0")]
    public int Quantity { get; set; }

    public QuantityUnit QuantityUnit { get; set; }

    public static ProductViewModel Map(Product product)
    {
        return new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name!,
            Price = product.Price,
            SubCategory = product.SubCategory!,
            Quantity = product.Quantity!.Value,
            QuantityUnit = product.Quantity!.Unit
        };
    }

    public Product MapToProduct()
    {
        return new Product(Id,
            Name,
            Price,
            SubCategory,
            new Quantity(Quantity,
                QuantityUnit));
    }
}