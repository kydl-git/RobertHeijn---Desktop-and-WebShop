#region

using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Exceptions;
using BusinessLogic.BL_Interfaces;

#endregion

namespace BusinessLogic.BL_Classes;

public sealed class Customer : IRole
{
    public Customer()
    {
    }

    public Customer(int? roleId = default, Address? preferredPickUpAddress = null)
    {
        RoleId = roleId;
        ShopAddress = preferredPickUpAddress;
    }

    private List<Address> Addresses { get; } = new();
    public IReadOnlyList<Address> GetAddresses => Addresses.AsReadOnly();
    public int? RoleId { get; }
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
            throw new InvalidValueException("Preferred pick-up address is not set");
        return addressService.GetShopAddress(this);
    }

    public bool AddAddress(Address address)
    {
        if (CheckIfAddressIsInList(address))
            return false;
        Addresses.Add(address);
        return true;
    }

    private bool CheckIfAddressIsInList(Address address)
    {
        return Addresses.Contains(address);
    }

    public bool RemoveAddress(Address address, ICustomerActionable service)
    {
        if (!CheckIfAddressIsInList(address)) return false;
        if (service.RemoveHomeDeliveryAddressFromCustomer(this, address))
            Addresses.Remove(address);
        return true;
    }
}