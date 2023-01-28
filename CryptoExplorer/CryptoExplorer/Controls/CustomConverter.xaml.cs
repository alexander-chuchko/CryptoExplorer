using CryptoExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                new PropertyMetadata(string.Empty));
        //new PropertyChangedCallback(OnSetTextChanged))

        public string CurrencyName
        {
            get { return (string)GetValue(CurrencyNameProperty); }
            set { SetValue(CurrencyNameProperty, value); }
        }

        #endregion

        #region   ---   Private helpers   ---
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
