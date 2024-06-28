using Api.Domain.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Payment;

namespace Api.Services
{
    public class PriceCalculator : IPriceCalculator
    {
        public decimal CalculatePrice(PackageEntity package)
        {
            
            return package.Quantity * 100; 
        }
    }
}
