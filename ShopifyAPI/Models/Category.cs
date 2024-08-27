using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
