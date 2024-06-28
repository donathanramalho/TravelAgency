// Caminho: Api.Domain/Interfaces/Repositories/IBookingRepository.cs

using System;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IBookingRepository : IRepository<BookingEntity>
    {
        Task<BookingEntity> SelectWithPackageAsync(Guid id);
    }
}
