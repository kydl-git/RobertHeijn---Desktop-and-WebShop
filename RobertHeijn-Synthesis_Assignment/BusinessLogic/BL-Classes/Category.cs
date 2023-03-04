#region

using System.ComponentModel;
using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace BusinessLogic.BL_Classes;

public sealed class Category
{
    public Category(int? id, string name, Category? parentCategory = null)
    {
        Id = id;
        Name = name;
        ParentCategory = parentCategory;
        if (parentCategory == null)
            SubCategories = new List<Category>();
    }

    public Category(string name, Category? parentCategory = null)
    {
        Name = name;
        ParentCategory = parentCategory;
        if (parentCategory == null)
            SubCategories = new List<Category>();
    }

    public Category()
    {
    }
    public int? Id { get; }
    public string Name { get; }

    [Browsable(false)] public Category? ParentCategory { get; private set; }

    [DisplayName("ParentCategoryName")] public string ParentCategoryName => ParentCategory!.Name;

    public List<Category>? SubCategories { get; }

    public bool AddSubCategory(Category subCategory)
    {
        if (ParentCategory == null && !SubCategories!.Contains(subCategory))
            SubCategories!.Add(subCategory);
        return SubCategories!.Contains(subCategory);
    }

    /// <summary>
    ///     Creates a new category or subcategory in the database
    /// </summary>
    /// <param name="categoryService">The service on which the method will be called</param>
    /// <param name="isSubCategory">
    ///     Set to true if a subcategory is created, by default
    ///     is false.
    /// </param>
    /// <returns>A boolean about the completion of the action.</returns>
    public bool CreateCategory(ICategoryActionable categoryService, bool isSubCategory = false)
    {
        return categoryService.CreateCategory(this, isSubCategory);
    }

    /// <summary>
    ///     Update the selected category or subcategory in the database
    /// </summary>
    /// <param name="categoryService">The service on which the method will be called</param>
    /// <returns>A boolean about the completion of the action.</returns>
    public bool UpdateCategoryName(ICategoryActionable categoryService)
    {
        return categoryService.UpdateCategoryName(this);
    }

    /// <summary>
    ///     Delete the selected category or subcategory in the database
    /// </summary>
    /// <param name="categoryService">The service on which the method will be called</param>
    /// <returns>A boolean about the completion of the action.</returns>
    public bool DeleteCategory(ICategoryActionable categoryService)
    {
        return categoryService.DeleteCategory(this);
    }

    /// <summary>
    ///     Call this method to get the category object from the database
    /// </summary>
    /// <param name="categoryService">The service on which the method will be called</param>
    /// <returns>The category object</returns>
    public Category GetCategory(ICategoryActionable categoryService)
    {
        return categoryService.GetCategory(this);
    }
}