using TestTiendaApi.Models;
using TestTiendaApi.ViewModel;

namespace TestTiendaApi.Repositories;

    public interface IClienteArticuloRepository
    {
  
    public List<ClienteXArticulo> GetClienteXArticulo(int idCliente, int idTienda);
    bool Add(ClienteArticulo tienda);
}

