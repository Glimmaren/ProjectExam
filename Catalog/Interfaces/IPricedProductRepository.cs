using PriceLists.Models;

namespace Catalog.Interfaces
{
    public interface IPricedProductRepository
    {
        Task<bool> AddPricedProducedAsync(PricedProduct pricedProduct);
        bool UpdatePricedProductAsync(PricedProduct pricedProduct);
        bool RemovePricedProductAsync(PricedProduct pricedProduct);
        Task<IList<PricedProduct>> ListAllPricedProductsAsync(int companyId);
        Task<PricedProduct> FindPricedProductByIdAsync(int id, int companyId);
        Task<IList<PricedProduct>> FindPricedProductIncludingNameAsync(string name, int companyId);
        Task<IList<PricedProduct>> FindPricedProductByValidFromDateAsync(DateTime fromDate, int companyId);
        Task<IList<PricedProduct>> FindPricedProductByValidToDateAsync(DateTime toDate, int companyId);
        Task<IList<PricedProduct>> FindPricedProductByValidBetweenDateAsync(DateTime fromDate,DateTime toDate, int companyId);
        Task<PricedProduct> FindPricedProductByArtNumberAsync(int artNumber, int companyId);

    }
}
