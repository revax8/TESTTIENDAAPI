using TestTiendaApi.Models;
using TestTiendaApi.Repositories;
using TestTiendaApi.ViewModel;

namespace TestTiendaApi.Services;

    public class ArticuloTiendaService:IArticuloTiendaService
    {
    private readonly IArticuloTiendaRepository _arRepository;

    public ArticuloTiendaService(IArticuloTiendaRepository arRepository)
    {
        _arRepository = arRepository;
    }
    public bool Add(ArticuloTiendum at)
    {
        return _arRepository.Add(at);
    }

    public ArticuloTiendum Get(int ID)
    {
        return _arRepository.Get(ID);
    }

    public async Task<List<ArticuloTiendum>> GetAllAsync()
    {
        return await _arRepository.GetAllAsync();
    }

    public ArticuloTiendum Update(int ID, ArticuloTiendum ar)
    {
        return _arRepository.Update(ID, ar);
    }

    public bool Delete(int ID)
    {
        return _arRepository.Delete(ID);
    }
    public List<TiendaXArticulo> GetTiendaXArticulo(int ID)
    {
        return _arRepository.GetTiendaXArticulo(ID);
    }
}

