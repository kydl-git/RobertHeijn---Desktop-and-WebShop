#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Exceptions;

#endregion

namespace BusinessLogic.BL_Managers;

public class Inventory
{
    public Inventory()
    {
        ProductsList = new List<InventoryProduct>();
    }


    private List<InventoryProduct> ProductsList { get; set; }
    public IReadOnlyList<InventoryProduct> Products => ProductsList.AsReadOnly();

    public void GetInventory(IInventoryActionable service)
    {
        ProductsList = service.GetInventory();
    }

    public bool AddProduct(InventoryProduct product, IInventoryActionable service)
    {
        if (ProductsList.Contains(product))
            throw new ObjectDuplicateException("This product already exists in inventory");
        if (service.AddItemToInventory(product))
            ProductsList.Add(product);
        return true;
    }

    public bool RemoveProduct(InventoryProduct product, IInventoryActionable service)
    {
        if (!ProductsList.Contains(product))
            throw new ProductNotAvailableException("This product does not exist in inventory");
        if (service.RemoveItemFromInventory(product))
            ProductsList.Remove(product);
        return true;
    }
}