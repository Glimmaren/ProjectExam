using System.ComponentModel.DataAnnotations;

namespace Costumer.Models
{
    public class CompanyCategory
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
