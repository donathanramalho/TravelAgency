using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Api.Domain.Entities.Enum;

namespace Api.Domain.Entities
{
    public class PaymentEntity : BaseEntity
    {
        public Guid BookingId { get; set; }

        [JsonIgnore]
        public BookingEntity? BookingEntity { get; set; }

        public decimal Amount { get; private set; }
        public DateTime PaymentDate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PaymentEnum PaymentMethod { get; set; }
    

        public void SetAmount(decimal amount)
        {
            this.Amount = amount;
        }
    }
}