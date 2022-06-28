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
    public partial class ListaComenzi : ContentPage
    {
        public ListaComenzi()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetComenziAsync();
        }
        async void AddCDE(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddComanda
            {
                BindingContext = new Comanda()
            });
        }
        async void Modificare(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddComanda
            {
                BindingContext = listView.SelectedItem
            });
            Sterg.IsVisible = false;
            Modif.IsVisible = false;
        }
        async void Stergere(object sender, EventArgs e)
        {
            //await App.Database.delete((Comanda)listView.SelectedItem);
            //listView.ItemsSource = null;
            //listView.ItemsSource = await App.Database.GetFeluriAsync();
            //Sterg.IsVisible = false;
            //Modif.IsVisible = false;
        }
        void Selectare(object sender, SelectedItemChangedEventArgs e)
        {
            Sterg.IsVisible = true;
            Modif.IsVisible = true;
        }
    }
}