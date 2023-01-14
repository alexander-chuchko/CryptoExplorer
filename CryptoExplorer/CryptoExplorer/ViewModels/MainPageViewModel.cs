using CryptoExplorer.Models;
using CryptoExplorer.Services.Cryptocurrency;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoExplorer.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        #region   ---    PrivateFields   ---

        private readonly ICryptocurrencyService? _cryptocurrencyService;

        #endregion
        public MainPageViewModel(ICryptocurrencyService? cryptocurrencyService)
        {
            _cryptocurrencyService = cryptocurrencyService;
            OnGetCurrencies();
        }

        #region   ---   PublicProperties   ---

        private IEnumerable<Currency>? _currencyList;
        public IEnumerable<Currency>? СurrencyList
        {
            get { return _currencyList; }
            set { SetProperty(ref _currencyList, value); }
        }

        private Currency? _currency;
        public Currency? Currency
        {
            get { return _currency; }
            set { SetProperty(ref _currency, value); }
        }

        private ICommand _GetGetCurrenciesCommand;
        public ICommand GetGetCurrenciesCommand => _GetGetCurrenciesCommand ?? new DelegateCommand(OnGetCurrencies);


        #endregion

        #region --- Private helpers ---

        private async void OnGetCurrencies()
        {
            if (_cryptocurrencyService is not null)
            {
                СurrencyList = await _cryptocurrencyService.GetTopCurrenciesAsync();//.GetAwaiter().GetResult();
            }
        }

        #endregion

        #region     --- Override ---
        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);

            if (args.PropertyName == nameof(Currency))
            {
                //ShowRelevantPins();
            }
        }

        #endregion

    }
}
