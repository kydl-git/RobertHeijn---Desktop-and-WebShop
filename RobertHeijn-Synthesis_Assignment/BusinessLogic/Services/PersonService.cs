#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace BusinessLogic.Services;

public sealed class PersonService : IPersonActionable
{
    private readonly IPersonActionable _personRepository;

    /// <summary>Initializes a new instance of the <see cref="PersonService" /> class.</summary>
    public PersonService(IPersonActionable personRepository)
    {
        _personRepository = personRepository;
    }

    public Person GetPerson(string? email)
    {
        return _personRepository.GetPerson(email);
    }

    public List<Person> GetPersons()
    {
        return _personRepository.GetPersons();
    }

    public bool CreatePerson(Person person)
    {
        return _personRepository.CreatePerson(person);
    }

    public bool UpdatePhone(Person person, string phone)
    {
        return _personRepository.UpdatePhone(person, phone);
    }

    public bool DeletePerson(Person person)
    {
        return _personRepository.DeletePerson(person);
    }

    public bool IsPersonAlreadyRegistered(string email)
    {
        return _personRepository.IsPersonAlreadyRegistered(email);
    }
}