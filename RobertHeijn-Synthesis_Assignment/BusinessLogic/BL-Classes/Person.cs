#region

using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Interfaces;

#endregion

namespace BusinessLogic.BL_Classes;

public sealed class Person
{
    public Person()
    {
    }

    public Person(Credentials credentials, string? firstName, string? lastName, string? phone, int? id = null, IRole? role = null)
    {
        Id = id;
        Credentials = credentials;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Role = role;
    }

    public Person(Credentials credentials)
    {
        Credentials = credentials;
    }

    public int? Id { get; }
    public Credentials Credentials { get; }
    public string? FirstName { get; }
    public string? LastName { get; }
    public string? Phone { get; private set; }
    public IRole? Role { get; private set; }

    public void SetRole(IRole role)
    {
        if (Role != null)
            throw new InvalidOperationException("Role is already set");
        Role = role;
    }

    public bool CreatePerson(IPersonActionable personService)
    {
        return personService.CreatePerson(this);
    }

    public Person GetPerson(IPersonActionable personService)
    {
	    return personService.GetPerson(Credentials.Email);
    }
    public bool UpdatePhone(IPersonActionable personService, string phone)
    {
        if(personService.UpdatePhone(this, phone))
	        Phone = phone;
        return Phone == phone;
    }

    public bool DeletePerson(IPersonActionable personService)
    {
        return personService.DeletePerson(this);
    }
}