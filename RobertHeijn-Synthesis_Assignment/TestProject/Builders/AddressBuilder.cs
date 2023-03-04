using BusinessLogic.BL_Classes;

namespace TestProject.Builders;

public class AddressBuilder
{
	private  Address _address;
	public const string DefaultStreet = "Default Street";
	public const string DefaultStreetNumber = "34A";
	public const string DefaultCity = "Eindhoven";
	public const string DefaultZipCode = "2451BD";
	public const int DefaultNumber = 1;

	public AddressBuilder()
	{
		_address = WithDefaultValues();
	}
	
	public Address WithDefaultValues()
	{
		_address = new Address(DefaultNumber, DefaultStreet,DefaultStreetNumber, DefaultZipCode, DefaultCity);
		return _address;
	}

}