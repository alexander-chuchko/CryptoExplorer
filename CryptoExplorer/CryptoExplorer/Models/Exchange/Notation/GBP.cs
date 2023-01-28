using Newtonsoft.Json;

namespace CryptoExplorer.Models.Exchange.Notation
{
    public class GBP
    {
        public GBP()
        {
            Name = nameof(GBP);
        }
        public string? Name { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("volume_24h")]
        public double Volume24h { get; set; }
    }
}
