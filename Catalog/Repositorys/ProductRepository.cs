using Catalog.Interfaces;
using Microsoft.EntityFrameworkCore;
using PriceLists.Data;
using PriceLists.Models;

namespace Catalog.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            try
            {
                await _context.AddAsync(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Product> FindProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Product> FindProductByNameAsync(string name)
        {
            return await _context.Products
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task<IList<Product>> FindProductIncludingNameAsync(string name)
        {
            return await _context.Products
                .Where(c => c.Name.Trim().ToLower().Contains(name.Trim().ToLower())).ToListAsync();
        }

        public async Task<IList<Product>> ListAllProductsAsync()
        {
            return await _context.Products.
                Include(c => c.Category).ToListAsync();
        }

        public bool RemoveProductAsync(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateProductAsync(Product product)
        {
            try
            {
                _context.Products.Update(product);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
