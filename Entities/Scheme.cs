using System;
using System.Collections.Generic;

namespace TransportCompany.Entities;

public partial class Scheme
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int NodeId { get; set; }

    public virtual Node Node { get; set; } = null!;
}
