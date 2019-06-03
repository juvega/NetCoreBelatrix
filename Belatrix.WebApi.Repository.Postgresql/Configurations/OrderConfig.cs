using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.OrderDate)
                .HasColumnName("order_date")
                .IsRequired();

            builder.Property(p => p.OrderNumber)
                .HasColumnName("order_number")
                .HasMaxLength(10);

            builder.Property(p => p.TotalAmount)
                .HasColumnName("total_amount");

            builder.HasIndex(p => p.OrderDate)
                .HasName("order_date_idx");

            builder.HasIndex(p => p.CustomerId)
                .HasName("order_customer_id_idx");

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .HasConstraintName("customer_id")
                .IsRequired();
        }
    }
}
