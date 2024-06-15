using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities.Enum;

namespace Api.Domain.Entities
{
    public class PaymentEntity : BaseEntity
    {
        public BookingEntity BookingEntity { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentEnum PaymentMethod { get; set; }
        public StatusEnum Status { get; set; }
    }
}