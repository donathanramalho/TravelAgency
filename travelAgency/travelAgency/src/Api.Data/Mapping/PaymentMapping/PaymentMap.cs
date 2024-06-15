using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping.PaymentMapping
{
    public class PaymentMap : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.ToTable("Payment");

            builder.HasKey(p => p.Id);

            builder.HasOne<BookingEntity>(p => p.BookingEntity)
                .WithMany()
                .HasForeignKey(b => b.Id);

            builder.Property(p => p.Amount);

            builder.Property(p => p.PaymentDate)
                .HasMaxLength(10);

            builder.Property(p => p.PaymentMethod)
                .HasMaxLength(50);
            
            builder.Property(p => p.Status)
                .HasMaxLength(10);

        }
    }

}