using AutoMapper;
using Catalog.ViewModels.CategoryViewModels;
using Catalog.ViewModels.PricedProductViewModels;
using Catalog.ViewModels.ProductViewModels;
using PriceLists.Models;

namespace Catalog.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CategoryMapping
            CreateMap<PostCategoryViewModel, Category>();
            CreateMap<Category, CategoryViewModel>();

            //ProductMapping
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();


            CreateMap<PostProductViewModel, Product>();
            CreateMap<Product, PostProductViewModel>();

            CreateMap<PatchProductViewModel, Product>();
            CreateMap<Product, PatchProductViewModel>();

            //PricedProductMapping
            CreateMap<PricedProduct, PostPricedProductViewMoedel>();
            CreateMap<PostPricedProductViewMoedel, PricedProduct>();

            CreateMap<PricedProductViewModel, PricedProduct>();
            CreateMap<PricedProduct, PricedProductViewModel>();
            



        }
    }
}
