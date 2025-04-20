using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.DataLayer.Models;

namespace SM.ViewModels
{
    public class InventoryViewModel : Inventory
    {
        public string? SupplierName { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? BarcodeId { get; set; }
        public string? CategoryName { get; set; }
        public enum FilterType
        {
            ProductName,
            ProductDescription,
            BarcodeId,
            CategoryName
        }
    }
}
