#region

using BusinessLogic.BL_DaL_Interfaces;
using Scrypt;

#endregion

namespace BusinessLogic.BL_Classes;

public sealed class Credentials
{
    private readonly ScryptEncoder _scryptEncoder = new();

    public Credentials()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="T:BusinessLogic.BL_Classes.Credentials" /> class.
    /// </summary>
    /// <param name="email">User email address.</param>
    /// <param name="password">
    ///     At account creation, password is the written password,
    ///     otherwise it is the hashed password from database.
    /// </param>
    /// <param name="isNew">
    ///     <see langword="true" /> at account creation, otherwise is
    ///     <see langword="false" /> by default
    /// </param>
    public Credentials(string? email, string? password, bool isNew = false)
    {
        Email = email;
        Password = isNew ? Encrypt(password) : password;
    }

    public string? Email { get; private set; }
    public string? Password { get; private set; }

    public bool Create(ICredentialsActionable credentialsService, bool isCustomer = true)
    {
        return credentialsService.Create(this, isCustomer);
    }

    public bool UpdatePassword(ICredentialsActionable credentialsService, string? oldPassword, string? newPassword)
    {
        if (!ComparePassword(oldPassword)) return false;
        if (credentialsService.UpdatePassword(this, Encrypt(newPassword)))
            Password = Encrypt(newPassword);
        return ComparePassword(newPassword);
    }

    public bool UpdateEmail(ICredentialsActionable credentialsService, string? newEmail)
    {
	    if(credentialsService.UpdateEmail(this, newEmail))
		    Email = newEmail;
	    return Email == newEmail;
    }

    public Credentials? Login(ICredentialsActionable credentialsService)
    {
        var user = credentialsService.ReadCredentials(Email);
        return user.ComparePassword(Password) ? user : null;
    }

    public bool ComparePassword(string? writtenPassword)
    {
        return _scryptEncoder.Compare(writtenPassword, Password);
    }

    private string? Encrypt(string? password)
    {
        return _scryptEncoder.Encode(password);
    }

    public Credentials ReadCredentialsByEmail(ICredentialsActionable credentialsService, string? email)
    {
        return credentialsService.ReadCredentials(email);
    }
}