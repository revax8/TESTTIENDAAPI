using TestTiendaApi.Models;

namespace TestTiendaApi.Repositories
{
    public interface ITiendaRepository
    {
        bool Add(Tienda tienda);
        Tienda Get(int ID);
        Tienda Update(int ID, Tienda tienda);
        Task<List<Tienda>> GetAllAsync();
    }
}
