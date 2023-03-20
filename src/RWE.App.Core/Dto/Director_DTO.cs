using RWE.App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RWE.App.Core.Dto
{
    public class Director_DTO
    {
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("birthdate")]
        public DateTime Birthdate { get; set; }
        [JsonPropertyName("movie")]
        public virtual Movie Movie { get; set; }
    }
}
