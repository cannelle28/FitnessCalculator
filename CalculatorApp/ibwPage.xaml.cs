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
    public sealed partial class ibwPage : Page
    {
        Calculator calculator = new Calculator();

        public ibwPage()
        {
            this.InitializeComponent();
        }

        // menu
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
        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(whrPage));
        }

        private void getHeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((getHeightBox.Text.All(Char.IsDigit)) && (!string.IsNullOrEmpty(getHeightBox.Text)))
                calculator.Height = Convert.ToDouble(getHeightBox.Text);
        }

        private void bmrResultButton_Click(object sender, RoutedEventArgs e)
        {
            if (calculator.Height > 0 && calculator.Height < 250 && (radioButtonFemale.IsChecked == true || radioButtonMale.IsChecked == true))
            {
                calculator.CalculateIBW();
                if (radioButtonFemale.IsChecked==true)
                    resultBox.Text = $"Broc: {calculator.brocF}\nLorentz: {calculator.lorF}\nPotton: {calculator.potF}\nAtuz: {calculator.atuz}";
                else if (radioButtonMale.IsChecked==true)
                    resultBox.Text = $"Broc: {calculator.brocM}\nLorentz: {calculator.lorM}\nPotton: {calculator.potM}\nAtuz: {calculator.atuz}";
            }
            else resultBox.Text = "Incorrect input";
        }
    }
}
