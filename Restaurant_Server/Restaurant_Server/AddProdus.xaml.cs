using Restaurant_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant_Server
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProdus : ContentPage
    {
        public AddProdus()
        {
            InitializeComponent();
        }
        async void OnButtonSave(object sender, EventArgs e)
        {
            try
            {
                var p = new Produs
                {
                    Denumire = txtden.Text,
                    Cantitate = int.Parse(txtcant.Text),
                    Pret = float.Parse(txtpret.Text),
                    Alergen = alerg.IsToggled
                };
                await App.Database.SaveProduseAsync(p);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("NEOK", ex.Message, "OK");
            }
        }
    }
}