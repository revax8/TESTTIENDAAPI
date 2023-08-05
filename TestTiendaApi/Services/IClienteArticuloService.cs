using TestTiendaApi.Models;
using TestTiendaApi.ViewModel;

namespace TestTiendaApi.Services
{
    public interface IClienteArticuloService
    {
        bool Add(ClienteArticulo at);
        public List<ClienteXArticulo> GetClienteXArticulo(int idCliente, int idTienda);
    }
}
