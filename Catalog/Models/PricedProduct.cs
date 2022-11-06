using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceLists.Models
{
    public class PricedProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int ArtNumber { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public DateTime ValdidFrom { get; set;}
        [Required]
        public DateTime ValdidTo { get; set; }
        public bool IsCampaign { get; set; }
        [Required] 
        public double Price { get; set; }
        [ForeignKey("ProductId")] 
        public Product? Product { get; set; }

    }
}
