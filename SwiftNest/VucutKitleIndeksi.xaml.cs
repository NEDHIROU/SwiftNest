using Microsoft.Maui.Controls;
using System;

namespace SwiftNest
{
    public partial class VucutKitleIndeksi : ContentPage
    {
        public VucutKitleIndeksi()
        {
            InitializeComponent();
        }

        // تزامن القيم بين إدخال الطول و Slider الخاص به
        private void OnHeightEntryChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(e.NewTextValue, out double height))
                HeightSlider.Value = height;
        }

        private void OnHeightSliderChanged(object sender, ValueChangedEventArgs e)
        {
            HeightEntry.Text = e.NewValue.ToString("F1");
        }

        // تزامن القيم بين إدخال الوزن و Slider الخاص به
        private void OnWeightEntryChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(e.NewTextValue, out double weight))
                WeightSlider.Value = weight;
        }

        private void OnWeightSliderChanged(object sender, ValueChangedEventArgs e)
        {
            WeightEntry.Text = e.NewValue.ToString("F1");
        }

        // حساب BMI وعرض النتيجة
        private void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            try
            {
                double height = HeightSlider.Value / 100;  // تحويل الطول من سم إلى متر
                double weight = WeightSlider.Value;

                double bmi = weight / (height * height);  // حساب مؤشر كتلة الجسم

                // عرض قيمة مؤشر كتلة الجسم في BMIResultLabel
                BMIResultLabel.Text = $"BMI: {bmi:F1}";

                string bmiCategory = GetBMICategory(bmi);
                BMIResultLabel.Text += $"\nKategori: {bmiCategory}";
            }
            catch (Exception)
            {
                BMIResultLabel.Text = "Hata: Lütfen geçerli bir değer giriniz.";
            }
        }

        // تصنيف BMI
        private string GetBMICategory(double bmi)
        {
            if (bmi < 18.5)
                return "Zayıf";
            else if (bmi >= 18.5 && bmi < 24.9)
                return "Normal";
            else if (bmi >= 25 && bmi < 29.9)
                return "Fazla Kilolu";
            else
                return "Obez";
        }
    }
}
