using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string  Nome { get; set; }
        public string Email { get; set; }
        public string Phone { get; set;}
    }
}