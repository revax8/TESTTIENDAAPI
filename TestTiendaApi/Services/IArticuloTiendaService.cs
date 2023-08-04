using TestTiendaApi.Models;

namespace TestTiendaApi.Services
{
    public interface IArticuloTiendaService
    {
        bool Add(ArticuloTiendum at);
        ArticuloTiendum Get(int ID);
        ArticuloTiendum Update(int ID, ArticuloTiendum at);
        Task<List<ArticuloTiendum>> GetAllAsync();
        bool Delete(int ID);
    }
}
