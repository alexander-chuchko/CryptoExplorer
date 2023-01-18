using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CryptoExplorer.Controls
{
    public partial class CustomSearchBar : UserControl
    {
        public CustomSearchBar()
        {
            InitializeComponent();
        }

        #region   ---   Public properties   ---

        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register(
                nameof(SearchText),
                typeof(string),
                typeof(CustomSearchBar),
                new PropertyMetadata(string.Empty));

        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }


        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register(
                nameof(ImagePath),
                typeof(string),
                typeof(CustomSearchBar),
                new PropertyMetadata(Constants.SEARCH_LIGHT));

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        #endregion


        #region   ---   Private helpers   ---

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                var newText = textBox.Text;

                if (!string.IsNullOrEmpty(newText) && newText.Length > 0)
                {
                    SearchText = newText;
                    imageButton.Source = GetBitmapImage(Constants.CLEAR_LIGHT);

                }
                else
                {
                    imageButton.Source = GetBitmapImage(Constants.SEARCH_LIGHT);
                }
            }
        }

        private void OnClickImage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (SearchText.Length > 0)
            {
                searchBar.Text = string.Empty;
            }
        }

        private BitmapImage GetBitmapImage(string path)
        {
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();

            myBitmapImage.UriSource = new Uri(path, UriKind.Relative);

            myBitmapImage.EndInit();

            return myBitmapImage;
        }

        #endregion
    }
}
