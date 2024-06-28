using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class PackageEntity : BaseEntity
    {
         public string MunicipioOrigem { get; set; }

        [Required]
        public Guid UfIdOrigem { get; set; }

        [JsonIgnore]
        public UfEntity? UfOrigem { get; set; }

        [Required]
        public string MunicipioDestino { get; set; }
        
        public Guid UfIdDestino { get; set; }

        [JsonIgnore]
        public UfEntity? UfDestino { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal Price { get; private set; }

        public void SetPrice(decimal price)
        {
            this.Price = price;
        }
    
    }
}
