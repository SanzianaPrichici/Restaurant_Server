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
    public partial class AddFel : ContentPage
    {
        public AddFel()
        {
           InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            //base.OnAppearing();
            var P = new List<Produs>();
            P = await App.Database.GetProduseAsync();
            listaProduse.ItemsSource = P;
            listaProduseFel.ItemsSource = null;
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                listaProduse.BeginRefresh();
                await DelP2((Produs)e.SelectedItem);
                //await Adauga((Produs)e.SelectedItem);
                listaProduse.EndRefresh();
            }
        }
        async Task DelP2 (Produs P1)
        {
            
            Console.WriteLine(@"ID");
            Console.WriteLine(P1.ID);
            List<Produs> L = (List<Produs>)listaProduse.ItemsSource;
            foreach( Produs p in L )
            { 
              if(p.ID == P1.ID)
                {
                    Console.WriteLine(@"S-a sters");
                    L.Remove(p);
                    break;
                } 
            }
            listaProduse.ItemsSource = L;
            
        }
        async Task Adauga(Produs P1)
        {
            Console.WriteLine(@"ID");
            Console.WriteLine(P1.ID);
            try
            {
                List<Produs> L = new List<Produs>();
                L = (List<Produs>)listaProduseFel.ItemsSource;
                L.Add(P1);
                listaProduseFel.ItemsSource = L;
            }
            catch(Exception ex) { Console.WriteLine("NEOK", ex.InnerException.ToString(), "OK"); }
        }
    }
}