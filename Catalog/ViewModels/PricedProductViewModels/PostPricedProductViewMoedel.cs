namespace Catalog.ViewModels.PricedProductViewModels
{
    public class PostPricedProductViewMoedel
    {
        public int ProductId { get; set; }
        public int ArtNumber { get; set; }
        public int CompanyId { get; set; }
        public DateTime ValdidFrom { get; set; }
        public DateTime ValdidTo { get; set; }
        public bool IsCampaign { get; set; }
        public double Price { get; set; }
    }
}
