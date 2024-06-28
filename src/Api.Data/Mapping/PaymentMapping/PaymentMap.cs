using System;
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

            // Configuração do relacionamento com BookingEntity
            builder.HasOne(p => p.BookingEntity)
                .WithMany()
                .HasForeignKey(p => p.BookingId);

            builder.Property(p => p.Amount)
                .IsRequired();

            builder.Property(p => p.PaymentDate)
                .IsRequired();

            builder.Property(p => p.PaymentMethod)
                .IsRequired();

        }
    }
}
