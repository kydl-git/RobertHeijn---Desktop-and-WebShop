#region

using System.ComponentModel.DataAnnotations;
using BusinessLogic.BL_Classes;

#endregion

namespace RobertHeijn_Web_App.Models.Account;

public class PersonViewModel
{
    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }
    
    public PersonViewModel(Person person)
	{
		FirstName = person.FirstName!;
		LastName = person.LastName!;
		PhoneNumber = person.Phone!;
	}
}