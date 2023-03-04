using BusinessLogic.BL_Classes;
using Xunit;
using FluentAssertions;

namespace TestProject.Entities;

public class CredentialsTest
{
	[Theory]
	[InlineData("testEmail","test", "test")]
	[InlineData("applesEmail","apples", "apples")]
	[InlineData("orangesEmail","oranges", "oranges")]
	public void TestCredentials_When_Given_ValidInput(string? email, string? password, string? confirmPassword)
	{   
		//Arrange & Act
		var credentials = new Credentials(email, password, true);
		//Assert
		credentials.ComparePassword(confirmPassword).Should().BeTrue();
	}
	[Theory]
	[InlineData("testEmail","test", "apples")]
	[InlineData("applesEmail","apples", "oranges")]
	[InlineData("orangesEmail","oranges", "apples")]
	public void TestCredentials_When_Given_InValidInput(string? email, string? password, string? confirmPassword)
	{   
		//Arrange & Act
		var credentials = new Credentials(email, password, true);
		//Assert
		credentials.ComparePassword(confirmPassword).Should().BeFalse();
	}
	
}