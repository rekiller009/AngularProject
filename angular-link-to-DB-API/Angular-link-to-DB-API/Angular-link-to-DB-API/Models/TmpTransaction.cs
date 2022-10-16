using System;
using System.Collections.Generic;

namespace Angular_link_to_DB_API.Models;

public partial class TmpTransaction
{
    public string? TransactionType { get; set; }

    public string? RefNo { get; set; }

    public DateTime? Dateissued { get; set; }

    public decimal? Amt { get; set; }

    public string? Invoice { get; set; }
}
