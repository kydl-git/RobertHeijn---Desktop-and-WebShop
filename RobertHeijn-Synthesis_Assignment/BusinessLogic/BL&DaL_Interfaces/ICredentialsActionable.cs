#region

using BusinessLogic.BL_Classes;

#endregion

namespace BusinessLogic.BL_DaL_Interfaces;

public interface ICredentialsActionable
{
	protected internal Credentials ReadCredentials(string? email);
	protected internal bool Create(Credentials credentials, bool isCustomer=true);
	protected internal bool UpdateEmail(Credentials credentials, string? newEmail);
	protected internal bool UpdatePassword(Credentials credentials, string? newPassword);
	protected internal bool CheckEmailDuplicate(string? email);
}