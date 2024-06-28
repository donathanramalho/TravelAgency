using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IBookingRepository, BookingRepository>();
            serviceCollection.AddScoped<IRepository<PaymentEntity>, BaseRepository<PaymentEntity>>();

            var connectionString = "Server=localhost;Port=3306;Database=travel;Uid=root;Pwd=root";

            serviceCollection.AddDbContext<MyContext> (
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
                
            
        
        }
    }
}