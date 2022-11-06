using AutoMapper;
using AutoMapper.Execution;
using Catalog.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using PriceLists.Data;
using PriceLists.Models;

namespace Catalog.Helpers
{
    //public class ProductResolver : IValueResolver<PostProductViewModel, Product, Category>
    //{
    //    //public Category Resolve(PostProductViewModel source, Product destination, Category destMember, ResolutionContext context)
    //    //{
    //    //    var repo = context.Items["repo"] as CatalogContext;

    //    //    var result = repo.Categories.FirstOrDefault(c => c.Id == source.CategoryId);
    //    //    if (result == null)
    //    //        throw new Exception($"Error, could not find any category matching this product, check id:{source.CategoryId}");

    //    //    return result;
    //    //}

    //    //public Category Resolve(ProductViewModel source, Product destination, Category destMember, ResolutionContext context)
    //    //{
    //    //    var repo = context.Items["repo"] as CatalogContext;

    //    //    var result = repo.Categories.FirstOrDefault(c => c.Id == source.CategoryId);
    //    //    if (result == null)
    //    //        throw new Exception($"Error, could not find any category matching this product, check id:{source.CategoryId}");

    //    //    return result;
    //    //}
    //}
}
