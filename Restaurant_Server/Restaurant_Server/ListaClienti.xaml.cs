using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurant_Server.Models;

namespace Restaurant_Server
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaClienti : ContentPage
    {
        public ListaClienti()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            //base.OnAppearing();
            var Cli = new List<Client>();
            Cli = await App.Database.GetClientsAsync();
            listView.ItemsSource = Cli;
        }
    }
}