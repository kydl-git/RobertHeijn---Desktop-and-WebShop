#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace BusinessLogic.Services;

public sealed class CategoryService : ICategoryActionable
{
    private readonly ICategoryActionable _categoryRepository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryService" />
    ///     class.
    /// </summary>
    public CategoryService(ICategoryActionable categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    /// <summary>Creates a new category or subcategory in the database.</summary>
    /// <param name="category">The category which will be created.</param>
    /// <param name="isSubCategory">
    ///     Set to true if a subcategory is created, by default
    ///     is false.
    /// </param>
    /// <returns>A boolean about the completion of the action.</returns>
    public bool CreateCategory(Category category, bool isSubCategory = false)
    {
        return _categoryRepository.CreateCategory(category, isSubCategory);
    }

    /// <summary>Updates the selected category or subcategory in the database.</summary>
    /// <param name="category">The category which will be updated.</param>
    /// <returns>A boolean about the completion of the action.</returns>
    public bool UpdateCategoryName(Category category)
    {
        return _categoryRepository.UpdateCategoryName(category);
    }

    /// <summary>Deletes the selected category or subcategory in the database.</summary>
    /// <param name="category">The category which will be deleted.</param>
    /// <returns>A boolean about the completion of the action.</returns>
    public bool DeleteCategory(Category category)
    {
        return _categoryRepository.DeleteCategory(category);
    }

    /// <summary>Retrieve a list of all categories from the database.</summary>
    /// <returns>A list of categories.</returns>
    public List<Category> GetCategories()
    {
        return _categoryRepository.GetCategories();
    }

    /// <summary>Retrieves a category from the database.</summary>
    /// <param name="category">The category which will be retrieved.</param>
    /// <returns>A category object.</returns>
    public Category GetCategory(Category category)
    {
        return _categoryRepository.GetCategory(category);
    }
}