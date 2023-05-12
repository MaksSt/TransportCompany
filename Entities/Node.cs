using System;
using System.Collections.Generic;

namespace TransportCompany.Entities;

public partial class Node
{
    public int Id { get; set; }

    public string? TypeOfTransportation { get; set; }

    public string? Transport { get; set; }

    public string? ReceptionPoint { get; set; }

    public string? DeliveryDate { get; set; }

    public string? DeliveryPoint { get; set; }

    public string? DoINeedCustomsClearance { get; set; }

    public int EmployeeId { get; set; }

    public int CarrierId { get; set; }

    public virtual Сarrier Carrier { get; set; } = null!;

    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Scheme> Schemes { get; set; } = new List<Scheme>();
}
