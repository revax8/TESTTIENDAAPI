using TestTiendaApi.Models;

namespace TestTiendaApi.Repositories;

    public interface IArticuloRepository
    {
    bool Add(Articulo tienda);
    Articulo Get(int ID);
    Articulo Update(int ID, Articulo at);
    Task<List<Articulo>> GetAllAsync();
    bool Delete(int ID);
}

