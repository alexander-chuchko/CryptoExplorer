
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

        public ICommand OnLoadedCommand { get; }

        public bool KeepAlive =>false;

        public void OnLoaded()
        {
            //IRegion mainRegion = _regionManager.Regions["ContentRegion"];
            //var view = _container.Resolve<MainPage>();
            //mainRegion.Add(view);

            _regionManager.RequestNavigate("ContentRegion", (nameof(MainPage)));
            //_regionManager.RequestNavigate(RegionNames.AuthContentRegion, NavigationPaths.RailwayListPath);
        }
    }
}
