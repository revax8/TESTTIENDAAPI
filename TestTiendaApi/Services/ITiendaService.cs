using TestTiendaApi.Models;

namespace TestTiendaApi.Services
{
    public interface ITiendaService
    {
        bool Add(Tienda paciente);
        Tienda Get(int ID);
        Tienda Update(int ID, Tienda tienda);
        Task<List<Tienda>> GetAllAsync();
        bool Delete(int ID);
    }
}
