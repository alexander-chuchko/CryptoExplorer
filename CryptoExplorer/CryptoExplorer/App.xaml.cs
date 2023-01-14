using CryptoExplorer.Services.Cryptocurrency;
using CryptoExplorer.ViewModels;
using CryptoExplorer.Views;
using Prism.Ioc;
//using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

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
            containerRegistry.Register<ICryptocurrencyService, CryptocurrencyService>();
            //Registering pages
            //containerRegistry.RegisterForNavigation<CurrencyOverviewPage, CurrencyOverviewPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CurrencyDetailsPage, CurrencyDetailsPageViewModel>();
        }

        #endregion
    }
}
