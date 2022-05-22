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
        
        public AddFel()
        {
           InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listaProduse.ItemsSource = await App.Database.GetProduseAsync();
            listaProduseFel.ItemsSource = new List<Produs>();
            float pretp = 0;
            prettotal.Text = pretp.ToString();
            foreach (Produs p in listaProduseFel.ItemsSource)
            {
                pretp += p.Pret;
            }
            pretproduse.Text = pretp.ToString();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Produs prod = (Produs)e.SelectedItem;
                List<Produs> L=await App.Database.ViewProduse((List<Produs>)listaProduse.ItemsSource,prod);
                listaProduse.ItemsSource = null;
                listaProduse.ItemsSource = L;
                List<Produs> L2 = (List<Produs>)listaProduseFel.ItemsSource;
                L2.Add(prod);
                listaProduseFel.ItemsSource = null;
                listaProduseFel.ItemsSource = L2;
                float pret = float.Parse(pretproduse.Text);
                pret += prod.Pret;
                pretproduse.Text = pret.ToString();
                try
                {
                    pret = float.Parse(prettotal.Text);
                    pret = float.Parse(txtadaos.Text) + float.Parse(pretproduse.Text);
                    prettotal.Text = pret.ToString();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(@"Ceva nu e ok", ex.Message);
                }
            }
        }
        async void OnItem2Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Produs prod = (Produs)e.SelectedItem;
                List<Produs> L = await App.Database.ViewProduse((List<Produs>)listaProduseFel.ItemsSource, prod);
                listaProduseFel.ItemsSource = null;
                listaProduseFel.ItemsSource = L;
                List<Produs> L2 = (List<Produs>)listaProduse.ItemsSource;
                L2.Add(prod);
                listaProduse.ItemsSource = null;
                listaProduse.ItemsSource = L2;
                float pret = float.Parse(pretproduse.Text);
                pret -= prod.Pret;
                pretproduse.Text = pret.ToString();
                pret = float.Parse(prettotal.Text);
                pret = float.Parse(txtadaos.Text) + float.Parse(pretproduse.Text);
                prettotal.Text = pret.ToString();
            }
        }
        async void AddValueperTotal(object sender, TextChangedEventArgs e)
        {
            float prett = 0;
            try
            {
                prett = float.Parse(txtadaos.Text);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            prettotal.Text = (prett + float.Parse(pretproduse.Text)).ToString();
        }
        async protected void SalvareFel(object sender, EventArgs a)
        {
            var fel = new Fel_m()
            {
                Nume = txtnume.Text,
                Durata = float.Parse(txtdurata.Text),
                InStoc = instoc.IsToggled,
                Pret=float.Parse(prettotal.Text)
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