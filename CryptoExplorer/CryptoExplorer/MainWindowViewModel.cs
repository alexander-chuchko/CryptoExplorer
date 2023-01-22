
using CryptoExplorer.Models;
using CryptoExplorer.Models.Menu;
using CryptoExplorer.Services.Cryptocurrency;
using CryptoExplorer.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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

        private IEnumerable<UserMenuViewModel>? _menuList;
        public IEnumerable<UserMenuViewModel>? MenuList
        {
            get { return _menuList; }
            set { SetProperty(ref _menuList, value); }
        }

        private UserMenuViewModel? _selectedParagraph;
        public UserMenuViewModel? SelectedParagraph
        {
            get { return _selectedParagraph; }
            set { SetProperty(ref _selectedParagraph, value); }
        }

        public ICommand OnLoadedCommand { get; }

        private ICommand _NavigateToPageCommand;
        public ICommand NavigateToPageCommand => _NavigateToPageCommand ?? (_NavigateToPageCommand = new DelegateCommand<object>(OnNavigateToPage));
        
        private ICommand _NavigateMainToPageCommand;
        public ICommand NavigateMainPageToCommand => _NavigateMainToPageCommand ?? (_NavigateMainToPageCommand = new DelegateCommand(OnNavigateToMainPage));

        public bool KeepAlive =>true;

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

        private void CreatingMenuItems()
        {
            var menu = new List<UserMenuViewModel>()
            {
              new UserMenuViewModel()
              {
                  Name = Constants.MAIN_ITEM, 
                  TextBackground = "#f8f5f5",
                  TextForeground = "#ff4064", 
                  ImageSource = "/Images/home_light.png"
              },
              new UserMenuViewModel()
              {
                  Name = Constants.DETAILS_ITEM, 
                  TextBackground =  Color.Transparent.ToString(), 
                  TextForeground = "#596EFB", 
                  ImageSource = "/Images/info_light.png"
              },
              new UserMenuViewModel()
              {
                  Name = Constants.CONVERTER_ITEM,
                  TextBackground = Color.Transparent.ToString(),
                  TextForeground = "#596EFB",
                  ImageSource = "/Images/convert_light.png"
              },
              new UserMenuViewModel()
              {
                  Name = Constants.SETTINGS_ITEM, 
                  TextBackground =  Color.Transparent.ToString(),
                  TextForeground = "#596EFB",
                  ImageSource = "/Images/settings_light.png"
              },
            };

            MenuList = menu;
        }

        public void OnNavigateToMainPage()
        {
            //IRegion mainRegion = _regionManager.Regions["ContentRegion"];
            //var view = _container.Resolve<MainPage>();
            //mainRegion.Add(view);
            CreatingMenuItems();
            OnGetCurrencies();

            _regionManager.RequestNavigate("ContentRegion", (nameof(MainPage)));
        }

        private void OnNavigateToPage(object parametr)
        {
            var namePage = parametr as string;
            
            if (!string.IsNullOrWhiteSpace(namePage))
            {
                switch (namePage)
                {
                    case Constants.MAIN_ITEM:
                        //var singleView = _regionManager.Regions["ContentRegion"].ActiveViews.FirstOrDefault();
                        _regionManager.RequestNavigate("ContentRegion", (nameof(MainPage)));
                        break;

                    case Constants.DETAILS_ITEM:
                        _regionManager.RequestNavigate("ContentRegion", (nameof(CurrencyDetailsPage)));
                        break;
                }
            }
        }

        private void ChangeItemColor()
        {
            var paragraph = MenuList?.Where(x => (x.TextBackground == "#f8f5f5" && x.TextForeground == "#ff4064"))?.FirstOrDefault();
                
            if (paragraph is not null)
            {
                paragraph.TextForeground = "#596EFB";
                paragraph.TextBackground = Color.Transparent.ToString();
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
            else if (args.PropertyName == nameof(SelectedParagraph)) 
            {
                if (SelectedParagraph is not null)
                {
                    ChangeItemColor();
                    SelectedParagraph.TextBackground = "#f8f5f5";
                    SelectedParagraph.TextForeground = "#ff4064";
                    OnNavigateToPage(SelectedParagraph.Name);
                }
            }
        }

        #endregion
    }
}
