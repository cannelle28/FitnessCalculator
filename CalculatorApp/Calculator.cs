using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Calculator
    {
        private double weight;
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private double age;
        public double Age
        {
            get { return age; }
            set { age = value; }
        }

        private double height;
        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        private double activity;
        public double Activity
        {
            get { return activity; }
            set { activity = value; }
        }
        private double waist;
        public double Waist
        {
            get { return waist; }
            set { waist = value; }
        }
        private double hip;
        public double Hip
        {
            get { return hip; }
            set { hip = value; }
        }

        public double bmi;
        public double bmr;
        public double whr;
        public double brocF, brocM, lorF, lorM, potF, potM, atuz;
        public string resultText;

        public double CalculateBMI()
        {
            bmi = Math.Round((weight / (height * height) * 10000), 2);
            if (bmi < 18.5) resultText = "Your bmi is below 18.5 – you're in the underweight range";
            else if (bmi >= 18.5 && bmi <= 24.9) resultText = "Your bmi is between 18.5 and 24.9 – you're in the healthy weight range";
            else if (bmi >= 25 && bmi <= 29.9) resultText = "Your bmi is between 25 and 29.9 – you're in the overweight range";
            else if (bmi >= 30 && bmi <= 39.9) resultText = "Your bmi is between 30 and 39.9 – you're in the obese range ";
            else resultText = "Please enter valid data";
            return bmi;
        }
        public double CalculateFemaleBMR()
        {
            bmr = (655 + 9.6 * weight + 1.8 * height - 4.7 * age) * activity;
            return bmr;
        }
        public double CalculateMaleBMR()
        {
            bmr = (66 + 13.7 * weight + 5 * height - 6.8 * age) * activity;
            return bmr;
        }
        public double CalculateWHR()
        {
            whr = waist / hip;
            return whr;
        }
        public void CalculateIBW()
        {
            brocF = 0.9 * (height - 100);
            brocM = 0.95 * (height - 100);
            lorF = height - 100 - (height - 150) / 2;
            lorM = height - 100 - (height - 150) / 4;
            potF = height - 100 - (height - 100) / 10;
            potM = height - 100 - (height - 100) / 20;
            atuz = 50 + 0.75 * (height - 150);
        }

    
    }
}
