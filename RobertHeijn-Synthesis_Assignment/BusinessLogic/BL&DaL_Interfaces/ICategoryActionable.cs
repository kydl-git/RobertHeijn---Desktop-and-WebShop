#region

using BusinessLogic.BL_Classes;

#endregion

namespace BusinessLogic.BL_DaL_Interfaces;

public interface ICategoryActionable
{
    /// <summary>Creates a new category or subcategory in the database.</summary>
    /// <param name="category">The category which will be created.</param>
    /// <param name="isSubCategory">
    ///     Set to true if a subcategory is created, by default
    ///     is false.
    /// </param>
    /// <returns>A boolean about the completion of the action.</returns>
    protected internal bool CreateCategory(Category category, bool isSubCategory = false);

    /// <summary>Updates the selected category or subcategory in the database.</summary>
    /// <param name="category">The category which will be updated.</param>
    /// <returns>A boolean about the completion of the action.</returns>
    protected internal bool UpdateCategoryName(Category category);

    /// <summary>Deletes the selected category or subcategory in the database.</summary>
    /// <param name="category">The category which will be deleted.</param>
    /// <returns>A boolean about the completion of the action.</returns>
    protected internal bool DeleteCategory(Category category);

    /// <summary>Retrieve a list of all categories from the database.</summary>
    /// <returns>A list of categories.</returns>
    List<Category> GetCategories();

    /// <summary>Retrieves a category from the database.</summary>
    /// <param name="category">The category which will be retrieved.</param>
    /// <returns>A category object.</returns>
    protected internal Category GetCategory(Category category);
}