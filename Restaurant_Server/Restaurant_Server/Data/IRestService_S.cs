using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Server.Models;
using System.Threading.Tasks;

namespace Restaurant_Server.Data
{
    public interface IRestService_S
    {
        //Implementare CLIENTI
        Task<List<Client>> RefreshDataAsyncCLI();
        Task<string> SaveClientAsync(Client item, bool isNewItem);
        Task DeleteClientAsync(int id);
        //Implementare USERI
        Task<List<User>> RefreshDataAsyncUSR();
        Task SaveUserAsync(User item, bool isNewItem);
        Task DeleteUserAsync(int id);
        //Implementare FELURI DE MANCARE
        Task<List<Fel_m>> RefreshDataAsyncFEL();
        Task<string> SaveFelAsync(Fel_m item, bool isNewItem);
        Task DeleteFelAsync(int id);
        //Implementare PRODUSE
        Task<List<Produs>> RefreshDataAsyncPROD();
        Task<List<Produs>> GetProduseFelAsync(int id);
        Task<List<Produs>> GetProduseNUAsync(int id);
        Task SaveProdusAsync(Produs item, bool isNewItem);
        Task DeleteProdusAsync(int id);
        Task<List<Produs>> SortProduse(List<Produs> L,Produs P);
        //Implementare Feluri+Produse
        Task SaveFel_ProdAsync(Fel_Prods item, bool isNewItem);
        //Implementare Mese
        Task<List<Masa>> RefreshDataAsyncMASA();
        Task SaveMasaAsync(Masa item, bool isNewItem);
        Task DeleteMasaAsync(int id);
        Task<List<Fel_Prods>> RefreshDataAsyncFELP(int id);
        Task<List<Comanda>> RefreshDataAsyncCOM();
    }
}
