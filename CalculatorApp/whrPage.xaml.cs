using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class whrPage : Page
    {
        Calculator calculator = new Calculator();

        public whrPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(bmiPage));
        }
        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(bmrPage));
        }
        private void MenuButton5_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ibwPage));
        }

        private void getWaist_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((getWaist.Text.All(Char.IsDigit)) && (!string.IsNullOrEmpty(getWaist.Text)))
                calculator.Waist = Convert.ToDouble(getWaist.Text);
        }
        private void getHip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((getHip.Text.All(Char.IsDigit)) && (!string.IsNullOrEmpty(getHip.Text)))
                calculator.Hip = Convert.ToDouble(getHip.Text);
        }

        private void bmrResultButton_Click(object sender, RoutedEventArgs e)
        {
            if (calculator.Hip > 0 && calculator.Waist > 0 && calculator.Waist<110 && calculator.Hip < 100 && (radioButtonMale.IsChecked == true || radioButtonFemale.IsChecked == true))
            {
                resultBox.Text = (Math.Round(calculator.CalculateWHR(), 2)).ToString();
                if (radioButtonFemale.IsChecked == true)
                {
                    if (calculator.whr <= 0.8) resultBox2.Text = "Your waist to hip circumference is within the ideal range.";
                    else if (calculator.whr > 0.8 && calculator.whr < 0.9) resultBox2.Text = "Your waist to hip circumference is slightly above the ideal range.";
                    else if (calculator.whr >= 0.9) resultBox2.Text = "Your waist to hip circumference suggests your body shape and weight are putting you at increased risk of developing conditions such as heart disease and diabetes.";
                }
                else if (radioButtonMale.IsChecked == true)
                {
                    if (calculator.whr < 0.9) resultBox2.Text = "Your waist to hip circumference is within the ideal range.";
                    else if (calculator.whr >= 0.9 && calculator.whr < 1) resultBox2.Text = "Your waist to hip circumference is slightly above the ideal range.";
                    else if (calculator.whr >= 1) resultBox2.Text = "Your waist to hip circumference suggests your body shape and weight are putting you at increased risk of developing conditions such as heart disease and diabetes.";
                }
                else resultBox2.Text = "Select your gender";
            }
            else resultBox2.Text = "Incorrect input";
        }
    }
}
