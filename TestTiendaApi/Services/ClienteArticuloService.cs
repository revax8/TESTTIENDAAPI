using TestTiendaApi.Models;
using TestTiendaApi.Repositories;
using TestTiendaApi.ViewModel;

namespace TestTiendaApi.Services;

    public class ClienteArticuloService:IClienteArticuloService
    {
    private readonly IClienteArticuloRepository _caRepository;

    public ClienteArticuloService(IClienteArticuloRepository caRepository)
    {
        _caRepository = caRepository;
    }
    public bool Add(ClienteArticulo at)
    {
        return _caRepository.Add(at);
    }

    
    public List<ClienteXArticulo> GetClienteXArticulo(int idCliente, int idTienda)
    {
        return _caRepository.GetClienteXArticulo(idCliente, idTienda);
    }


}

