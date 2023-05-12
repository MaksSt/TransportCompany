using System;
using System.Collections.Generic;

namespace TransportCompany.Entities;

public partial class Invoice
{
    public int Id { get; set; }

    public string? Price { get; set; }

    public string? PriceCustomClearance { get; set; }

    public int ContractId { get; set; }

    public int NodeId { get; set; }

    public virtual Contract Contract { get; set; } = null!;

    public virtual Node Node { get; set; } = null!;
}
