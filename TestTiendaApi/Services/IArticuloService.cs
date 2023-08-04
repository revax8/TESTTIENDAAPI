using TestTiendaApi.Models;

namespace TestTiendaApi.Services
{
    public interface IArticuloService
    {
        bool Add(Articulo at);
        Articulo Get(int ID);
        Articulo Update(int ID, Articulo at);
        Task<List<Articulo>> GetAllAsync();
        bool Delete(int ID);
    }
}
