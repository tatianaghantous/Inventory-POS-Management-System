using System.Collections.Generic;

namespace ShopifyAPI.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string BarcodeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public int? CategoryId { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? InitialPrice { get; set; }

        public int? BranchId { get; set; }

    }
}

