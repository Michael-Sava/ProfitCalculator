using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProfitCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculations calculations;

        public MainWindow()
        {
            InitializeComponent();

            this.calculations = new Calculations();
        }




        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox textBox in FindVisualChildren<TextBox>(TheWindow))
            {
                textBox.Clear();
            }
        }

        private void Btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(TxtBox_Units_bought.Text.Replace(".",","), out double Units);
            double.TryParse(TxtBox_Buy_price.Text.Replace(".", ","), out double BuyPrice);
            double.TryParse(TxtBox_Sell_Price.Text.Replace(".", ","), out double SellPrice);
            double.TryParse(TxtBox_BuyCommission.Text.Replace(".", ","), out double BuyCommission);
            double.TryParse(TxtBox_SellCommission.Text.Replace(".", ","), out double SellCommission);
            double.TryParse(TxtBox_TaxPerc.Text.Replace(".", ","), out double TaxPerc);

            
            TxtBox_TotalBuyPrice.Text = Math.Round((calculations.CalculateBuyCost(BuyPrice, (BuyCommission / 100)) * Units), 2).ToString();
            TxtBox_TotalSellPrice.Text = Math.Round((calculations.CalculateSellCost(SellPrice, (SellCommission / 100)) * Units), 2).ToString();
            TxtBox_Profit.Text = Math.Round((calculations.CalculateProfit(BuyPrice, SellPrice, (SellCommission / 100), (BuyCommission / 100)) * Units), 2).ToString();
            TxtBox_ProfitPerc.Text = Math.Round((calculations.CalculateProfitPercent(BuyPrice, SellPrice,(SellCommission / 100), (BuyCommission / 100)) * 100), 2).ToString();
            TxtBox_TotalTaxCost.Text = Math.Round((calculations.CalculateTaxCost(BuyPrice, SellPrice, (SellCommission / 100), (BuyCommission / 100), (TaxPerc / 100)) * Units), 2).ToString();
            TxtBox_TotalProfitAfterTax.Text = Math.Round((calculations.CalculateProfitAfterTax(BuyPrice, SellPrice, (SellCommission / 100), (BuyCommission / 100), (TaxPerc / 100)) * Units), 2).ToString();
        }

        


        #region Helper Methods

        /// <summary>
        /// Help method for clearing TextBoxes in Window object
        /// </summary>
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }


        /// <summary>
        /// Input validation for the text-boxes allowing only numbers and a maximum of 10 digits 
        /// </summary>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.,]{1}?[0-9]{0,10}$|^[0-9]{0,10}[.,]{1}?[0-9]{0,10}$|^[0-9]{1,10}$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        #endregion


    }
}
