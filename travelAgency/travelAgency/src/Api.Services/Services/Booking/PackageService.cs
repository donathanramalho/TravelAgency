using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Booking;

namespace Api.Services.Services
{
    public class PackageService : IPackageService
    {
        
        private IRepository<PackageEntity> _repository;
        public PackageService(IRepository<PackageEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<PackageEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<PackageEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<PackageEntity> Post(PackageEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<PackageEntity> Put(PackageEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}