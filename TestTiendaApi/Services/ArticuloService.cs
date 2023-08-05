using TestTiendaApi.Models;
using TestTiendaApi.Repositories;

namespace TestTiendaApi.Services;

    public class ClienteService:IClienteService
    {
    private readonly IClienteRepository _cRepository;

    public ClienteService(IClienteRepository cRepository)
    {
        _cRepository = cRepository;
    }
    public bool Add(Cliente at)
    {
        return _cRepository.Add(at);
    }

    public Cliente Get(int ID)
    {
        return _cRepository.Get(ID);
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _cRepository.GetAllAsync();
    }

    public Cliente Update(int ID, Cliente ar)
    {
        return _cRepository.Update(ID, ar);
    }

    public bool Delete(int ID)
    {
        return _cRepository.Delete(ID);
    }
}

