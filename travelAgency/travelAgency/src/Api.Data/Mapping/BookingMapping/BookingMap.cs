using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping.BookingMapping
{
    public class BookingMap : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.ToTable("Booking");

            builder.HasKey(b => b.Id);

            builder.HasOne<PackageEntity>(b => b.PackageEntity)
                .WithMany()
                .HasForeignKey(p => p.Id);

            builder.Property(b => b.BookingDate)
                .HasMaxLength(10);

            builder.Property(b => b.Status)
                .HasMaxLength(50);

        }

    }
}