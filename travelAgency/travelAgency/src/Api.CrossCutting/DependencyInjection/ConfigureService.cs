using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Booking;
using Api.Domain.Interfaces.Services.User;
using Api.Services.Services;
using Api.Services.Services.PaymentServices;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IBookingService, BookingService>();
            serviceCollection.AddTransient<IDestinyService, DestinyService>();
            serviceCollection.AddTransient<IPackageService, PackageService>();
            serviceCollection.AddTransient<IPaymentService, PaymentService>();

        }

    }
}