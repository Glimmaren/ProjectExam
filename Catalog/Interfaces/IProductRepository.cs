using PriceLists.Models;

namespace Catalog.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> AddProductAsync(Product product);
        bool UpdateProductAsync(Product product);
        bool RemoveProductAsync(Product product);
        Task<IList<Product>> ListAllProductsAsync();
        Task<Product> FindProductByIdAsync(int id);
        Task<Product> FindProductByNameAsync(string name);
        Task<IList<Product>> FindProductIncludingNameAsync(string name);
    }
}
