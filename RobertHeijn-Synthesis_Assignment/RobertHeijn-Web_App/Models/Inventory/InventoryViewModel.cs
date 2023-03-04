#region

using BusinessLogic.BL_Managers;

#endregion

namespace RobertHeijn_Web_App.Models.Inventory;

public class InventoryViewModel
{
    public List<InventoryProductViewModel> InventoryItems { get; set; }
    public string? StatusMessage { get; set; }

    public void Map(BusinessLogic.BL_Managers.Inventory inventory)
    {
	    InventoryItems = inventory.Products.Select(item => new InventoryProductViewModel().Map(new InventoryItemViewModel().Map(item))).ToList();
    }
}