using Api.Domain.Interfaces.Services.Booking;
using Api.Domain.Interfaces.Services.Payment;
using Api.Domain.Interfaces.Services.User;
using Api.Services;
using Api.Services.Services;
using Api.Services.Services.Booking;
using Api.Services.Services.PaymentServices;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IBookingService, BookingService>();
            serviceCollection.AddTransient<IPackageService, PackageService>();
            serviceCollection.AddTransient<IPaymentService, PaymentService>();
            serviceCollection.AddTransient<IPriceCalculator, PriceCalculator>();
            serviceCollection.AddTransient<IUfService, UfService>();
            

        }

    }
}