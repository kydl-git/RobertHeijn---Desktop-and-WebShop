#region

using BusinessLogic.BL_Classes;

#endregion

namespace BusinessLogic.BL_DaL_Interfaces;

public interface IPersonActionable
{ 
	protected internal Person GetPerson(string? email); 
    List<Person> GetPersons();
    protected internal bool CreatePerson(Person person);
    protected internal bool UpdatePhone(Person person, string phone);
    protected internal bool DeletePerson(Person person);
    bool IsPersonAlreadyRegistered(string email);
}