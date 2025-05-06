using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace CurrencyConverter
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, double> currencyRates = new Dictionary<string, double>()
        {
            { "USD", 90 },
            { "EUR", 97 },
            { "CNY", 12 }
        };

        public MainWindow()
        {
            InitializeComponent();
            cmbCurrency.SelectedIndex = 0; 
        }

        
        private void ConvertCurrency()
        {
            if (double.TryParse(txtRubles.Text, out double rubles) &&
                cmbCurrency.SelectedItem is ComboBoxItem selectedCurrency)
            {
                string currency = selectedCurrency.Content.ToString();
                double rate = currencyRates[currency];
                double result = rubles / rate;
                txtResult.Text = $"{result:F2} {currency}";
            }
            else
            {
                txtResult.Text = "Ошибка ввода";
            }
        }
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            ConvertCurrency();
        }

        private void txtRubles_TextChanged(object sender, TextChangedEventArgs e)
        {
            ConvertCurrency(); 
        }
        
        private void cmbCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertCurrency(); // Автоматическое обновление (доп. задание)
        }
    }
}