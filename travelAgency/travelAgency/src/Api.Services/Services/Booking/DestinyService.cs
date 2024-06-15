using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Booking;

namespace Api.Services.Services
{
    public class DestinyService : IDestinyService
    {
    
        private IRepository<DestinyEntity> _repository;
        public DestinyService(IRepository<DestinyEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<DestinyEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<DestinyEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<DestinyEntity> Post(DestinyEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<DestinyEntity> Put(DestinyEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
        
    }
