using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Costumer.Models;
using Customer.ViewModels.CompanyCategoryViewModels;
using Customer.ViewModels.CompanyGroupViewModels;

namespace Customer.Models
{
    public class Company
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public int CompanyGroupId { get; set; }
        [Required]
        public int CompanyCategoryId { get; set; }
        [Required]
        public bool Wholesale { get; set; }
        public CompanyGroup? CompanyGroup { get; set; }
        [ForeignKey("CompanyCategoryId")]
        public CompanyCategory? CompanyCategory { get; set; }

    }
}
