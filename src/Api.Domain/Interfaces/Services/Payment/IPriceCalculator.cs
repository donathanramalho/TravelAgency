// Caminho: Domain/Interfaces/Services/Payment/IPriceCalculator.cs

using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Payment
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(PackageEntity package);
    }
}
