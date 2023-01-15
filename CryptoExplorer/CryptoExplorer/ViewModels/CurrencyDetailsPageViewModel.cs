using CryptoExplorer.Models;
using CryptoExplorer.Services.SettingsManager;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
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


        private ICommand _GoBackCommand;
        public ICommand GoBackCommand => _GoBackCommand ?? new DelegateCommand(OnGoBackCommand);

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
        }

        #endregion
    }
}
