using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMDataLayer.Models;

namespace SM.ViewModels
{
    public class OrderViewModel
    {
        public long OrderId { get; set; }
        public long OrderItemId { get; set; }
        public long? ItemId { get; set; }
        public string? Barcode { get; set; }

        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double? ProductPrice { get; set; }
        public double? UnitPriceAfterDiscount { get; set; }
        public double? TotalPrice { get; set; }
        public double? TotalPriceAfterDiscount { get; set; }
        public long? Quantity { get; set; }
        public string? SellerName { get; set; }
        public string? BuyerName { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public double? TotalInUsd { get; set; }
        public Image? Image { get; set; }
        public Product? Product { get; set; }
    }

}
