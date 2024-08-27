using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class Promotion
{
    public long PromotionId { get; set; }

    public string? PromotionName { get; set; }

    public string? Discount { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public string? Description { get; set; }

    public long? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }
}
