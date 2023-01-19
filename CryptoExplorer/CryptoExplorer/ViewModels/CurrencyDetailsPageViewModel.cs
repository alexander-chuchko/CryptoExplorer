using CryptoExplorer.Models;
using CryptoExplorer.Services.SettingsManager;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Diagnostics;
using System.Windows.Input;

namespace CryptoExplorer.ViewModels
{
    public class CurrencyDetailsPageViewModel : BindableBase, INavigationAware
    {
        #region   ---    PrivateFields   ---

        private IRegionNavigationService _navigationService;
        private readonly ISettingsManager _settingsManager;

        #endregion

        public CurrencyDetailsPageViewModel(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }


        #region   ---   PublicProperties   ---

        private Currency? _currency;
        public Currency? Currency
        {
            get { return _currency; }
            set { SetProperty(ref _currency, value); }
        }

        private string? _name;
        public string? Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string? _supply;
        public string? Supply
        {
            get { return _supply; }
            set { SetProperty(ref _supply, value); }
        }

        private string? _maxSupply;
        public string? MaxSupply
        {
            get { return _maxSupply; }
            set { SetProperty(ref _maxSupply, value); }
        }

        private string? _marketCapUsd;
        public string? MarketCapUsd
        {
            get { return _marketCapUsd; }
            set { SetProperty(ref _marketCapUsd, value); }
        }

        private string? _rank;
        public string? Rank
        {
            get { return _rank; }
            set { SetProperty(ref _rank, value); }
        }

        private string? _volumeUsd24Hr;
        public string? VolumeUsd24Hr
        {
            get { return _volumeUsd24Hr; }
            set { SetProperty(ref _volumeUsd24Hr, value); }
        }

        private string? _priceUsd;
        public string? PriceUsd
        {
            get { return _priceUsd; }
            set { SetProperty(ref _priceUsd, value); }
        }

        private string? _changePercent24Hr;
        public string? ChangePercent24Hr
        {
            get { return _changePercent24Hr; }
            set { SetProperty(ref _changePercent24Hr, value); }
        }

        private string? _vwap24Hr;
        public string? Мwap24Hr
        {
            get { return _vwap24Hr; }
            set { SetProperty(ref _vwap24Hr, value); }
        }

        private string? _explorer;
        public string? Explorer
        {
            get { return _explorer; }
            set { SetProperty(ref _explorer, value); }
        }

        private ICommand _GoBackCommand;
        public ICommand GoBackCommand => _GoBackCommand ?? new DelegateCommand(OnGoBackCommand);

        private ICommand _FollowTheLinkCommand;
        public ICommand FollowTheLinkCommand => _FollowTheLinkCommand ?? new DelegateCommand<object>(OnFollowTheLink);

        #endregion

        #region --- Private helpers ---

        private void OnGoBackCommand()
        {
            if (_navigationService.Journal.CanGoBack)
            {
                _navigationService.Journal.GoBack();
            }
        }

        private void OnChangeTheme()
        {
            /*
                             if (_settingsManager.IsDarkTheme)
                {
                    _settingsManager.IsDarkTheme = false;
                }
                OnChangeTheme();
             */
            _settingsManager.IsDarkTheme = true;
        }

        private void InitializationData(Currency currency)
        {
            if (currency is not null)
            {
                Name = $"Price statistics {currency.Name}";
                PriceUsd = OnReplacingValue(currency.PriceUsd);
                Rank = OnReplacingValue(currency.Rank);
                VolumeUsd24Hr = OnReplacingValue(currency.VolumeUsd24Hr);
                Supply = OnReplacingValue(currency.Supply);
                MaxSupply = OnReplacingValue(currency.MaxSupply);
                MarketCapUsd = OnReplacingValue(currency.MarketCapUsd);
                ChangePercent24Hr = OnReplacingValue(currency.ChangePercent24Hr);
                Мwap24Hr = OnReplacingValue(currency.Vwap24Hr);
                Explorer = OnReplacingValue(currency.Explorer);
            }
        }

        private string OnReplacingValue(string ? parametr)
        {
            return !string.IsNullOrEmpty(parametr) ? parametr : "-";
        }

        private void OnFollowTheLink(object parametr)
        {
            if (parametr is string url)
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }

        #endregion

        #region      ---  Iterface INavigatedAware implementation   ---

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {   
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationService = navigationContext.NavigationService;

            Currency = (Currency)navigationContext.Parameters[nameof(Currency)];

            InitializationData(Currency);

        }

        #endregion
    }
}
