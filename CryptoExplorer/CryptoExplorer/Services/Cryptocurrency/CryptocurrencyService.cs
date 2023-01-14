using CryptoExplorer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoExplorer.Services.Cryptocurrency
{
    public class CryptocurrencyService : ICryptocurrencyService
    {
        public const string WEB_API = $"assets?poloniex=Binance&limit=";
        //public const string BASE_URL = "https://api.coincap.io/v2/";
        string _apiKey = $"";

        private HttpClient _client;
        public CryptocurrencyService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Constants.BASE_URL);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add(Constants.API_NAME, Constants.API_KEY);

        }
        public async Task<IEnumerable<Currency>> GetTopCurrenciesAsync()
        {
            IEnumerable<Currency>? сurrencies = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{WEB_API}{Constants.LIMIT_CURRENCIES}");

                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    var responceCurrency = await response.Content.ReadAsStringAsync();
                    var deserializedResponceCurrency = JsonConvert.DeserializeObject<ResponceCurrency>(responceCurrency);

                    сurrencies = deserializedResponceCurrency?.Currencies?.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return сurrencies;
        }
    }
}
