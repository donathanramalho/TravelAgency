using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class UfEntity : BaseEntity
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<PackageEntity> Packages { get; set; } = new List<PackageEntity>();
    }
}
