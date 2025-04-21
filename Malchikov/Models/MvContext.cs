using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Malchikov.Models;

public partial class MvContext : DbContext
{
    public MvContext()
    {
    }

    public MvContext(DbContextOptions<MvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assortment> Assortments { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PK452-14;DataBase=MV;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assortment>(entity =>
        {
            entity.ToTable("Assortment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PriceShop)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("price_shop");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.Volume)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("volume");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Shop_1");

            entity.ToTable("Shop");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssortmentId).HasColumnName("assortment_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PriceShop).HasColumnName("price_shop");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

            entity.HasOne(d => d.Assortment).WithMany(p => p.Shops)
                .HasForeignKey(d => d.AssortmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shop_Assortment");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Shops)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shop_Supplier");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PriceSupplier).HasColumnName("price_supplier");
            entity.Property(e => e.Quatity).HasColumnName("quatity");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
