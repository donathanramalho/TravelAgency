// Caminho: Api.Services/Services/PaymentService.cs

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Entities.Enum;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Booking;
using Api.Domain.Interfaces.Repositories;

namespace Api.Services.Services.PaymentServices
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<PaymentEntity> _repository;
        private readonly IBookingRepository _bookingRepository;

        public PaymentService(IRepository<PaymentEntity> repository, IBookingRepository bookingRepository)
        {
            _repository = repository;
            _bookingRepository = bookingRepository;
        }

        public async Task<PaymentEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<PaymentEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<PaymentEntity> Post(PaymentEntity payment)
        {
            var booking = await _bookingRepository.SelectWithPackageAsync(payment.BookingId);

            if (booking == null)
            {
                throw new ArgumentException("Invalid Booking ID");
            }

            var package = booking.PackageEntity;
            if (package == null)
            {
                throw new ArgumentException("PackageEntity is null");
            }

            payment.SetAmount(package.Price);

            return await _repository.InsertAsync(payment);
        }

        public async Task<PaymentEntity> Put(PaymentEntity payment)
        {
            var booking = await _bookingRepository.SelectWithPackageAsync(payment.BookingId);

            if (booking == null)
            {
                throw new ArgumentException("Invalid Booking ID");
            }

            var package = booking.PackageEntity;
            payment.SetAmount(package.Price);

            return await _repository.UpdateAsync(payment);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public IEnumerable<string> GetPaymentMethods()
        {
            return Enum.GetNames(typeof(PaymentEnum));
        }
    }
}
