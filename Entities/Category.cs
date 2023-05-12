using System;
using System.Collections.Generic;

namespace TransportCompany.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string? Category1 { get; set; }

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();
}
