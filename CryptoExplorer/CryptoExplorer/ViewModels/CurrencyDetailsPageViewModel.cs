
using CryptoExplorer.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Linq;

namespace CryptoExplorer.ViewModels
{
    public class CurrencyDetailsPageViewModel : BindableBase, INavigationAware
    {
        private IRegionNavigationService _navigationService;

        public CurrencyDetailsPageViewModel()
        {

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
