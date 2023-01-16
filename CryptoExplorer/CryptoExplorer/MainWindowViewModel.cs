
using CryptoExplorer.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows.Input;

namespace CryptoExplorer
{
    public class MainWindowViewModel : BindableBase, IRegionMemberLifetime
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _container;


        public MainWindowViewModel(IRegionManager regionManager, IContainerExtension container)
        {
            _regionManager = regionManager;
            this._container = container;
            OnLoadedCommand = new DelegateCommand(OnLoaded);
        }

        #region   ---   PublicProperties   ---

        public ICommand OnLoadedCommand { get; }

        private ICommand _NavigateCurrencyDetailsPageCommand;
        public ICommand NavigateCurrencyDetailsPageCommand => _NavigateCurrencyDetailsPageCommand ?? (_NavigateCurrencyDetailsPageCommand = new DelegateCommand<object>(OnNavigateToCurrencyDetailsPage));

        public bool KeepAlive =>false;

        #endregion

        #region --- Private helpers ---
        public void OnLoaded()
        {
            //IRegion mainRegion = _regionManager.Regions["ContentRegion"];
            //var view = _container.Resolve<MainPage>();
            //mainRegion.Add(view);

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
    }
}
