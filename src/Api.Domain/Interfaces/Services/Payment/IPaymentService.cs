using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Booking
{
    public interface IPaymentService
    {

        Task<PaymentEntity> Get (Guid id);
        Task<IEnumerable<PaymentEntity>> GetAll ();
        Task<PaymentEntity> Post (PaymentEntity payment);
        Task<PaymentEntity> Put (PaymentEntity payment);
        IEnumerable<string> GetPaymentMethods();
        Task<bool> Delete (Guid id);
    

    }
}