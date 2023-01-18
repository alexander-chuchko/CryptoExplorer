using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// Interaction logic for CustomTextBlock.xaml
    /// </summary>
    public partial class CustomTextBlock : UserControl
    {
        public CustomTextBlock()
        {
            InitializeComponent();
            //this.DataContext = this;
        }
        /*
        public ICommand SettingsTapCommand
        {
            get => (ICommand)GetValue(SettingsTapCommandProperty);
            set => SetValue(SettingsTapCommandProperty, value);
        }

        public bool IsCheckable
        {
            get { return (bool)GetValue(IsCheckableProperty); }
            set { SetValue(IsCheckableProperty, value); }
        }*/

        public static readonly DependencyProperty SetTextProperty =
            DependencyProperty.Register(
                nameof(SetText),
                typeof(string),
                typeof(CustomTextBlock),
                new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnSetTextChanged)));

        private static void OnSetTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is CustomTextBlock customTextBlock)
            {
                customTextBlock.OnSetText(e);
            }
        }

        public string SetText
        {
            get { return (string)GetValue(SetTextProperty); }
            set { SetValue(SetTextProperty, value); }
        }

        private void OnSetText(DependencyPropertyChangedEventArgs e)
        {
            MyTextBlock.Text = (string)e.NewValue;
        }

    }
}
