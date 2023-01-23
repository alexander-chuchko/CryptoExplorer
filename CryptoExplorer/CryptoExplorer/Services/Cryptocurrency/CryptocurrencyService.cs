using CryptoExplorer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CryptoExplorer.Services.Cryptocurrency
{
    public class CryptocurrencyService : ICryptocurrencyService
    {
        public const string WEB_API_CURRENCIES = $"?poloniex=Binance&limit="; //Currencies
        public const string WEB_API_MARKETS = $"/markets?limit="; //api.coincap.io/v2/assets/bitcoin10
        //public const string WEB_API_EXCHANGES = $"/markets";

        private HttpClient _client;
        private HttpClient _client1;

        public CryptocurrencyService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Constants.BASE_URL_ONE);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add(Constants.API_NAME, Constants.API_KEY);

            _client1 = new HttpClient();
            //_client1.BaseAddress = new Uri(Constants.BASE_URL_TWO);

        }
        public async Task<IEnumerable<Currency>> GetCurrenciesAsync()
        {
            IEnumerable<Currency>? сurrencies = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{WEB_API_CURRENCIES}{Constants.LIMIT_CURRENCIES}");

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



        public async Task<IEnumerable<Market>> GetMarketsAsync(string id)
        {
            IEnumerable<Market>? markets = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync($"assets/{id}{WEB_API_MARKETS}{Constants.LIMIT_MARKETS}");

                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    var responceMarket = await response.Content.ReadAsStringAsync();
                    var deserializedResponceCurrency = JsonConvert.DeserializeObject<ResponceMarket>(responceMarket);

                    markets = deserializedResponceCurrency?.Currencies?.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return markets;
        }

        public IEnumerable<Currency> GetFindedCurrencies(IEnumerable<Currency> currencies, string keyWord)
        {
            IEnumerable<Currency>? selectedCurrencies = null;

            try
            {
                if (!string.IsNullOrWhiteSpace(keyWord))
                {
                    selectedCurrencies = currencies.Where(x => (x.Name.StartsWith(keyWord, StringComparison.OrdinalIgnoreCase) && x.Name.Contains(keyWord)) || 
                    (x.Symbol.StartsWith(keyWord, StringComparison.OrdinalIgnoreCase) && x.Symbol.Contains(keyWord))).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return selectedCurrencies;
        }

        public async Task<IEnumerable<Currency>> GetExchangeRatesAsync()
        {
            IEnumerable<Currency>? сurrencies = null;

            try
            {
                HttpResponseMessage response = await _client1.GetAsync($"https://cryptingup.com/api/markets");

                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    var responceCurrency = await response.Content.ReadAsStringAsync();
                    var deserializedResponceCurrency = JsonConvert.DeserializeObject<ExchangeRate>(responceCurrency);

                    //сurrencies = deserializedResponceCurrency?.Currencies?.ToList();
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
