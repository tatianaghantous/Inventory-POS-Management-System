using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class ReviewsRating
{
    public long ReviewRatingId { get; set; }

    public long? ProductId { get; set; }

    public long? CustomerId { get; set; }

    public long? Rating { get; set; }

    public string? ReviewText { get; set; }

    public string? ReviewDate { get; set; }

    public long? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
