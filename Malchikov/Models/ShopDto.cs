namespace Malchikov.Models
{
    public class ShopDto
    {
        public string Name { get; set; } = null!;

        public int Quantity { get; set; }

        public int PriceShop { get; set; }

        public int SupplierId { get; set; }

        public int AssortmentId { get; set; }
    }
}
