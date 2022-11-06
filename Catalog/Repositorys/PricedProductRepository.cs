using System.Reflection;
using Catalog.Interfaces;
using Microsoft.EntityFrameworkCore;
using PriceLists.Data;
using PriceLists.Models;

namespace Catalog.Repositorys
{
    public class PricedProductRepository : IPricedProductRepository
    {
        private readonly CatalogContext _context;
        public PricedProductRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPricedProducedAsync(PricedProduct pricedProduct)
        {
            try
            {
                await _context.PricedProducts.AddAsync(pricedProduct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<PricedProduct> FindPricedProductByArtNumberAsync(int artNumber, int companyId)
        {
            return await _context.PricedProducts
                .Include(c=> c.Product)
                .Include(c => c.Product.Category)
                .FirstOrDefaultAsync(c => c.ArtNumber == artNumber && c.CompanyId == companyId );
        }


        public async Task<PricedProduct> FindPricedProductByIdAsync(int id, int companyId)
        {
            return await _context.PricedProducts
                .Include(c => c.Product)
                .Include(c => c.Product.Category)
                .FirstOrDefaultAsync(c => c.Id == id && c.CompanyId == companyId);
        }

        public async Task<IList<PricedProduct>> FindPricedProductByValidBetweenDateAsync(DateTime fromDate, DateTime toDate, int companyId)
        {
            return await _context.PricedProducts
                .Include(c => c.Product)
                .Include(c => c.Product.Category)
                .Where(c => c.ValdidFrom >= fromDate && c.ValdidTo <= toDate && c.CompanyId == companyId)
                .ToListAsync();
        }

        public async Task<IList<PricedProduct>> FindPricedProductByValidFromDateAsync(DateTime fromDate, int companyId)
        {
            return await _context.PricedProducts
                .Include(c => c.Product)
                .Include(c => c.Product.Category)
                .Where(c => c.ValdidFrom >= fromDate && c.CompanyId == companyId)
                .ToListAsync();
        }

        public async Task<IList<PricedProduct>> FindPricedProductByValidToDateAsync(DateTime toDate, int companyId)
        {
            return await _context.PricedProducts
                .Include(c => c.Product)
                .Include(c => c.Product.Category)
                .Where(c => c.ValdidTo <= toDate && c.CompanyId == companyId)
                .ToListAsync();
        }

        public async Task<IList<PricedProduct>> FindPricedProductIncludingNameAsync(string name, int companyId)
        {
            return await _context.PricedProducts
                .Include(c => c.Product)
                .Include(c => c.Product.Category)
                .Where(c => c.Product.Name == name && c.CompanyId == companyId)
                .ToListAsync();
        }

        public async Task<IList<PricedProduct>> ListAllPricedProductsAsync(int companyId)
        {
            return await _context.PricedProducts
                .Include(c => c.Product)
                .Include(c => c.Product.Category)
                .ToListAsync();
        }

        public bool RemovePricedProductAsync(PricedProduct pricedProduct)
        {
            try
            {
                _context.PricedProducts.Remove(pricedProduct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePricedProductAsync(PricedProduct pricedProduct)
        {
            try
            {
                _context.PricedProducts.Update(pricedProduct);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
