using System;
using System.Collections.Generic;

namespace TransportCompany.Entities;

public partial class Check
{
    public string Id { get; set; } = null!;

    public int? PaymentAmount { get; set; }

    public int NodeId { get; set; }

    public virtual Node Node { get; set; } = null!;
}
