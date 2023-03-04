using BusinessLogic.BL_Classes;
using Xunit;
using FluentAssertions;

namespace TestProject.Entities;

public class CategoryTests
{
	[Theory]
	[InlineData("Milk", "Dairy")]
	[InlineData("Vegetables", "Vegetables And Fruits")]
	[InlineData("Fruits", "Vegetables And Fruits")]
	[InlineData("Pork", "Meat")]
	public void CreateCategory_WithValidName_ShouldCreate_Valid_SubCategoryAndParent(string name, string parentName)
	{
		// Arrange
		var category = new Category(parentName);
		var subCategory = new Category(name, category);
		// Act
		category.AddSubCategory(subCategory);
		// Assert
		category.SubCategories.Should().Contain(subCategory); 
		subCategory.ParentCategory.Should().Be(category);
	}
	[Theory]
	[InlineData("Milk", "Dairy", "Yoghurt")]
	[InlineData("Vegetables", "Vegetables And Fruits", "Carrot")]
	[InlineData("Fruits", "Vegetables And Fruits", "Apple")]
	[InlineData("Pork", "Meat", "Bacon")]
	public void CreateSubCategory_ShouldThrowException_When_Adding_Child_Categories(string name, string parentName, string childName)
	{
		//Arrange
		var category = new Category(parentName);
		var subCategory = new Category(name,category);
		var childCategory = new Category(childName);
		// Act & Assert
		Assert.ThrowsAny<NullReferenceException>(() => subCategory.AddSubCategory(childCategory));
	}
}