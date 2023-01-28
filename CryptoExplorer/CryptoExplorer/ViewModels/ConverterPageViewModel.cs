using CryptoExplorer.Models;
using CryptoExplorer.Models.Exchange;
using CryptoExplorer.Services.Cryptocurrency;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
            Task.Run(()=> OnGetCurrencies());
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

        private IEnumerable<string> _baseAssets;
        public IEnumerable<string> BaseAssets
        {
            get { return _baseAssets; }
            set { SetProperty(ref _baseAssets, value); }
        }

        private IEnumerable<Models.Exchange.Market> _markets;
        public IEnumerable<Models.Exchange.Market> Markets
        {
            get { return _markets; }
            set { SetProperty(ref _markets, value); }
        }


        private IEnumerable<string> _currencyNames;
        public IEnumerable<string> CurrencyNames
        {
            get { return _currencyNames; }
            set { SetProperty(ref _currencyNames, value); }
        }

        private string? _cryptocurrencyName;
        public string? CryptocurrencyName
        {
            get { return _cryptocurrencyName; }
            set { SetProperty(ref _cryptocurrencyName, value); }
        }

        private string? _currencyName;
        public string? CurrencyName
        {
            get { return _currencyName; }
            set { SetProperty(ref _currencyName, value); }
        }


        //CryptocurrencyName

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
            СurrencyList = await _cryptocurrencyService.GetCurrenciesAsync();
            IEnumerable<Models.Exchange.Market> markets = await _cryptocurrencyService.GetExchangeRatesAsync();
            var res = markets.ToList()[0];

            BaseAssets = markets.Select(x => x.BaseAsset).ToList();

            //var res1 = markets.Where(x=>x.)

            CurrencyNames = typeof(Quote).GetProperties().Select(x=>x.Name);

        }

        #endregion

        #region     --- Override ---

        protected override async void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
            
            if (args.PropertyName == nameof(Currency))
            {
                var res = await _cryptocurrencyService.GetExchangeRatesAsync();
                ElementStatus = true;
            }
        }

        #endregion
    }
}
