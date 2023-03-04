using BusinessLogic.BL_Classes;

namespace TestProject.Builders;

public class PersonBuilder
{
	private Person _person;
	public static string FirstName => "testFirstName";
	public static string LastName => "testLastName";
	public static string PhoneNumber => "+31634556317";

	public PersonBuilder()
	{
		_person = WithDefaultValues();
	}

	public Person WithDefaultValues()
	{
		_person = new Person(new CredentialsBuilder().WithDefaultValues(), FirstName, LastName, PhoneNumber);
		return _person;
	}
}