using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities.Enum;

namespace Api.Domain.Entities
{
    public class BookingEntity : BaseEntity
    {
        public UserEntity UserEntity { get; set; }
        public PackageEntity PackageEntity { get; set; }
        public DateTime BookingDate { get; set; }
        public StatusBookingEnum Status { get; set; }
    }
}