#region

using BusinessLogic.BL_Classes;

#endregion

namespace RobertHeijn_Web_App.Models.Inventory;

public class InventoryItemViewModel
{
    public int Id { get; set; }
    public ProductViewModel Product { get; set; }
    public int AvailableAmount { get; set; }

    public InventoryItemViewModel Map(InventoryProduct inventoryProduct)
    {
        Id = inventoryProduct.Id;
        Product = ProductViewModel.Map(inventoryProduct.Product!);
        AvailableAmount = inventoryProduct.AvailableAmount;
        return this;
    }

    public InventoryProduct Map()
    {
        return new InventoryProduct(
            Product.MapToProduct(),
            AvailableAmount,
            Id);
    }
}