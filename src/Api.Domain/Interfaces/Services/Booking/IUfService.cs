using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Booking
{
   public interface IUfService
    {
        Task<UfEntity> Get(Guid id);
        Task<IEnumerable<UfEntity>> GetAll ();
    }
}