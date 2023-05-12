using System;
using System.Collections.Generic;

namespace TransportCompany.Entities;

public partial class Stock
{
    public int Id { get; set; }

    public string? Number { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();
}
