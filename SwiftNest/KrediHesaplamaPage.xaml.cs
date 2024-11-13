using Microsoft.Maui.Controls;
using System.Globalization;

namespace SwiftNest
{
    public partial class KrediHesaplamaPage : ContentPage
    {
        public KrediHesaplamaPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            var culture = new CultureInfo("tr-TR");
            try
            {
                double krediTutar = double.Parse(KrediTutarEntry.Text);
                double faizOrani = double.Parse(FaizOraniEntry.Text) / 100;
                int vadeAy = int.Parse(VadeEntry.Text);

                double aylikFaizOrani = faizOrani / 12;
                double aylikTaksit = (krediTutar * aylikFaizOrani) / (1 - Math.Pow(1 + aylikFaizOrani, -vadeAy));

                double toplamOdeme = aylikTaksit * vadeAy;
                double toplamFaiz = toplamOdeme - krediTutar;

                AylikTaksitLabel.Text = $"Aylık Taksit: {aylikTaksit.ToString("C2", culture)}";
                ToplamOdemeLabel.Text = $"Toplam Ödeme: {toplamOdeme.ToString("C2", culture)}";
                ToplamFaizLabel.Text = $"Toplam Faiz: {toplamFaiz.ToString("C2", culture)}";
            }
            catch (Exception ex)
            {
                DisplayAlert("Hata", "Lütfen geçerli veriler giriniz.", "Tamam");
            }
        }
    }
}
