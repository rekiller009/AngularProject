using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Angular_link_to_DB_API.Db;

public partial class CadetAuditTrailDbContext : DbContext
{
    public CadetAuditTrailDbContext()
    {
    }

    public CadetAuditTrailDbContext(DbContextOptions<CadetAuditTrailDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditTrail> AuditTrails { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MIS190500041;Initial Catalog=CADET_V01;Persist Security Info=False;User ID=NECSAPSIN\\changchuan_cham;Password=password;Integrated Security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditTrail>(entity =>
        {
            entity.ToTable("AuditTrail");

            entity.HasIndex(e => new { e.DeletedBy, e.DeletedDate }, "NCIX_AuditTrail_DeleteFlag");

            entity.HasIndex(e => e.TableFk, "NCIX_AuditTrail_Table_FK");

            entity.HasIndex(e => e.TableName, "NCIX_AuditTrail_Table_Name");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(3);
            entity.Property(e => e.AfterData)
                .HasColumnOrder(5)
                .HasColumnType("xml");
            entity.Property(e => e.BeforeData)
                .HasColumnOrder(4)
                .HasColumnType("xml");
            entity.Property(e => e.CreatedBy).HasColumnOrder(7);
            entity.Property(e => e.CreatedDate)
                .HasColumnOrder(8)
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasColumnOrder(11);
            entity.Property(e => e.DeletedDate)
                .HasColumnOrder(12)
                .HasColumnType("datetime");
            entity.Property(e => e.Rowversion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnOrder(6);
            entity.Property(e => e.TableFk)
                .HasColumnOrder(2)
                .HasColumnName("Table_FK");
            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnOrder(1)
                .HasColumnName("Table_Name");
            entity.Property(e => e.UpdatedBy).HasColumnOrder(9);
            entity.Property(e => e.UpdatedDate)
                .HasColumnOrder(10)
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
