using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string? NotificationText { get; set; }

    public bool NotificationSeen { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }
}
