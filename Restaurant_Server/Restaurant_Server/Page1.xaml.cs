using Restaurant_Server.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant_Server
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private ObservableCollection<Produs> _prod;
        public ObservableCollection<Produs> Produse
        {
            get
            {
                return _prod ?? (_prod = new ObservableCollection<Produs>());
            }
        }
        public Page1()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
        //listaProduse.ItemsSource = await App.Database.ViewProduse();
        }
        protected void MyButtonClick(object sender, EventArgs a)
        {
            var p = new Produs()
            {
                ID = 7,
                Denumire = "Supa",
                Cantitate = 3,
                Pret = 8,
                Alergen = true
            };
            Produse.Add(p);
            Console.WriteLine(@"S-a scris");
            foreach(Produs x in Produse)
            {
                Console.WriteLine(x.ID);
            }
            listaProduse.ItemsSource = Produse;
        }
    }
}