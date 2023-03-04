#region

using System.Data;
using System.Globalization;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using static System.Convert;
using DBNull = System.DBNull;

#endregion

namespace DataAccessLayer.RepositoryClasses;

public class CategoryRepository : ICategoryActionable
{
    private readonly DbQueries _dbQueries;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryRepository" />
    ///     class.
    /// </summary>
    public CategoryRepository(DbQueries dbQueries)
    {
        _dbQueries = dbQueries;
    }

    private string SqlString { get; set; } = null!;
    private Dictionary<string, string?> Parameters { get; } = new();
    private DataSet DataSet { get; set; } = new();

    public bool CreateCategory(Category category, bool isSubCategory = false)
    {
        Clear();
        SqlString = "INSERT INTO rh_category (name, parent_id, isSubCategory) VALUES (@name, @parent_id, @isSubCategory)";
        Parameters.Add("@name", category.Name);
        Parameters.Add("@parent_id", category.ParentCategory == null ? DBNull.Value.ToString(CultureInfo.CurrentCulture) : category.ParentCategory.Id.ToString());
        Parameters.Add("@isSubCategory", isSubCategory ? "1" : "0");
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool UpdateCategoryName(Category category)
    {
        Clear();
        SqlString = "UPDATE rh_category SET name = @name WHERE id = @id";
        Parameters.Add("@name", category.Name);
        Parameters.Add("@id", category.Id.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    public bool DeleteCategory(Category category)
    {
        Clear();
        SqlString = "DELETE FROM rh_category WHERE id = @id";
        Parameters.Add("@id", category.Id.ToString());
        return _dbQueries.InsertUpdateDelete(SqlString, Parameters);
    }

    /// <summary>Retrieve a list of all categories from the database.</summary>
    /// <returns>A list of categories.</returns>
    public List<Category> GetCategories()
    {
        List<Category> categories = new();
        Clear();
        SqlString = "SELECT c.id, c.name, ca.id sub_id, ca.name sub_name " +
                    "FROM rh_category c " +
                    "INNER JOIN rh_category ca " +
                    "ON c.id = ca.parent_id " +
                    "WHERE c.isSubCategory = 0";
        DataSet = _dbQueries.Select(SqlString, Parameters);
        for (var i = 0; i < DataSet.Tables[0].Rows.Count; i++)
        {
            var row = DataSet.Tables[0].Rows[i];
            if (categories.Any(c => c.Id == (int)row["id"])) continue;
            var parentCategory = new Category((int)row["id"], (string)row["name"]);

            for (var j = 0; j < DataSet.Tables[0].Rows.Count; j++)
            {
                row = DataSet.Tables[0].Rows[j];
                if (parentCategory.Id != (int)row["id"]) continue;
                var subCategory = new Category((int)row["sub_id"], (string)row["sub_name"], parentCategory);
                parentCategory.AddSubCategory(subCategory);
            }

            categories.Add(parentCategory);
        }

        return categories;
    }

    /// <summary>Retrieves a category from the database.</summary>
    /// <param name="category">The category which will be retrieved.</param>
    /// <returns>A category object.</returns>
    public Category GetCategory(Category category)
    {
        Clear();
        SqlString = "SELECT c.id, c.name, ca.id sub_id, ca.name sub_name, c.isSubCategory, " +
                    "rca.id parent_id, rca.name parent_name " +
                    "FROM rh_category c " +
                    "LEFT JOIN rh_category ca ON c.id = ca.parent_id " +
                    "LEFT JOIN rh_category rca ON rca.id = c.parent_id " +
                    "WHERE c.id = @category_id";
        Parameters.Add("@category_id", category.Id.ToString());
        DataSet = _dbQueries.Select(SqlString, Parameters);
        var row = DataSet.Tables[0].Rows[0];
        var returnedCategory = new Category((int)row["id"], (string)row["name"]);
        if (!IsDBNull(row["sub_id"]))
            for (var i = 0; i < DataSet.Tables[0].Rows.Count; i++)
            {
                row = DataSet.Tables[0].Rows[i];
                var subCategory = new Category((int)row["sub_id"], (string)row["sub_name"], returnedCategory);
                returnedCategory.AddSubCategory(subCategory);
            }
        else
            returnedCategory = new Category((int)row["id"], (string)row["name"], new Category((int)row["parent_id"], (string)row["parent_name"]));

        return returnedCategory;
    }


    private void Clear()
    {
        Parameters.Clear();
        DataSet.Clear();
        SqlString = string.Empty;
    }
}