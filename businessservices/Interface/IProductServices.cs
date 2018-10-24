using BusinessEntities;
using System.Collections.Generic;


namespace BusinessServices
{
    /// <summary>
    /// Product Service Contract
    /// </summary>
    public interface IProductServices
    {
        ProductEntity GetProductById(int id);
        IEnumerable<ProductEntity> GetAllProducts();
        int CreateProduct(ProductEntity productEntity);
        bool UpdateProduct(int id, ProductEntity productEntity);
        bool DeleteProduct(int id); 
    }
}
