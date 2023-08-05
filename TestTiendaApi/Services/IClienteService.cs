using TestTiendaApi.Models;

namespace TestTiendaApi.Services
{
    public interface IClienteService
    {
        bool Add(Cliente c);
        Cliente Get(int ID);
        Cliente Update(int ID, Cliente c);
        Task<List<Cliente>> GetAllAsync();
        bool Delete(int ID);
    }
}
