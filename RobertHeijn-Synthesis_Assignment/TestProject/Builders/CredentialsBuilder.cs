using BusinessLogic.BL_Classes;

namespace TestProject.Builders;

public class CredentialsBuilder
{
	private Credentials _credentials;
	public static string? Email => "testEmail@test.com";
	public static string? Password => "testPassword";

	public Credentials WithDefaultValues()
	{
		_credentials = new Credentials(Email, Password);
		return _credentials;
	}

	public CredentialsBuilder()
	{
		_credentials = WithDefaultValues();
	}
}