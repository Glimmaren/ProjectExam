using System.ComponentModel.DataAnnotations;

namespace PriceLists.Models
{
    public class Pricelists
    {
        [Key]
        public int PriceListId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public List<Product> Products { get; set; }

    }
}
