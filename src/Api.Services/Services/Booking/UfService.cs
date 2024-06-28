using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Booking;

namespace Api.Services.Services.Booking
{
    public class UfService : IUfService
    {
        private readonly IRepository<UfEntity> _repository;

        public UfService(IRepository<UfEntity> repository)
        {
            _repository = repository;
        }

        public async Task<UfEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UfEntity>> GetAll()
            {
                return await _repository.SelectAsync();
            }

    }
}