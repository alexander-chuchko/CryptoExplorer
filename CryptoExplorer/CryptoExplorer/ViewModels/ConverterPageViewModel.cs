using CryptoExplorer.Models;
using CryptoExplorer.Services.Cryptocurrency;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CryptoExplorer.ViewModels
{
    public class ConverterPageViewModel : BindableBase
    {
        #region   ---    PrivateFields   ---

        private readonly ICryptocurrencyService _cryptocurrencyService;
        private readonly IRegionManager _regionManager;

        #endregion

        public ConverterPageViewModel(ICryptocurrencyService cryptocurrencyService, IRegionManager regionManager)
        {
            _cryptocurrencyService = cryptocurrencyService;
            _regionManager = regionManager;
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

        //ElementStatus
        private bool? _elementStatus = false;
        public bool? ElementStatus
        {
            get { return _elementStatus; }
            set { SetProperty(ref _elementStatus, value); }
        }

        #endregion

        #region --- Private helpers ---

        private async void OnGetCurrencies()
        {
            СurrencyList = await _cryptocurrencyService.GetTopCurrenciesAsync();

            if (СurrencyList is not null && СurrencyList.Count() > 0)
            {

            }
        }

        #endregion

        #region     --- Override ---

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
            
            if (args.PropertyName == nameof(Currency))
            {
                ElementStatus = true;
            }
        }

        #endregion
    }
}
