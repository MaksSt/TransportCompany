using System;
using System.Collections.Generic;

namespace TransportCompany.Entities;

public partial class Сarrier
{
    public int Id { get; set; }

    public string? Company { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public virtual ICollection<Node> Nodes { get; set; } = new List<Node>();
}
