using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomConnector.Models
{
    public class SearchableItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public IDictionary<string, object> Properties { get; set; }
    }
}
