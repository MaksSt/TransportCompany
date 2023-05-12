using System;
using System.Collections.Generic;

namespace TransportCompany.Entities;

public partial class Contractemployee
{
    public int EmployeeId { get; set; }

    public int ContractId { get; set; }

    public virtual Contract Contract { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
