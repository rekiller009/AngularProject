using System;
using System.Collections.Generic;
using Angular_link_to_DB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular_link_to_DB_API.Db;

public partial class TestingContext : DbContext
{
    public TestingContext()
    {
    }

    public TestingContext(DbContextOptions<TestingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TmpTransaction> TmpTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CHANGCHUAN-ASUS;Database=Testing;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TmpTransaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tmpTransaction");

            entity.Property(e => e.Amt).HasColumnType("money");
            entity.Property(e => e.Dateissued).HasColumnType("datetime");
            entity.Property(e => e.Invoice)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RefNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TransactionType)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
