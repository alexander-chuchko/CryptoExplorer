using Prism.Mvvm;

namespace CryptoExplorer.Models.Menu
{
    public class UserMenuViewModel : BindableBase
    {
        private string? _textForeground;
        public string? TextForeground
        {
            get { return _textForeground; }
            set { SetProperty(ref _textForeground, value); }
        }

        private string? _name;
        public string? Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string? _textBackground;
        public string? TextBackground
        {
            get { return _textBackground; }
            set { SetProperty(ref _textBackground, value); }
        }

        private string? _imageSource;
        public string? ImageSource
        {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
        }
    }
}
