#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace RobertHeijn_Web_App.Models.Account;

public class LoginInputModel
{
    [Required] [EmailAddress] public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Remember me?")] public bool RememberMe { get; set; }
}