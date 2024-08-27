using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int? ProductId { get; set; }

    public int? SupplierId { get; set; }

    public int? QuantityInStock { get; set; }

    public DateTime? LastRestockedDate { get; set; }

    public DateTime? ReorderThreshold { get; set; }

    public decimal? Price { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
