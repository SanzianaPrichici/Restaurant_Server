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
    public partial class AddMasa : ContentPage
    {
        public AddMasa()
        {
            InitializeComponent();
        }
        async void OnButtonSave(object sender, EventArgs e)
        {
            try
            {
                var m = new Masa
                {
                    Nr_pers=Int32.Parse(txtnrpers.Text),
                    Dispo = alerg.IsToggled
                };
                await App.Database.SaveMasaAsync(m);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("NEOK", ex.Message, "OK");
            }
        }
    }
}