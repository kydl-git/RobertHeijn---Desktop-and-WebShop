#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_Interfaces;

#endregion

namespace BusinessLogic.BL_DaL_Interfaces;

public interface IAddressActionable
{
	protected internal bool CreatePickUpAddress(Address address);
	protected internal bool UpdateAddress(Address address);
	protected internal bool DeleteAddress(Address address);
	public List<Address> GetPickUpAddresses();
	protected internal bool SetShopAddress(IRole role, Address? address);
	protected internal Address GetShopAddress(IRole role);
}