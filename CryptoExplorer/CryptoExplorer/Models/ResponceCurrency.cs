using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoExplorer.Models
{
    public class ResponceCurrency
    {
        [JsonProperty("timestamp")]
        public string? Timestamp { get; set; }

        [JsonProperty("data")]
        public IEnumerable<Currency>? Currencies { get; set; }
    }
}
