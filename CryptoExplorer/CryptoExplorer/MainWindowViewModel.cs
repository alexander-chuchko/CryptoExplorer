
using CryptoExplorer.Models;
using CryptoExplorer.Services.Cryptocurrency;
using CryptoExplorer.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;

namespace CryptoExplorer
{
    public class MainWindowViewModel : BindableBase, IRegionMemberLifetime
    {
        #region   ---    PrivateFields   ---

        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _container;
        private readonly ICryptocurrencyService _cryptocurrencyService;


        #endregion

        public MainWindowViewModel(IRegionManager regionManager, IContainerExtension container, ICryptocurrencyService cryptocurrencyService)
        {
            _regionManager = regionManager;
            _container = container;
            _cryptocurrencyService = cryptocurrencyService;

            //OnLoadedCommand = new DelegateCommand(OnLoaded);

        }

        #region   ---   PublicProperties   ---

        private string? _text = "Popular coins";
        public string? Text1
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private Currency? _currency;
        public Currency? Currency
        {
            get { return _currency; }
            set { SetProperty(ref _currency, value); }
        }


        private IEnumerable<Currency>? _currencyList;
        public IEnumerable<Currency>? СurrencyList
        {
            get { return _currencyList; }
            set { SetProperty(ref _currencyList, value); }
        }


        public ICommand OnLoadedCommand { get; }

        private ICommand _NavigateCurrencyDetailsPageCommand;
        public ICommand NavigateCurrencyDetailsPageCommand => _NavigateCurrencyDetailsPageCommand ?? (_NavigateCurrencyDetailsPageCommand = new DelegateCommand<object>(OnNavigateToCurrencyDetailsPage));

        private ICommand _NavigateMainPageCommand;
        public ICommand NavigateMainPageCommand => _NavigateMainPageCommand ?? (_NavigateMainPageCommand = new DelegateCommand<object>(OnNavigateToCurrencyDetailsPage));

        private ICommand _BackTapCommand;
        public ICommand BackTapCommand => _BackTapCommand ?? (_BackTapCommand = new DelegateCommand<object>(OnNavigateToCurrencyDetailsPage));

        public bool KeepAlive =>false;

        #endregion

        #region --- Private helpers ---


        private async void OnGetCurrencies()
        {
            if (_cryptocurrencyService is not null)
            {
                var getedCollection = await _cryptocurrencyService.GetTopCurrenciesAsync();//.GetAwaiter().GetResult();

                if (getedCollection is not null && getedCollection.Count() != 0)
                {
                    СurrencyList = getedCollection.Take(3);
                }
            }
        }
        public void OnLoaded()
        {
            //IRegion mainRegion = _regionManager.Regions["ContentRegion"];
            //var view = _container.Resolve<MainPage>();
            //mainRegion.Add(view);
            OnGetCurrencies();

            _regionManager.RequestNavigate("ContentRegion", (nameof(MainPage)));

        }

        private void OnNavigateToCurrencyDetailsPage(object parametr)
        {
            var namePage = parametr as string;
            
            if (!string.IsNullOrWhiteSpace(namePage))
            {
                switch (namePage)
                {
                    case nameof(CurrencyDetailsPage):
                        _regionManager.RequestNavigate("ContentRegion", (nameof(CurrencyDetailsPage)));
                        break;
                }
            }
        }

        #endregion

        #region     --- Override ---
        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);

            if (args.PropertyName == nameof(Currency))
            {
                //var navigationParameters = new NavigationParameters();
                //navigationParameters.Add(nameof(Currency), Currency);
                //_regionManager.RequestNavigate(Constants.CONTENT_REGION, nameof(CurrencyDetailsPage), navigationParameters);
            }
        }

        #endregion
    }
}
