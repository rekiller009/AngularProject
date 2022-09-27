using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Angular_link_to_DB_API.Db;

public partial class CadetDbContext : DbContext
{
    public CadetDbContext()
    {
    }

    public CadetDbContext(DbContextOptions<CadetDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MIS190500041;Initial Catalog=CADET_V01;Persist Security Info=False;User ID=NECSAPSIN\\changchuan_cham;Password=password;Integrated Security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.ToTable(tb => tb.HasTrigger("trAT_Users"));

            entity.HasIndex(e => e.LoginId, "U_LoginId").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.CreatedBy).HasColumnOrder(10);
            entity.Property(e => e.CreatedDate)
                .HasColumnOrder(11)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasColumnOrder(14);
            entity.Property(e => e.DeletedDate)
                .HasColumnOrder(15)
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentCodeFk)
                .HasColumnOrder(3)
                .HasColumnName("DepartmentCodeFK");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnOrder(4);
            entity.Property(e => e.ExpiryDate)
                .HasColumnOrder(7)
                .HasColumnType("datetime");
            entity.Property(e => e.LoginId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(1);
            entity.Property(e => e.Password)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnOrder(16);
            entity.Property(e => e.Remarks)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnOrder(8);
            entity.Property(e => e.Rowversion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnOrder(9);
            entity.Property(e => e.StartDate)
                .HasColumnOrder(6)
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasColumnOrder(12);
            entity.Property(e => e.UpdatedDate)
                .HasColumnOrder(13)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnOrder(2);
            entity.Property(e => e.UserStatusCode).HasColumnOrder(5);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
