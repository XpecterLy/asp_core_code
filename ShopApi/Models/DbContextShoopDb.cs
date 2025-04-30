using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShopApi.Models;

public partial class DbContextShoopDb : DbContext
{
    public DbContextShoopDb()
    {
    }

    public DbContextShoopDb(DbContextOptions<DbContextShoopDb> options)
        : base(options)
    {
    }

    public virtual DbSet<DtProduct> DtProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DtProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("dt_product");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.DateCreate).HasColumnName("date_create");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
