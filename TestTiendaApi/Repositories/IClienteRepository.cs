using TestTiendaApi.Models;

namespace TestTiendaApi.Repositories;

    public interface IClienteRepository
    {
    bool Add(Cliente cliente);
    Cliente Get(int ID);
    Cliente Update(int ID, Cliente at);
    Task<List<Cliente>> GetAllAsync();
    bool Delete(int ID);
}

