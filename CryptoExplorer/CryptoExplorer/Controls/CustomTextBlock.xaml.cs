using CryptoExplorer.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CryptoExplorer.Controls
{
    public partial class CustomTextBlock : UserControl
    {
        public CustomTextBlock()
        {
            InitializeComponent();
        }

        #region   ---   Public properties   ---

        public static readonly DependencyProperty SetTextProperty =
            DependencyProperty.Register(
                nameof(SetText),
                typeof(string),
                typeof(CustomTextBlock),
                new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnSetTextChanged)));

        public string SetText
        {
            get { return (string)GetValue(SetTextProperty); }
            set { SetValue(SetTextProperty, value); }
        }

        public static readonly DependencyProperty SetListProperty =
            DependencyProperty.Register(
                nameof(SetList),
                typeof(IEnumerable<Currency>),
                typeof(CustomTextBlock),
                new PropertyMetadata(null, new PropertyChangedCallback(OnSetListChanged)));

        public IEnumerable<Currency> SetList
        {
            get { return (IEnumerable<Currency>)GetValue(SetTextProperty); }
            set { SetValue(SetTextProperty, value); }
        }

        public static readonly DependencyProperty SelectedCurrencyProperty =
            DependencyProperty.Register(
                nameof(SelectedCurrency),
                typeof(Currency),
                typeof(CustomTextBlock),
                new PropertyMetadata(null));

        public Currency SelectedCurrency
        {
            get { return (Currency)GetValue(SelectedCurrencyProperty); }
            set { SetValue(SelectedCurrencyProperty, value); }
        }

        #endregion


        #region   ---   Private helpers   ---

        private static void OnSetTextChanged(DependencyObject control, DependencyPropertyChangedEventArgs e)
        {
            if (control is CustomTextBlock customTextBlock)
            {
                customTextBlock.OnSetText(e);
            }
        }
        private void OnSetText(DependencyPropertyChangedEventArgs e)
        {
            titleTextBlock.Text = (string)e.NewValue;
        }

        private static void OnSetListChanged(DependencyObject control, DependencyPropertyChangedEventArgs e)
        {
            if (control is CustomTextBlock customTextBlock)
            {
                customTextBlock.OnSetList(e);
            }
        }

        private void OnSetList(DependencyPropertyChangedEventArgs e)
        {
            stringSheet.ItemsSource = (IEnumerable<Currency>)e.NewValue;
        }

        private void OnSelectedElement(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            SelectedCurrency = (Currency)listBox.SelectedItem;

        }

        #endregion
    }
}
