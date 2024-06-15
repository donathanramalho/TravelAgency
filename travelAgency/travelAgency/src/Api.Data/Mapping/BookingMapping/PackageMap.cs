using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping.BookingMapping
{
    public class PackageMap : IEntityTypeConfiguration<PackageEntity>
    {
        public void Configure(EntityTypeBuilder<PackageEntity> builder)
        {
            builder.ToTable("Package");

            builder.HasKey(p => p.Id);

            builder.HasOne<DestinyEntity>(p => p.DestinyEntity)
                .WithMany()
                .HasForeignKey(d => d.Id);
            
            builder.Property(p => p.Quantity);

            builder.Property(p => p.StartDate)
                .HasMaxLength(10);

            builder.Property(p => p.EndDate)
                .HasMaxLength(10);

            builder.Property(p => p.Price);

        }
    }
}