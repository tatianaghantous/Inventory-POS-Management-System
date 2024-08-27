namespace ShopifyAPI.Dtos
{
    public class InventoryDto
    {
        public int InventoryId { get; set; }

        public int? ProductId { get; set; }

        public int? SupplierId { get; set; }

        public int? QuantityInStock { get; set; }

        public DateTime? LastRestockedDate { get; set; }

        public DateTime? ReorderThreshold { get; set; }

        public decimal? Price { get; set; }

        public int? BranchId { get; set; }
    }
}

