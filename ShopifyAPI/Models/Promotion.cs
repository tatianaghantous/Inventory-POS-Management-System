using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public string? PromotionName { get; set; }

    public DateTime? Discount { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }
}
