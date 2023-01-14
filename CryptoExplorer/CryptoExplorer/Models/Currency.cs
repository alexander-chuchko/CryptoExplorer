
using Newtonsoft.Json;

namespace CryptoExplorer.Models
{
    public class Currency
    {
        [JsonProperty("id")]
        public string? CurrencyId { get; set; }

        [JsonProperty("rank")]
        public string? Rank { get; set; }

        [JsonProperty("symbol")]
        public string? Symbol { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("maxSupply")]
        public string? MaxSupply { get; set; }

        [JsonProperty("marketCapUsd")]
        public string? MarketCapUsd { get; set; }

        [JsonProperty("volumeUsd24Hr")]
        public string? VolumeUsd24Hr { get; set; }

        [JsonProperty("priceUsd")]
        public string? PriceUsd { get; set; }

        [JsonProperty("changePercent24Hr")]
        public string? ChangePercent24Hr { get; set; }

        [JsonProperty("vwap24Hr")]
        public string? Vwap24Hr { get; set; }

        [JsonProperty("explorer")]
        public string? Explorer { get; set; }

    }
}
