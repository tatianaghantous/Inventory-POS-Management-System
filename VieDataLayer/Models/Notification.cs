using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class Notification
{
    public long NotificationId { get; set; }

    public string? NotificationText { get; set; }

    public long NotificationSeen { get; set; }

    public long? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }
}
