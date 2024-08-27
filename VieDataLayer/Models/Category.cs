using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class Category
{
    public long CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public long? BranchId { get; set; }

    public long DisplayInPos { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
