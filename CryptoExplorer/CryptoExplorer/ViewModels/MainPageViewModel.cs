using CryptoExplorer.Models;
using CryptoExplorer.Services.Cryptocurrency;
using CryptoExplorer.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace CryptoExplorer.ViewModels
{
    public class MainPageViewModel : BindableBase, IRegionMemberLifetime
    {
        #region   ---    PrivateFields   ---

        private readonly ICryptocurrencyService _cryptocurrencyService;
        private readonly IRegionManager _regionManager;

        #endregion

        public MainPageViewModel(ICryptocurrencyService? cryptocurrencyService, IRegionManager regionManager)
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

        private IEnumerable<Currency>? _currencyAllList;
        public IEnumerable<Currency>? CurrencyAllList
        {
            get { return _currencyAllList; }
            set { SetProperty(ref _currencyAllList, value); }
        }

        private Currency? _currency;
        public Currency? Currency
        {
            get { return _currency; }
            set { SetProperty(ref _currency, value); }
        }

        private string? _serachText;
        public string? SearchText
        {
            get { return _serachText; }
            set { SetProperty(ref _serachText, value); }
        }

        private ICommand _GetGetCurrenciesCommand;
        public ICommand GetGetCurrenciesCommand => _GetGetCurrenciesCommand ?? new DelegateCommand(OnGetCurrencies);

        public bool KeepAlive => false;


        #endregion

        #region --- Private helpers ---


        private async void OnGetCurrencies()
        {
            CurrencyAllList = await _cryptocurrencyService.GetTopCurrenciesAsync();
            
            if (CurrencyAllList is not null && CurrencyAllList.Count() > 0) 
            {
                СurrencyList = CurrencyAllList.Take(Constants.NUMBER_OF_DISPLAYED_CURRENCIES);
            }
        }

        #endregion

        #region     --- Override ---
        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);

            if (args.PropertyName == nameof(Currency))
            {
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add(nameof(Currency), Currency);
                _regionManager.RequestNavigate(Constants.CONTENT_REGION, nameof(CurrencyDetailsPage), navigationParameters);
            }
            else if (args.PropertyName == nameof(SearchText))
            {
                if (string.IsNullOrEmpty(SearchText))
                {
                    СurrencyList = CurrencyAllList?.Take(Constants.NUMBER_OF_DISPLAYED_CURRENCIES);
                }
                else
                {
                    if (CurrencyAllList is not null && SearchText is not null)
                    {
                        var findedCurrencies = _cryptocurrencyService?.GetFindedCurrencies(CurrencyAllList, SearchText);
                        СurrencyList = findedCurrencies;
                    }
                }
            }
        }

        #endregion

    }
}
