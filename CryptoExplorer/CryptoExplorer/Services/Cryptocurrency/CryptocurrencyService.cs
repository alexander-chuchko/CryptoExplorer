using CryptoExplorer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExplorer.Services.Cryptocurrency
{
    public class CryptocurrencyService : ICryptocurrencyService
    {
        public const string WEB_API = "markets";
        public const string BASE_URL = "https://api.coincap.io/v2/";
        public const string API_KEY = "34d7b96b-dafd-4c0f-88fb-6d588ea564ff";
        private HttpClient _client;
        public CryptocurrencyService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(BASE_URL);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("apikey",API_KEY);

        }
        public async Task<IEnumerable<Currency>> GetTopCurrenciesAsync(int limit = 0)
        {
            List<Currency> collection = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(WEB_API);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var responceCurrency = await response.Content.ReadAsStringAsync();
                        //var deserializedResponceCurrency = 
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return collection;
        }
    }
}
