using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Booking;

namespace Api.Services.Services.PaymentServices
{
    public class PaymentService : IPaymentService
    {
        
        private IRepository<PaymentEntity> _repository;
        public PaymentService(IRepository<PaymentEntity> repository)
        {
            _repository = repository;
        }

        public async Task<PaymentEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<PaymentEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<PaymentEntity> Post(PaymentEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<PaymentEntity> Put(PaymentEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}