using CryptoExplorer.ViewModels;
using CryptoExplorer.Views;
using Prism.Ioc;
//using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace CryptoExplorer
{
    public partial class App : PrismApplication
    {
        #region  ---   Overrides   ---

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Registering services

            //Registering pages
            //containerRegistry.RegisterForNavigation<CurrencyDetailsPage, CurrencyDetailsPageViewModel>();
            //containerRegistry.RegisterForNavigation<CurrencyOverviewPage, CurrencyOverviewPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }

        #endregion
    }
}
