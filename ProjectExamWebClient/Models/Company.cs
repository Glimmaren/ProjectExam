using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Costumer.Models;

namespace Customer.Models
{
    public class Company
    {   

        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyGroupId { get; set; }
        public int CompanyCategoryId { get; set; }
        public bool Wholesale { get; set; }
        public CompanyGroup? CompanyGroup { get; set; }
        public CompanyCategory? CompanyCategory { get; set; }

    }
}
