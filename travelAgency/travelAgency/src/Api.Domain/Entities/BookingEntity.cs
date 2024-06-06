using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class BookingEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public int PackageId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime Status { get; set; }
    }
}