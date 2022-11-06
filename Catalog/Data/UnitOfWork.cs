using Catalog.Interfaces;
using Catalog.Repositorys;
using Catalog.UnitOfWork;
using PriceLists.Data;

namespace Catalog.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogContext _context;
        public UnitOfWork(CatalogContext context)
        {
            _context = context;
        }
        public ICategoryRepository CategoryRepository => new CategoryRepository(_context);
        public IProductRepository ProductRepository => new ProductRepository(_context);
        public IPricedProductRepository PricedProductRepository => new PricedProductRepository(_context);
        public CatalogContext Context => _context;

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            throw new NotImplementedException();
        }
    }
}
