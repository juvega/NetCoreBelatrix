using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.UnitPrice)
                .HasColumnName("unit_price")
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .HasConstraintName("order_id")
                .IsRequired();

            builder.HasOne(oi => oi.Product)
                .WithMany(c => c.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .HasConstraintName("product_id")
                .IsRequired();

            builder.HasIndex(p => p.OrderId).HasName("order_item_order_id_idx");

            builder.HasIndex(p => p.ProductId).HasName("order_item_product_id_idx");
        }
    }
}
