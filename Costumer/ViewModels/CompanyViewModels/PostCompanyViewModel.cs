using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Costumer.Models;

namespace Customer.ViewModels.CompanyViewModels
{
    public class PostCompanyViewModel
    {
        public string Name { get; set; }
        public int CompanyGroupId { get; set; }
        public int CompanyCategoryId { get; set; }
        public bool Wholesale { get; set; }
    }
}
