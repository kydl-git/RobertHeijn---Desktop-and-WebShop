#region

using BusinessLogic.BL_DaL_Interfaces;
using EmailValidation;

#endregion

namespace BusinessLogic.BL_Validation;

public class Validator : IValidatable
{
    public bool PhoneNumberValidator(string phoneNumber, string regionCode)
    {
        return PhoneValidation.CheckPhone(phoneNumber.Replace(" ", ""), regionCode);
    }

    public bool ValidateEmail(string? email)
    {
        return EmailValidator.Validate(email);
    }

    public bool CheckEmailDuplicate(ICredentialsActionable credentialsService, string? email)
    {
        return credentialsService.CheckEmailDuplicate(email);
    }
}