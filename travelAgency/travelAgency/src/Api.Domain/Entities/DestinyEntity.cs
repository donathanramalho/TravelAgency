using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class DestinyEntity : BaseEntity
    {
        public Guid UfId { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
       
        
    }
}