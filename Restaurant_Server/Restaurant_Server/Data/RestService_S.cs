using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Server.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace Restaurant_Server.Data
{
    public class RestService_S : IRestService_S
    {
        readonly HttpClient client;
        readonly string RestUrlCLI = "https://api-lic.conveyor.cloud/api/Clients";
        readonly string RestUrlUSR = "https://api-lic.conveyor.cloud/api/Users/";
        readonly string RestUrlFEL = "https://api-lic.conveyor.cloud/api/Fels/";
        readonly string RestUrlPROD = "https://api-lic.conveyor.cloud/api/Produs/";
        readonly string RestUrlFP = "https://api-lic.conveyor.cloud/api/Fel_Prod/";
        readonly string RestUrlMASA = "https://api-lic.conveyor.cloud/api/Masas/";
        readonly string RestUrlCOM = "https://api-lic.conveyor.cloud/api/Comandas/";
        public List<Client> Clients { get; private set; }
        public List<User> Users { get; private set; }
        public List<Fel_m> Feluri { get; private set; }
        public List<Produs> Produse { get; private set; }
        public List<Masa> Mese { get; private set; }
        public List<Fel_Prods> FP { get; private set; }
        public List<Comanda> Comenzi { get; private set; }
        public RestService_S()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);
        }
        //Afisare lista clienti
        public async Task<List<Client>> RefreshDataAsyncCLI()
        {
            Console.WriteLine("AM AJUNS IN RestService");
            Clients = new List<Client>();
            Uri uri = new Uri(string.Format(RestUrlCLI, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Clients = JsonConvert.DeserializeObject<List<Client>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare clienti", ex.Message);
            }
            return Clients;
        }
        //Afisare lista useri
        public async Task<List<User>> RefreshDataAsyncUSR()
        {
            Console.WriteLine(@"Am ajuns in baza de date sa afisez userii");
            Users = new List<User>();
            Uri uri = new Uri(string.Format(RestUrlUSR, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Users = JsonConvert.DeserializeObject<List<User>>(content);
                    Console.WriteLine(Users.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare useri", ex.Message);
            }
            return Users;
        }
        //Afisare Feluri de mancare
        public async Task<List<Fel_m>> RefreshDataAsyncFEL()
        {
            Feluri = new List<Fel_m>();
            Uri uri = new Uri(string.Format(RestUrlFEL, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Feluri = JsonConvert.DeserializeObject<List<Fel_m>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare feluri", ex.Message);
            }
            return Feluri;
        }
        //Afisare Produse
        public async Task<List<Produs>> RefreshDataAsyncPROD()
        {
            Produse = new List<Produs>();
            Uri uri = new Uri(string.Format(RestUrlPROD, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Am ajuns la produse");
                    string content = await response.Content.ReadAsStringAsync();
                    Produse = JsonConvert.DeserializeObject<List<Produs>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare produse", ex.Message);
            }
            return Produse;
        }
        public async Task<List<Fel_Prods>> RefreshDataAsyncFELP(int id)
        {
            FP = new List<Fel_Prods>();

            Uri uri = new Uri(string.Format(RestUrlFP, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Am ajuns la feluri_prod");
                    string content = await response.Content.ReadAsStringAsync();
                    FP = JsonConvert.DeserializeObject<List<Fel_Prods>>(content);
                    List<Fel_Prods> Copie = new List<Fel_Prods>(FP);
                    Console.WriteLine(id.ToString());
                    foreach (Fel_Prods x in Copie)
                    {
                        Console.WriteLine(x.ID.ToString());
                        Console.WriteLine(x.FID.ToString());
                        Console.WriteLine(x.PID.ToString());
                        if (x.FID != id)
                            FP.Remove(x);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare feluri_prod", ex.Message);
            }
            return FP;
        }
        //Afisare Mese
        public async Task<List<Masa>> RefreshDataAsyncMASA()
        {
            Mese = new List<Masa>();
            Uri uri = new Uri(string.Format(RestUrlMASA, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Mese = JsonConvert.DeserializeObject<List<Masa>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare Mese", ex.Message);
            }
            return Mese;
        }
        public async Task<List<Comanda>> RefreshDataAsyncCOM()
        {
            Comenzi = new List<Comanda>();
            Uri uri = new Uri(string.Format(RestUrlCOM, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Comenzi = JsonConvert.DeserializeObject<List<Comanda>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare Mese", ex.Message);
            }
            List<Comanda> c2 = new List<Comanda>(Comenzi);
            foreach (Comanda c in c2)
            {
                try
                {
                    if (c.Status.ToUpper() != "IN_PREPARARE")
                    {
                        Console.WriteLine("*");
                        Comenzi.Remove(c); Console.WriteLine(c.Status); Console.WriteLine(c.ID);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("!");
                    Comenzi.Remove(c);
                }
            }
            foreach (Comanda c in Comenzi)
            {
                Console.WriteLine(c.ID);
                Console.WriteLine(c.Status);
            }
            return Comenzi;
        }
        public async Task<List<Produs>> SortProduse(List<Produs> L, Produs P)
        {
            Console.Write("Sunt in SOrt");
            Produse = new List<Produs>(L);
            List<Produs> Copie = new List<Produs>(Produse);
            List<Produs> Copie2 = new List<Produs>(Produse);
            foreach (Produs x in Copie)
            {
                Console.WriteLine(x.Denumire);
                if (x.ID == P.ID)
                {
                    Console.WriteLine("Am sters");
                    Console.WriteLine(x.Denumire);
                    Produse.Remove(x);
                }
            }
            Console.Write("Am iesit din SOrt");
            return Produse;
        }
        // Salvare Client
        public async Task<string> SaveClientAsync(Client item, bool isNewItem)
        {
            Console.WriteLine(@"Am ajuns la URL");
            Uri uri = new Uri(string.Format(RestUrlCLI, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    uri = new Uri(uri.ToString()+item.ID);
                    response = await client.PutAsync(uri, content);
                }
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"S-a salvat clientul.");
                    return response.Headers.Location.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Clientul nu poate fi salvat", ex.Message);
            }
            return null;
        }
        //Salvare fel de mancare
        public async Task<string> SaveFelAsync(Fel_m item, bool isNewItem)
        {
            Console.WriteLine(@"Am ajuns la URL");
            Uri uri = new Uri(string.Format(RestUrlFEL, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    uri = new Uri(uri.ToString() + item.ID);
                    response = await client.PutAsync(uri, content);
                }
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"S-a salvat felul.");
                    return response.Headers.Location.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Felul nu poate fi salvat", ex.Message);
            }
            return null;
        }
        public async Task SaveFel_ProdAsync(Fel_Prods item, bool isNewItem)
        {
            Console.WriteLine(@"Am ajuns la URL");
            Uri uri = new Uri(string.Format(RestUrlFP, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    uri = new Uri(uri.ToString() + item.ID);
                    response = await client.PutAsync(uri, content);
                }
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"S-a salvat felul.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Felul nu poate fi salvat", ex.Message);
            }
        }
        //Salvare produs
        public async Task SaveProdusAsync(Produs item, bool isNewItem)
        {
            Console.WriteLine(@"Am ajuns la URL");
            Uri uri = new Uri(string.Format(RestUrlPROD, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    uri = new Uri(uri.ToString() + item.ID);
                    response = await client.PutAsync(uri, content);
                }
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"S-a salvat produsul.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Produsul nu poate fi salvat", ex.Message);
            }
        }
        // Salvare User
        public async Task SaveUserAsync(User item, bool isNewItem)
        {
            Console.WriteLine(@"Am ajuns la URLul pt user");
            Uri uri = new Uri(string.Format(RestUrlUSR, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                Console.WriteLine(json);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    Console.WriteLine(@"Ceva POST.");
                    response = await client.PostAsync(uri, content);
                    Console.WriteLine(response.Headers.ToString());
                }
                else
                {
                    Console.WriteLine(@"Ceva PUT.");
                    uri = new Uri(uri.ToString() + item.ID);
                    response = await client.PutAsync(uri, content);
                }
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"S-a salvat userul.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Userul nu poate fi salvat", ex.Message);
            }
        }
        //Salvare Masa
        public async Task SaveMasaAsync(Masa item, bool isNewItem)
        {
            Console.WriteLine(@"Am ajuns la URL");
            Uri uri = new Uri(string.Format(RestUrlMASA, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    uri = new Uri(uri.ToString() + item.ID);
                    response = await client.PutAsync(uri, content);
                }
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"S-a salvat clientul.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Clientul nu poate fi salvat", ex.Message);
            }
        }
        //Stergere Client
        public async Task DeleteClientAsync(int id)
        {
            Uri uri = new Uri(RestUrlCLI + id.ToString());
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Clientul a fost sters");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Clientul nu poate fi sters", ex.Message);
            }
        }
        //Stergere User
        public async Task DeleteUserAsync(int id)
        {
            Uri uri = new Uri(RestUrlUSR+id.ToString());
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Userul a fost sters");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Userul nu poate fi sters", ex.Message);
            }
        }
        //Stergere Fel de mancare
        public async Task DeleteFelAsync(int id)
        {
            Console.WriteLine("Sa stergem felul");
            Uri uri = new Uri(RestUrlFEL + id.ToString());
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                Console.WriteLine(response.RequestMessage.ToString());
                Console.WriteLine(response.ReasonPhrase.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Felul a fost sters");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Felul nu poate fi sters", ex.Message);
            }
        }
        //Stergere Fel de mancare
        public async Task DeleteProdusAsync(int id)
        {
            Uri uri = new Uri(RestUrlPROD + id.ToString());
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Produsul a fost sters");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Produsul nu poate fi sters", ex.Message);
            }
        }
        public async Task DeleteMasaAsync(int id)
        {
            Uri uri = new Uri(RestUrlMASA + id.ToString());
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Produsul a fost sters");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Produsul nu poate fi sters", ex.Message);
            }
        }
        public async Task<List<Produs>> GetProduseFelAsync(int id)
        {
            Console.WriteLine("GetProduseFelAsync");
            Console.WriteLine(id.ToString());
            List<Produs> L2 = await GetProduseNUAsync(id);
            Produse = await RefreshDataAsyncPROD();
            List<Produs> Copie = new List<Produs>(Produse);
            List<Produs> Copie2 = new List<Produs>(Produse);
            foreach (Produs p in Produse)
            {
                Console.WriteLine(p.Denumire.ToString());
            }
            foreach (Produs p in Copie2)
            {
                Console.WriteLine(p.Denumire.ToString());
            }
            foreach (Produs p in L2)
            {
                Console.WriteLine(p.Denumire.ToString());
                foreach (Produs p2 in Copie)
                {
                    if (p2.ID == p.ID)
                    {
                        Console.WriteLine("Am sters");
                        Console.WriteLine(p2.Denumire.ToString());
                        Copie2.Remove(p2);
                    }
                    else
                    {
                        Console.WriteLine("A ramas");
                        Console.WriteLine(p2.Denumire.ToString());
                    }
                }
            }
            Console.WriteLine("Am terminat");
            foreach(Produs p in Copie2)
            {
                Console.WriteLine(p.Denumire.ToString());
            }    
            return Copie2;
        }
        public async Task<List<Produs>> GetProduseNUAsync(int id)
        {
            Console.WriteLine("l");
            Console.WriteLine("GetProduseNUAsync");
            Console.WriteLine(id.ToString());
            Produse = await RefreshDataAsyncPROD();
            List<Fel_Prods> L = await RefreshDataAsyncFELP(id);
            List<Produs> Copie = new List<Produs>(Produse);
            Console.WriteLine("Aici");
            foreach (Fel_Prods p in L)
            {
                Console.WriteLine(p.PID.ToString());
            }
            foreach (Fel_Prods fp in L)
            {
                Console.WriteLine("Felul de mancare cu id-ul");
                Console.WriteLine(fp.PID);
                foreach (Produs p in Copie)
                {
                    if (fp.PID == p.ID)
                        Produse.Remove(p);
                }
            }
            return Produse;
        }
    }
}
