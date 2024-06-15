using Api.Data.Mapping;
using Api.Data.Mapping.BookingMapping;
using Api.Data.Mapping.PaymentMapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        //public DbSet<UserEntity> Users {get; set;}
        public MyContext (DbContextOptions<MyContext> options) : base (options) 
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity> (new UserMap().Configure);
            modelBuilder.Entity<BookingEntity> (new BookingMap().Configure);
            modelBuilder.Entity<PackageEntity> (new PackageMap().Configure);
            modelBuilder.Entity<DestinyEntity> (new DestinyMap().Configure);
            modelBuilder.Entity<PaymentEntity> (new PaymentMap().Configure);
        }
    }
}