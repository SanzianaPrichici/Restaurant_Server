using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Server.Models;
using System.Threading.Tasks;

namespace Restaurant_Server.Data
{
    public class LicentaDB
    {
        readonly IRestService_S restService;
        public LicentaDB(IRestService_S service)
        {
            restService = service;
        }
        public Task<List<Client>> GetClientsAsync()
        {
            return restService.RefreshDataAsyncCLI();
        }
        public Task<List<User>> GetUsersAsync()
        {
            Console.WriteLine(@"Am ajuns in baza de date sa afisez userii");
            return restService.RefreshDataAsyncUSR();
        }
        public Task<List<Fel_m>> GetFeluriAsync()
        {
            return restService.RefreshDataAsyncFEL();
        }
        public Task<List<Produs>> GetProduseAsync()
        {
            Console.Write(@"Al doilea pas in LicentaDB");
            return restService.RefreshDataAsyncPROD();
        }
        public Task<string> SaveClientAsync(Client item, bool isNewItem = true)
        {
            Console.WriteLine(@"Am ajuns in baza de date");
            return restService.SaveClientAsync(item, isNewItem);
        }
        public Task SaveUserAsync(User item, bool isNewItem = true)
        {
            return restService.SaveUserAsync(item, isNewItem);
        }
        public Task<string> SaveFeluriAsync(Fel_m item, bool isNewItem = true)
        {
            Console.WriteLine(@"Am ajuns in baza de date");
            return restService.SaveFelAsync(item, isNewItem);
        }
        public Task SaveFPAsync(Fel_Prods item, bool isNewItem = true)
        {
            return restService.SaveFel_ProdAsync(item, isNewItem);
        }
        public Task SaveProduseAsync(Produs item, bool isNewItem = true)
        {
            return restService.SaveProdusAsync(item, isNewItem);
        }
        public Task DeleteClientAsync(Client item)
        {
            return restService.DeleteClientAsync(item.ID);
        }
        public Task DeleteUserAsync(User item)
        {
            return restService.DeleteUserAsync(item.ID);
        }
        public Task DeleteFeluriAsync(Fel_m item)
        {
            return restService.DeleteFelAsync(item.ID);
        }
        public Task DeleteProduseAsync(Produs item)
        {
            return restService.DeleteProdusAsync(item.ID);
        }
        public Task<List<Produs>> ViewProduse(List<Produs> L, Produs P1)
        {
            return restService.SortProduse(L, P1);
        }
    }
}
