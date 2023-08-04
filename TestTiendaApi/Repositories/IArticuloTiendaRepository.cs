using TestTiendaApi.Models;

namespace TestTiendaApi.Repositories;

    public interface IArticuloTiendaRepository
    {
    bool Add(ArticuloTiendum tienda);
    ArticuloTiendum Get(int ID);
    ArticuloTiendum Update(int ID, ArticuloTiendum at);
    Task<List<ArticuloTiendum>> GetAllAsync();
    bool Delete(int ID);
}

