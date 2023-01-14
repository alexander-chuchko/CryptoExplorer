using Newtonsoft.Json;
using System.Collections.Generic;


namespace CryptoExplorer.Models
{
    public class ResponceMarket
    {
        [JsonProperty("timestamp")]
        public string? Timestamp { get; set; }

        [JsonProperty("data")]
        public IEnumerable<Market>? Currencies { get; set; }
    }
}
