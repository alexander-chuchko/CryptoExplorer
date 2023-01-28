using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CryptoExplorer.Controls
{
    public partial class CustomConverter : UserControl
    {
        public CustomConverter()
        {
            InitializeComponent();
        }

        #region   ---   Public properties   ---

        public static readonly DependencyProperty PointerAngleProperty =
            DependencyProperty.Register(
                nameof(PointerAngle),
                typeof(Rotation),
                typeof(CustomConverter),
                new PropertyMetadata(Rotation.Rotate0));

        public Rotation PointerAngle
        {
            get { return (Rotation)GetValue(PointerAngleProperty); }
            set { SetValue(PointerAngleProperty, value); }
        }

        public static readonly DependencyProperty CurrencyNameProperty =
            DependencyProperty.Register(
                nameof(CurrencyName),
                typeof(string),
                typeof(CustomConverter),
                new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnCurrencyNameChanged)));

        public string CurrencyName
        {
            get { return (string)GetValue(CurrencyNameProperty); }
            set { SetValue(CurrencyNameProperty, value); }
        }

        #endregion

        #region   ---   Private helpers   ---

        private static void OnCurrencyNameChanged(DependencyObject control, DependencyPropertyChangedEventArgs e)
        {
            if (control is CustomConverter customConverter)
            {
                customConverter.OnCurrencyName(e);
            }
        }

        private void OnCurrencyName(DependencyPropertyChangedEventArgs e)
        {
            nameCurrency.Text = (string)e.NewValue;
        }

        private void OnOpenList(object sender, MouseButtonEventArgs e)
        {
            arrowOpenOrClose.Source = GetBitmapImage("/images/up_arrow_light.png");
        }


        private BitmapImage GetBitmapImage(string path)
        {
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();

            myBitmapImage.UriSource = new Uri(path, UriKind.Relative);

            myBitmapImage.Rotation = PointerAngle = PointerAngle ==
                Rotation.Rotate0 ?
                Rotation.Rotate180 :
                Rotation.Rotate0;

            myBitmapImage.EndInit();

            return myBitmapImage;
        }

        #endregion
    }
}
