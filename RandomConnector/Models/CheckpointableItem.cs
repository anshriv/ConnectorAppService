using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RandomConnector.Models
{
    public class CheckpointableItem
    {
        [JsonProperty("searchableItems")]
        public List<SearchableItem> SearchableItems { get; set; }

        [JsonProperty("moveNext")]
        public bool MoveNext { get; set; }

        [JsonProperty("checkpoint")]
        public int Checkpoint { get; set; }
    }
}