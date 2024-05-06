using System;
using Xamarin.Forms;

namespace Pivculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing() { ShowItems(); }

        private void ShowItems()
        { itemcollection.ItemsSource = App.Db.GetItems(); }

        private async void PutItem(object sender, EventArgs e)
        {
            if (namefield.Text.Trim().Length < 1 && alchofield.Text.Trim().Length < 1 &&
                volfield.Text.Trim().Length < 1 && cointfield.Text.Trim().Length < 1)
            {
                await DisplayAlert("error", "пустое поле", "ок");
                return;
            }
            else if (int.TryParse(alchofield.Text.Trim(), out _) == false)
            {
                await DisplayAlert("error", "нужно число", "ок");
                return;
            }
            else if (int.TryParse(volfield.Text.Trim(), out _) == false)
            {
                await DisplayAlert("error", "нужно число", "ок");
                return;
            }
            else if (int.TryParse(cointfield.Text.Trim(), out _) == false)
            {
                await DisplayAlert("error", "нужно число", "ок");
                return;
            }
            string name = namefield.Text.Trim();

            int alchoclear = Convert.ToInt32(alchofield.Text.Trim());
            int volclear = Convert.ToInt32(volfield.Text.Trim());
            int cointclear = Convert.ToInt32(cointfield.Text.Trim());
            int slide = (int)slidefield.Value;

            float vol = volclear;
            float coint = cointclear / vol * 1000;
            float alchopower = alchoclear * vol / 100;
            float alcho = cointclear / alchopower;

            Item item = new Item
            { Alcho = alcho, Coint = coint, Slide = slide, Name = name };

            App.Db.SaveItem(item);
            ShowItems();


            namefield.Text = "";
            alchofield.Text = "";
            volfield.Text = "";
            cointfield.Text = "";
            slidefield.Value = 5;
        }
        private void Delete(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var id = button.BindingContext;
            App.Db.DeleteItem(Convert.ToInt32(id));
            ShowItems();
        }
    }    

}
