#region

using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Exceptions;
using BusinessLogic.BL_Interfaces;

#endregion

namespace BusinessLogic.BL_Classes;

public sealed class ShopWorker : IRole
{
    public ShopWorker(Address? workAddress, int? id = null)
    {
        RoleId = id;
        ShopAddress = workAddress;
    }

    public ShopWorker()
    {
    }

    public int? RoleId { get; private set; }
    public Address? ShopAddress { get; private set; }

    public bool SetShopAddress(Address? address, IAddressActionable addressService)
    {
        if (address == null)
            return false;
        if (addressService.SetShopAddress(this, address))
            ShopAddress = address;
        return ShopAddress == address;
    }

    public Address GetShopAddress(IAddressActionable addressService)
    {
        if (ShopAddress == null)
            throw new InvalidValueException("Shop address is not set");
        return addressService.GetShopAddress(this);
    }

    public bool UpdateShopAddress(IRolesActionable rolesService, Address address)
    {
        if (ShopAddress == address)
            throw new ObjectDuplicateException("This address is already set.");
        if (rolesService.UpdateShopAddress(this, address))
            ShopAddress = address;
        return ShopAddress == address;
    }

    public static ShopWorker? Map(IRole role)
    {
        return new ShopWorker
        {
            RoleId = role.RoleId,
            ShopAddress = role.ShopAddress!
        };
    }
}