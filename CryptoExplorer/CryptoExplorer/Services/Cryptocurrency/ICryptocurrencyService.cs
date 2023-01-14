using CryptoExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExplorer.Services.Cryptocurrency
{
    public interface ICryptocurrencyService
    {
        Task<IEnumerable<Currency>> GetTopCurrenciesAsync();
    }
}
