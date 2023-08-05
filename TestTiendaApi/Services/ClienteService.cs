using TestTiendaApi.Models;
using TestTiendaApi.Repositories;

namespace TestTiendaApi.Services;

    public class ArticuloService:IArticuloService
    {
    private readonly IArticuloRepository _arRepository;

    public ArticuloService(IArticuloRepository arRepository)
    {
        _arRepository = arRepository;
    }
    public bool Add(Articulo at)
    {
        return _arRepository.Add(at);
    }

    public Articulo Get(int ID)
    {
        return _arRepository.Get(ID);
    }

    public async Task<List<Articulo>> GetAllAsync()
    {
        return await _arRepository.GetAllAsync();
    }

    public Articulo Update(int ID, Articulo ar)
    {
        return _arRepository.Update(ID, ar);
    }

    public bool Delete(int ID)
    {
        return _arRepository.Delete(ID);
    }
}

