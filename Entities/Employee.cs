using System;
using System.Collections.Generic;

namespace TransportCompany.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Middlename { get; set; }

    public string? Patronymic { get; set; }

    public string? Post { get; set; }

    public string? Login { get; set; }

    public string? Pass { get; set; }

    public string? Rank { get; set; }

    public virtual ICollection<Node> Nodes { get; set; } = new List<Node>();
}
