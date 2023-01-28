using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExplorer.Models.Exchange
{
    public class Market
    {
        [JsonProperty("quote")]
        public Quote? Quote { get; set; }

        [JsonProperty("exchange_id")]
        public string? ExchangeId { get; set; }

        [JsonProperty("symbol")]
        public string? Symbol { get; set; }

        [JsonProperty("base_asset")]
        public string? BaseAsset { get; set; }

        [JsonProperty("quote_asset")]
        public string? QuoteAsset { get; set; }

        [JsonProperty("price_unconverted")]
        public string? PriceUnconverted { get; set; }

        [JsonProperty("price")]
        public string? Price { get; set; }

        [JsonProperty("change_24h")]
        public string? Change24h { get; set; }

        [JsonProperty("spread")]
        public string? Spread { get; set; }

        [JsonProperty("volume_24h")]
        public string? Volume24h { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("created_at")]
        public string? CreatedAt { get; set; }
        
        [JsonProperty("updated_at")]
        public string? UpdatedAt { get; set; }
    }
}
