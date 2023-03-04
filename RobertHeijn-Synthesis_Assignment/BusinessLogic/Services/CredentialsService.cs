#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace BusinessLogic.Services;

public sealed class CredentialsService : ICredentialsActionable
{
    private readonly ICredentialsActionable _credentialsRepository;

    public CredentialsService(ICredentialsActionable credentialsRepository)
    {
        _credentialsRepository = credentialsRepository;
    }

    public Credentials ReadCredentials(string? email)
    {
        return _credentialsRepository.ReadCredentials(email);
    }

    public bool Create(Credentials credentials, bool isCustomer)
    {
        return _credentialsRepository.Create(credentials, isCustomer);
    }

    public bool UpdateEmail(Credentials credentials, string? newEmail)
    {
	    return _credentialsRepository.UpdateEmail(credentials, newEmail);
    }
    public bool UpdatePassword(Credentials credentials, string? newPassword)
    {
        return _credentialsRepository.UpdatePassword(credentials, newPassword);
    }

    public bool CheckEmailDuplicate(string? email)
    {
        return _credentialsRepository.CheckEmailDuplicate(email);
    }
}