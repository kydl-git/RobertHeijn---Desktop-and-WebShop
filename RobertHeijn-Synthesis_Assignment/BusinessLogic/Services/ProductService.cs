#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;

#endregion

namespace BusinessLogic.Services;

public sealed class ProductService : IProductActionable
{
    private readonly IProductActionable _productRepository;

    public ProductService(IProductActionable productRepository)
    {
        _productRepository = productRepository;
    }

    public int CreateProduct(Product product)
    {
        return _productRepository.CreateProduct(product);
    }

    public bool UpdateProductPrice(Product product, decimal price)
    {
        return _productRepository.UpdateProductPrice(product, price);
    }

    public bool UpdateProductQuantity(Product product, int newQuantityValue)
    {
        return _productRepository.UpdateProductQuantity(product, newQuantityValue);
    }

    public List<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }
}