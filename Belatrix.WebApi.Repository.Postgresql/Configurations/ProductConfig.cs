using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.UnitPrice)
                .HasColumnName("unit_price");

            builder.Property(p => p.ProductName)
                .HasColumnName("product_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Package)
                .HasColumnName("package")
                .HasMaxLength(30);

            builder.Property(p => p.IsDiscontinued)
                .HasColumnName("is_discontinued")
                .IsRequired();

            builder.HasOne(oi => oi.Supplier)
                .WithMany(o => o.Products)
                .HasForeignKey(oi => oi.SupplierId)
                .HasConstraintName("supplier_id")
                .IsRequired();

            builder.HasIndex(p => p.SupplierId).HasName("product_supplier_id_idx");

            builder.HasIndex(p => p.ProductName).HasName("product_name_idx");
        }
    }
}
