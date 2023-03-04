#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Interfaces;

#endregion

namespace BusinessLogic.Services;

public sealed class AddressService : IAddressActionable
{
    private readonly IAddressActionable _addressRepository;

    /// <summary>Initializes a new instance of the <see cref="AddressService" /> class.</summary>
    public AddressService(IAddressActionable addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public bool CreatePickUpAddress(Address address)
    {
        return _addressRepository.CreatePickUpAddress(address);
    }

    public bool UpdateAddress(Address address)
    {
        return _addressRepository.UpdateAddress(address);
    }

    public bool DeleteAddress(Address address)
    {
        return _addressRepository.DeleteAddress(address);
    }


    public List<Address> GetPickUpAddresses()
    {
        return _addressRepository.GetPickUpAddresses();
    }

    public bool SetShopAddress(IRole role, Address? address)
    {
        return _addressRepository.SetShopAddress(role, address);
    }

    public Address GetShopAddress(IRole role)
    {
        return _addressRepository.GetShopAddress(role);
    }
}