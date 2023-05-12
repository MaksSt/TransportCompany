using System;
using System.Collections.Generic;

namespace TransportCompany.Entities;

public partial class Contract
{
    public int Id { get; set; }

    public int? Price { get; set; }

    public int CustomerId { get; set; }

    public string? ЗlaceOfDelivery { get; set; }

    public string? ShipmentDate { get; set; }

    public string? DateOfConclusionOfTheContract { get; set; }

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
