using Costumer.Models;
using Customer.ViewModels.CompanyCategoryViewModels;
using Customer.ViewModels.CompanyGroupViewModels;


namespace Customer.ViewModels.CompanyViewModels
{
    public class CompanyViewModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public CompanyGroup CompanyGroup { get; set; }
        public CompanyCategory CompanyCategory { get; set; }
        public bool Wholesale { get; set; }
    }
}
