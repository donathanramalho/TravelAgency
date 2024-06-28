using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Booking
{
    public interface IPackageService
    {
      
        Task<PackageEntity> Get (Guid id);
        Task<IEnumerable<PackageEntity>> GetAll ();
        Task<PackageEntity> Post (PackageEntity package);
        Task<PackageEntity> Put (PackageEntity package);
        Task<bool> Delete (Guid id);

    
    }
}