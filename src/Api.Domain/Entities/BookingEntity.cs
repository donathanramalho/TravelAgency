using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Api.Domain.Entities.Enum;

namespace Api.Domain.Entities
{
   public class BookingEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        
        [JsonIgnore]
        public UserEntity? UserEntity { get; set; }

        public Guid PackageId { get; set; }

        [JsonIgnore]
        public PackageEntity? PackageEntity { get; set; }

        public DateTime BookingDate { get; set; }
        
    }
}