#region

using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace BusinessLogic.BL_Classes;

public sealed class Address : IEquatable<Address>
{
	public Address(int id, string street, string streetNumber, string zipCode, string city)
	{
		Id = id;
		Street = street;
		StreetNumber = streetNumber;
		ZipCode = zipCode;
		City = city;
	}

	public Address(string street, string streetNumber, string zipCode, string city)
	{
		Street = street;
		StreetNumber = streetNumber;
		ZipCode = zipCode;
		City = city;
	}

	public int Id { get; }
	public string Street { get; }
	public string StreetNumber { get; }
	public string ZipCode { get; }
	public string City { get; }

	public bool Equals(Address? other)
	{
		if (ReferenceEquals(null, other)) return false;
		if (ReferenceEquals(this, other)) return true;
		return Street == other.Street && StreetNumber == other.StreetNumber && ZipCode == other.ZipCode && City == other.City;
	}

	public bool CreatePickUpAddress(IAddressActionable addressService)
	{
		return addressService.CreatePickUpAddress(this);
	}

	public bool UpdateAddress(IAddressActionable addressService)
	{
		return addressService.UpdateAddress(this);
	}

	public bool DeleteAddress(IAddressActionable addressService)
	{
		return addressService.DeleteAddress(this);
	}

	public static bool operator ==(Address? left, Address? right)
	{
		return left!.Equals(right);
	}

	public static bool operator !=(Address? left, Address? right)
	{
		return !(left == right);
	}
}