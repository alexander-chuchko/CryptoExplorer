using CryptoExplorer.Models.Exchange.Notation;
using Newtonsoft.Json;

namespace CryptoExplorer.Models.Exchange
{
    public class Quote
    {
        [JsonProperty("NZD")]
        public NZD? NZD { get; set; }

        [JsonProperty("GBP")]
        public GBP? GBP { get; set; }

        [JsonProperty("EUR")]
        public EUR? EUR { get; set; }

        [JsonProperty("CAD")]
        public CAD? CAD { get; set; }

        [JsonProperty("AUD")]
        public AUD? AUD { get; set; }

        [JsonProperty("USD")]
        public USD? USD { get; set; }

        [JsonProperty("JPY")]
        public JPY? JPY { get; set; }
    }
}
