#region

using BusinessLogic.BL_Classes;

#endregion

namespace BusinessLogic.BL_DaL_Interfaces;

public interface IProductActionable
{
    /// <summary>
    ///     Create a new <see cref="T:BusinessLogic.BL_Classes.Product" /> object.
    /// </summary>
    /// <param name="product">
    ///     The <see cref="T:BusinessLogic.BL_Classes.Product" /> to
    ///     be created in the database
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the specified
    ///     <see cref="T:BusinessLogic.BL_Classes.Product" />
    /// </returns>
    protected internal int CreateProduct(Product product);
    protected internal bool UpdateProductPrice(Product product, decimal newPrice);
    protected internal bool UpdateProductQuantity(Product product, int newQuantityValue);
    List<Product> GetAllProducts();
}