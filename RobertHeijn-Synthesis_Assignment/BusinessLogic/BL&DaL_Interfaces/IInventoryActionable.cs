#region

using BusinessLogic.BL_Classes;

#endregion

namespace BusinessLogic.BL_DaL_Interfaces;

public interface IInventoryActionable
{
	protected internal bool AddItemToInventory(InventoryProduct item);
	protected internal bool RemoveItemFromInventory(InventoryProduct item);
	protected internal bool UpdateItemQuantityInInventory(InventoryProduct item);
	protected internal InventoryProduct GetItemFromInventory(InventoryProduct item);
	protected internal List<InventoryProduct> GetInventory();
	List<InventoryProduct> FilterInventory(string? categoryName = null, string? subcategoryName = null, decimal minPrice = 0, decimal maxPrice = 0, bool getMostExpensive = true);
	protected internal bool IsItemInStock(Product product);
}