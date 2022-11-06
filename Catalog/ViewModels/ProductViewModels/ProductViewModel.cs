using PriceLists.Models;

namespace Catalog.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Category? Category { get; set; }
    }
}
