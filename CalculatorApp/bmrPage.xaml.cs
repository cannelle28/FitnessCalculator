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
    public sealed partial class bmrPage : Page
    {
        Calculator calculator = new Calculator();
        int resultActivity;

        public bmrPage()
        {
            this.InitializeComponent();

            //combobox
            ActivityComboBox.Items.Add(new Item("SEDENTARY - Spend most of the day sitting (bank teller, desk job)", 0));
            ActivityComboBox.Items.Add(new Item("LIGHT ACTIVITY - Spend a good part of the day on your feet (teacher, salesman)", 1));
            ActivityComboBox.Items.Add(new Item("ACTIVE - Spend a good part of the day doing physical activity (waitress, mailman)", 2));
            ActivityComboBox.Items.Add(new Item("VERY ACTIVE - Spend most of the day doing heavy physical activity (messanger, capenter)", 3));

        }

        private class Item //comboBox
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
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
        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(whrPage));
        }
        private void MenuButton5_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ibwPage));
        }

        private void getWeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((getWeightBox.Text.All(Char.IsDigit)) && (!string.IsNullOrEmpty(getWeightBox.Text)))
                calculator.Weight = Convert.ToDouble(getWeightBox.Text);

        }
        private void getHeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((getHeightBox.Text.All(Char.IsDigit)) && (!string.IsNullOrEmpty(getHeightBox.Text)))
                calculator.Height = Convert.ToDouble(getHeightBox.Text);
        }
        private void getAgeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((getAgeBox.Text.All(Char.IsDigit)) && (!string.IsNullOrEmpty(getAgeBox.Text)))
                calculator.Age = Convert.ToDouble(getAgeBox.Text);
        }

        private void ActivityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item itm = (Item)ActivityComboBox.SelectedItem;
            resultActivity = ActivityComboBox.SelectedIndex;

            switch (resultActivity)
            {
                case 0: calculator.Activity = 1.2; break;
                case 1: calculator.Activity = 1.375; break;
                case 2: calculator.Activity = 1.5; break;
                case 3: calculator.Activity = 1.5; break;
            }
        }

        private void bmrResultButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActivityComboBox.SelectedIndex >= 0 && ActivityComboBox.SelectedIndex <= 3 && calculator.Age>12 && calculator.Weight>39 && calculator.Height>130)
            {
                if (radioButtonFemale.IsChecked == true)
                {
                    resultBox.Text = "You need " + calculator.CalculateFemaleBMR().ToString() + " calories";
                }
                else if (radioButtonMale.IsChecked== true)
                {
                    resultBox.Text = "You need " + calculator.CalculateMaleBMR().ToString() + " calories";
                }
                else if ( radioButtonMale.IsChecked == false || radioButtonFemale.IsChecked == false) resultBox.Text = "Select your gender";
            }
            else resultBox.Text = "Incorrect input";
        }
    }
}
