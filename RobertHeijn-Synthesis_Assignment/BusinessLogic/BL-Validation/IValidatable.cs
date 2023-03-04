#region

using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace BusinessLogic.BL_Validation;

public interface IValidatable
{
    bool PhoneNumberValidator(string phoneNumber, string regionCode);
    bool ValidateEmail(string? email);
    bool CheckEmailDuplicate(ICredentialsActionable credentialsService, string? email);
}