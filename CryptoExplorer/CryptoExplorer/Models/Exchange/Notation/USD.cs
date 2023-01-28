
using Newtonsoft.Json;

namespace CryptoExplorer.Models.Exchange.Notation
{
    public class USD
    {
        public USD()
        {
            Name = nameof(USD);
        }
        public string? Name { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("volume_24h")]
        public double Volume24h { get; set; }
    }
}
