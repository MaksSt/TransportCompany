using System;
using System.Collections.Generic;

namespace TransportCompany.Entities;

public partial class Cargo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Quanyity { get; set; }

    public int StockId { get; set; }

    public int CategoryIid { get; set; }

    public int ContractId { get; set; }

    public virtual Category CategoryI { get; set; } = null!;

    public virtual Contract Contract { get; set; } = null!;

    public virtual Stock Stock { get; set; } = null!;
}
