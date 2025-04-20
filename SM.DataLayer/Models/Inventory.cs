using System;
using System.Collections.Generic;

namespace SM.DataLayer.Models;

public partial class Inventory
{
    public long InventoryId { get; set; }

    public long? ProductId { get; set; }

    public long? SupplierId { get; set; }

    public long? QuantityInStock { get; set; }

    public string? LastRestockedDate { get; set; }

    public string? ReorderThreshold { get; set; }

    public double? Price { get; set; }

    public long? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Supplier? Supplier { get; set; }

}
