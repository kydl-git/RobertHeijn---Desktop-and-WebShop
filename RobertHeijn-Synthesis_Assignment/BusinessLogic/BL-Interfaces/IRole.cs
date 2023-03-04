#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace BusinessLogic.BL_Interfaces;

public interface IRole
{
    int? RoleId { get; }
    Address? ShopAddress { get; }
    bool SetShopAddress(Address? address, IAddressActionable addressService);
    Address GetShopAddress(IAddressActionable addressService);
}