using CryptoExplorer.Models;
using CryptoExplorer.Models.Exchange;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoExplorer.Services.Cryptocurrency
{
    public interface ICryptocurrencyService
    {
        Task<IEnumerable<Currency>> GetCurrenciesAsync();
        Task<IEnumerable<Models.Market>> GetMarketsAsync(string id);
        IEnumerable<Currency> GetFindedCurrencies(IEnumerable<Currency> currencies, string keyWord);

        Task<IEnumerable<Models.Exchange.Market>> GetExchangeRatesAsync();
    }
}
