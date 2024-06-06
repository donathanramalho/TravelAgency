using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Booking
{
    public interface IDestinyEntity
    {
        public interface IBookingService
    {
        Task<DestinyEntity> Get (Guid id);
        Task<IEnumerable<DestinyEntity>> GetAll ();
        Task<DestinyEntity> Post (DestinyEntity user);
        Task<DestinyEntity> Put (DestinyEntity user);
        Task<bool> Delete (Guid id);

    }
    }
}