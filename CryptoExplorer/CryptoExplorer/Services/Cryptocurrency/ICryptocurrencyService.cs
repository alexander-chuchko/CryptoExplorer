using CryptoExplorer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoExplorer.Services.Cryptocurrency
{
    public interface ICryptocurrencyService
    {
        Task<IEnumerable<Currency>> GetCurrenciesAsync();
        Task<IEnumerable<Market>> GetMarketsAsync(string id);
        IEnumerable<Currency> GetFindedCurrencies(IEnumerable<Currency> currencies, string keyWord);

        Task<IEnumerable<Currency>> GetExchangeRatesAsync();
    }
}
