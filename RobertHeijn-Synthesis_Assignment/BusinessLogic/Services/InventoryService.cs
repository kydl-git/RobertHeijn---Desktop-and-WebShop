#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace BusinessLogic.Services;

public sealed class InventoryService : IInventoryActionable
{
    private readonly IInventoryActionable _inventoryRepository;

    public InventoryService(IInventoryActionable inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public bool AddItemToInventory(InventoryProduct item)
    {
        return _inventoryRepository.AddItemToInventory(item);
    }

    public bool RemoveItemFromInventory(InventoryProduct item)
    {
        return _inventoryRepository.RemoveItemFromInventory(item);
    }

    public bool UpdateItemQuantityInInventory(InventoryProduct item)
    {
        return _inventoryRepository.UpdateItemQuantityInInventory(item);
    }

    public InventoryProduct GetItemFromInventory(InventoryProduct item)
    {
        return _inventoryRepository.GetItemFromInventory(item);
    }

    public List<InventoryProduct> GetInventory()
    {
        return _inventoryRepository.GetInventory();
    }
    public List<InventoryProduct> FilterInventory(string? categoryName = null, string? subcategoryName = null, decimal minPrice = 0, decimal maxPrice = 0, bool getMostExpensive = true)
    {
        return _inventoryRepository.FilterInventory(categoryName, subcategoryName, minPrice, maxPrice, getMostExpensive);
    }
    public bool IsItemInStock(Product product)
    {
        return _inventoryRepository.IsItemInStock(product);
    }
}