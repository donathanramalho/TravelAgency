using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping.BookingMapping
{
    public class DestinyMap : IEntityTypeConfiguration<DestinyEntity>
    {
        public void Configure(EntityTypeBuilder<DestinyEntity> builder)
        {
            builder.ToTable("Destiny");

            builder.HasKey(d => d.Id);

            builder.HasIndex(d => d.UfId)
                .IsUnique();

            builder.Property(d => d.Nome)
                .HasMaxLength(100);

            builder.Property(d => d.Sigla)
                .HasMaxLength(2);

        }
    }

}