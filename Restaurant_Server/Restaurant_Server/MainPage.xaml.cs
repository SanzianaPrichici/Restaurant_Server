using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Restaurant_Server
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void Dishes (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaFeluri());
        }
        async void Clients (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaClienti());
        }
        async void Products(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaProduse());
        }
        async void Tables(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaMese());
        }
        async void Orders (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaComenzi());
        }
    }
}
