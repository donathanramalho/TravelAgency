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

          public async Task<PackageEntity> Post(PackageEntity package)
        {
            if (await _repository.ExistAsync(package.Id))
            {
                throw new ArgumentException("Package ID already exists.");
            }

            if (package.EndDate < DateTime.UtcNow)
            {
                throw new ArgumentException("End date cannot be in the past.");
            }
            if (package.Quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0.");
            }

            return await _repository.InsertAsync(package);
        }

        public async Task<PackageEntity> Put(PackageEntity package)
        {
            if (package.EndDate < DateTime.UtcNow)
            {
                throw new ArgumentException("End date cannot be in the past.");
            }

            var existingPackage = await _repository.SelectAsync(package.Id);
            if (existingPackage == null)
            {
                throw new ArgumentException("Package not found.");
            }
            if (package.Quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0.");
            }

            return await _repository.UpdateAsync(package);
        }
    }
}