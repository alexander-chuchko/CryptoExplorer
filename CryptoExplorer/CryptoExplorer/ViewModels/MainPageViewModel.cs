using CryptoExplorer.Services.Cryptocurrency;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoExplorer.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly ICryptocurrencyService _cryptocurrencyService;
        public MainPageViewModel(ICryptocurrencyService cryptocurrencyService)
        {
            _cryptocurrencyService = cryptocurrencyService; 
        }

        private ICommand _GetGetCurrenciesCommand;
        public ICommand GetGetCurrenciesCommand => _GetGetCurrenciesCommand ?? new DelegateCommand(OnGetCurrencies);

        private void OnGetCurrencies()
        {
            var res =  _cryptocurrencyService.GetTopCurrenciesAsync();
        }

        //private ICommand _NavigationToGoBackCommand;
        //public ICommand NavigationToGoBackCommand => _NavigationToGoBackCommand ?? (_NavigationToGoBackCommand = new DelegateCommand<string>(OnNavigationToGoBack));
    }
}
