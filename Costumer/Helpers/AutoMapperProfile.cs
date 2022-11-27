using AutoMapper;
using Catalog.ViewModels;
using Costumer.Models;
using Customer.Models;
using Customer.ViewModels;
using Customer.ViewModels.CompanyCategoryViewModels;
using Customer.ViewModels.CompanyGroupViewModels;
using Customer.ViewModels.CompanyViewModels;
using Customer.ViewModels.PersonViewModels;
using Customer.ViewModels.RoleViewModels;
using JWTAuhtenticationManager.Models;

namespace Customer.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Role Mapping
            CreateMap<Role, PostRoleViewModel>();
            CreateMap<PostRoleViewModel, Role>();

            CreateMap<Role, PatchRoleViewModel>();
            CreateMap<PatchRoleViewModel, Role>();

            CreateMap<RoleViewModel, Role>();
            CreateMap<Role, RoleViewModel>();

            //CompanyGroup Mapping
            CreateMap<CompanyGroup, PostCompanyGroupViewModel>();
            CreateMap<PostCompanyGroupViewModel, CompanyGroup>();

            CreateMap<CompanyGroup, PatchCompanyGroupViewModel>();
            CreateMap<PatchCompanyGroupViewModel, CompanyGroup>();

            CreateMap<CompanyGroup, CompanyGroupViewModel>();
            CreateMap<CompanyGroupViewModel, CompanyGroup>();

            //ComppanyGroup Mapoing
            CreateMap<CompanyCategory, PostCompanyCategoryViewModel>();
            CreateMap<PostCompanyCategoryViewModel, CompanyCategory>();

            CreateMap<CompanyCategory, PatchCompanyCategoryViewModel>();
            CreateMap<PatchCompanyCategoryViewModel, CompanyCategory>();

            CreateMap<CompanyCategory, CompanyCategoryViewModel>();
            CreateMap<CompanyCategoryViewModel, CompanyCategory>();

            //Comppany Mapoing
            CreateMap<Company, PostCompanyViewModel>();
            CreateMap<PostCompanyViewModel, Company>();

            CreateMap<Company, PatchCompanyViewModel>();
            CreateMap<PatchCompanyViewModel, Company>();

            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyViewModel, Company>();

            //Comppany Mapoing
            CreateMap<Person, PostPersonViewModel>();
            CreateMap<PostPersonViewModel, Person>();

            CreateMap<Person, PatchPersonViewModel>();
            CreateMap<PatchPersonViewModel, Person>();

            CreateMap<Person, PersonViewModel>();
            CreateMap<PersonViewModel, Person>();

            //Outhers
            CreateMap<AuthenticationResponse, Token>();

        }
    }
}
