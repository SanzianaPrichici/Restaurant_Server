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
    public partial class ListaMese : ContentPage
    {
        public ListaMese()
        {
            InitializeComponent();
        }
        async protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetMesesync();
        }
        async void AddTable(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMasa
            {
                BindingContext = new Masa()
            });
        }
        async void Modificare(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMasa
            {
                BindingContext = listView.SelectedItem
            });
            Sterg.IsVisible = false;
            Modif.IsVisible = false;
        }
        async void Stergere(object sender, EventArgs e)
        {
            await App.Database.DeleteMasaAsync((Masa)listView.SelectedItem);
            listView.ItemsSource = null;
            listView.ItemsSource = await App.Database.GetMesesync();
            Sterg.IsVisible = false;
            Modif.IsVisible = false;
        }
        void Selectare(object sender, SelectedItemChangedEventArgs e)
        {
            Sterg.IsVisible = true;
            Modif.IsVisible = true;
        }
    }
}