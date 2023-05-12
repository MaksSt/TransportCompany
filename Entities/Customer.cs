using System;
using System.Collections.Generic;

namespace TransportCompany.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public string? Number { get; set; }

    public string? Email { get; set; }

    public int? Inn { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
