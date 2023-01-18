using CryptoExplorer.Models;
using CryptoExplorer.Services.Cryptocurrency;
using CryptoExplorer.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace CryptoExplorer.ViewModels
{
    public class MainPageViewModel : BindableBase, IRegionMemberLifetime
    {
        #region   ---    PrivateFields   ---

        private readonly ICryptocurrencyService? _cryptocurrencyService;
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
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add(nameof(Currency), Currency);
                _regionManager.RequestNavigate(Constants.CONTENT_REGION, nameof(CurrencyDetailsPage), navigationParameters);
            }
            else if (args.PropertyName == nameof(SearchText))
            {
                
            }
        }

        #endregion

    }
}
