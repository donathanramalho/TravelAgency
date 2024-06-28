// Caminho: Api.Data/Repository/BookingRepository.cs

using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BookingRepository : BaseRepository<BookingEntity>, IBookingRepository
    {
        public BookingRepository(MyContext context) : base(context) { }

        public async Task<BookingEntity> SelectWithPackageAsync(Guid id)
        {
            return await _context.Set<BookingEntity>()
                .Include(b => b.PackageEntity) // Inclua a entidade relacionada
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        
    }
}
