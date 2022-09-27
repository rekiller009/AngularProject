using System;
using System.Collections.Generic;

namespace Angular_link_to_DB_API.Db;

public partial class AuditTrail
{
    public Guid Id { get; set; }

    public string? TableName { get; set; }

    public Guid TableFk { get; set; }

    public string? Action { get; set; }

    public string? BeforeData { get; set; }

    public string? AfterData { get; set; }

    public byte[] Rowversion { get; set; } = null!;

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }
}
