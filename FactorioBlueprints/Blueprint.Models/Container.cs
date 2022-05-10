using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blueprint.Models
{
    public class Container
    {
        [JsonPropertyName("blueprint")]
        public Blueprint? Blueprint { get; set; }
        [JsonPropertyName("blueprint-book")]
        public BlueprintBook? Book { get; set; }
    }
}
