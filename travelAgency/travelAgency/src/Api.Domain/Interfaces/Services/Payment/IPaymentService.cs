using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Booking
{
    public interface IPaymentService
    {
        public interface IBookingService
    {
        Task<PaymentEntity> Get (Guid id);
        Task<IEnumerable<PaymentEntity>> GetAll ();
        Task<PaymentEntity> Post (PaymentEntity user);
        Task<PaymentEntity> Put (PaymentEntity user);
    

    }
    }
}