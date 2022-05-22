using Restaurant_Server.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant_Server
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddFel : ContentPage
    {
        private ObservableCollection<Produs> _prod;
        public ObservableCollection<Produs> Produse
        {
            get
            {
                return _prod ?? (_prod = new ObservableCollection<Produs>());
            }
        }
        public AddFel()
        {
           InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listaProduse.ItemsSource = await App.Database.GetProduseAsync();
            listaProduseFel.ItemsSource = new List<Produs>();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                List<Produs> L=await App.Database.ViewProduse((List<Produs>)listaProduse.ItemsSource,(Produs)e.SelectedItem);
                listaProduse.ItemsSource = null;
                listaProduse.ItemsSource = L;
                //await Adauga((Produs)e.SelectedItem);
                List<Produs> L2 = (List<Produs>)listaProduseFel.ItemsSource;
                L2.Add((Produs)e.SelectedItem);
                listaProduseFel.ItemsSource = null;
                listaProduseFel.ItemsSource = L2;
            }
        }
        async void OnItem2Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                List<Produs> L = await App.Database.ViewProduse((List<Produs>)listaProduseFel.ItemsSource, (Produs)e.SelectedItem);
                listaProduseFel.ItemsSource = null;
                listaProduseFel.ItemsSource = L;
                //await Adauga((Produs)e.SelectedItem);
                List<Produs> L2 = (List<Produs>)listaProduse.ItemsSource;
                L2.Add((Produs)e.SelectedItem);
                listaProduse.ItemsSource = null;
                listaProduse.ItemsSource = L2;
            }
        }
        async protected void SalvareFel(object sender, EventArgs a)
        {
            var fel = new Fel_m()
            {
                Nume = txtnume.Text,
                Durata = float.Parse(txtdurata.Text),
                InStoc = instoc.IsToggled
            };
            string s= await App.Database.SaveFeluriAsync(fel);
            string nr = new string(s.Reverse().ToArray());
            Regex re = new Regex(@"\d+");
            var id = re.Match(nr);
            string id2 = new string(id.ToString().Reverse().ToArray());
            int id3 = Int32.Parse(id2);
            Console.WriteLine(id3.ToString());
            foreach(Produs p in listaProduseFel.ItemsSource)
            {
                Fel_Prods F = new Fel_Prods()
                {
                    FID = id3,
                    PID = p.ID
                };
                await App.Database.SaveFPAsync(F);
            }
        }
    }
}