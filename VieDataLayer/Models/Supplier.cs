using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class Supplier
{
    public long SupplierId { get; set; }

    public string? Name { get; set; }

    public string? ContactInformation { get; set; }

    public string? Location { get; set; }

    public long? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
