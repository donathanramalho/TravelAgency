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

            builder.HasOne(p => p.UfOrigem)
                .WithMany()
                .HasForeignKey(p => p.UfIdOrigem)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.UfDestino)
                .WithMany()
                .HasForeignKey(p => p.UfIdDestino)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.MunicipioOrigem)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.MunicipioDestino)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.EndDate)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();
        }
    }
}
