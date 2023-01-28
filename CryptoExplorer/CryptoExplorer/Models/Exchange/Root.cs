using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoExplorer.Models.Exchange
{
    public class Root
    {
        [JsonProperty("markets")]
        public List<Market>? Markets { get; set; }

        [JsonProperty("next")]
        public string? Next { get; set; }
    }
}
