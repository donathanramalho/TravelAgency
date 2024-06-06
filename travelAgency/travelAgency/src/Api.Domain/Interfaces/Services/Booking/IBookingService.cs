using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Booking
{
    public interface IBookingService
    {
        Task<BookingEntity> Get (Guid id);
        Task<IEnumerable<BookingEntity>> GetAll ();
        Task<BookingEntity> Post (BookingEntity user);
        Task<BookingEntity> Put (BookingEntity user);
        Task<bool> Delete (Guid id);

    }
    
}