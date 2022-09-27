using System;
using System.Collections.Generic;

namespace Angular_link_to_DB_API.Db;

public partial class User
{
    public Guid Id { get; set; }

    public string LoginId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public Guid? DepartmentCodeFk { get; set; }

    public string? EmailAddress { get; set; }

    public Guid? UserStatusCode { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    public string? Remarks { get; set; }

    public byte[] Rowversion { get; set; } = null!;

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? Password { get; set; }
}
