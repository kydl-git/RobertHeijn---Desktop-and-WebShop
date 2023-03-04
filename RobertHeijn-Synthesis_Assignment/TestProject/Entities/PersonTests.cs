using BusinessLogic.BL_Classes;
using Xunit;
using FluentAssertions;

namespace TestProject.Entities;

public class PersonTests
{
	[Theory] 
	[InlineData("John", "Doe", "john@test.com", "apples", "phone", 1, 1)]
	[InlineData("Jane", "Doe", "jane@test.com", "oranges", "phone", 2, 3)]
	[InlineData("Jack", "Doe", "jack@test.com", "bananas", "phone", 3, 4)]
	public void PersonTest_Should_Be_Created_Successfully(string fn,string ln, string? em, string? pw, string pn, int id, int roleId)
	{
		//Arrange
		var person = new Person(new Credentials(em, pw),fn, ln, pn, id, new Customer(roleId));

		//Act
		var result = person;

		//Assert
		result.Should().NotBeNull();
		result.FirstName.Should().Be(fn);
		result.LastName.Should().Be(ln);
		result.Credentials.Email.Should().Be(em);
		result.Credentials.Password.Should().Be(pw);
		result.Phone.Should().Be(pn);
		result.Id.Should().Be(id);
		result.Role!.RoleId.Should().Be(roleId);
	}
	[Theory] 
	[InlineData("John", "Doe", "john@test.com", "apples", "phone", 1, 1,3)]
	[InlineData("Jane", "Doe", "jane@test.com", "oranges", "phone", 1, 2, 3)]
	public void PersonTest_Should_Throw_InvalidOperationException_On_SetRole(string fn,string ln, string? em, string? pw, string pn, int id, int roleId, int newRoleId)
	{
		//Arrange
		var person = new Person(new Credentials(em, pw),fn, ln, pn, id, new Customer(roleId));
		//Act
		Action act = () => person.SetRole(new Customer(newRoleId));
		//Assert
		act.Should().Throw<InvalidOperationException>();
	}
}