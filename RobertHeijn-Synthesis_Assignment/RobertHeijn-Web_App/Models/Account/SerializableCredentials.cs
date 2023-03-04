#region

using BusinessLogic.BL_Classes;

#endregion

namespace RobertHeijn_Web_App.Models.Account;

[Serializable]
public class SerializableCredentials
{
    public string? Email { get; set; }
    public string? Password { get; set; }

    public SerializableCredentials Map(Credentials credentials)
    {
        Email = credentials.Email;
        Password = credentials.Password;
        return this;
    }

    public Credentials Map()
    {
        return new Credentials(
            Email,
            Password);
    }
}