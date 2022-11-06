using AutoMapper;
using AutoMapper.Execution;
using Catalog.ViewModels.PricedProductViewModels;
using Catalog.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using PriceLists.Data;
using PriceLists.Models;

namespace Catalog.Helpers
{
    //public class PricedProductResolver : IValueResolver<PostPricedProductViewMoedel, PricedProduct, Product>
    //{
    //    public Product Resolve(PostPricedProductViewMoedel source, PricedProduct Destination, Product destMember,
    //        ResolutionContext context)
    //    {
    //        var repo = context.Items["repo"] as CatalogContext;

    //        var result = repo.Products.FirstOrDefault(c => c.ProductId == source.ProductId);
    //        if(result == null) 
    //            throw new Exception($"Error, could not find any Product matching, check id:{source.ProductId}");

    //        return result;

    //    }
    //}
}
