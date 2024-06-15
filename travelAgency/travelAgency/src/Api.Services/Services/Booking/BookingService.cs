using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Booking;

namespace Api.Services.Services
{
    public class BookingService : IBookingService
    {
        
        private IRepository<BookingEntity> _repository;
        public BookingService(IRepository<BookingEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<BookingEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<BookingEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<BookingEntity> Post(BookingEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<BookingEntity> Put(BookingEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}