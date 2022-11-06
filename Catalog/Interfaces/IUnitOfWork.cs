using Catalog.Interfaces;
using PriceLists.Data;

namespace Catalog.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IPricedProductRepository PricedProductRepository { get; }
        CatalogContext Context { get; }
        Task<bool> CompleteAsync();
        bool HasChanges();

    }
}
