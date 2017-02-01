using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CalculatorApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class bmiPage : Page
    {
        Calculator calculator = new Calculator();

        public bmiPage()
        {
            this.InitializeComponent();

        }

        private void getWeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (getWeightBox.Text.Length>0)
                if ((getWeightBox.Text.All(Char.IsDigit)) &&(!string.IsNullOrEmpty(getWeightBox.Text)))
                calculator.Weight = Convert.ToDouble(getWeightBox.Text);
        }
        private void getHeigtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((getHeigtBox.Text.All(Char.IsDigit)) && (!string.IsNullOrEmpty(getHeigtBox.Text)))
                calculator.Height = Convert.ToDouble(getHeigtBox.Text);
        }

        private void bmiResultButton_Click(object sender, RoutedEventArgs e)
        {
            if (calculator.Weight > 40 && calculator.Weight < 100 && calculator.Height > 130 && calculator.Height < 210)
            {
                calculator.CalculateBMI();
                resultBox.Text = Convert.ToString(calculator.bmi);
                resultBox2.Text = calculator.resultText;
            }
            else
            {
                resultBox.Text = "";
                resultBox2.Text = "Incorrect input";
            }
        }

        // menu
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(bmrPage));
        }
        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(whrPage));
        }

        private void MenuButton5_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ibwPage));
        }

        private void MenuButton4_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(whrPage));
        }
    }
}
