using TestTiendaApi.Models;
using TestTiendaApi.Repositories;

namespace TestTiendaApi.Services
{
    public class TiendaService : ITiendaService
    {
        private readonly ITiendaRepository _tiendaRepository;

        public TiendaService(ITiendaRepository tiendaRepository)
        {
            _tiendaRepository = tiendaRepository;
        }
        public bool Add(Tienda paciente)
        {
            return _tiendaRepository.Add(paciente);
        }

        public Tienda Get(int ID)
        {
            return _tiendaRepository.Get(ID);
        }

        public async Task<List<Tienda>> GetAllAsync()
        {
            return await _tiendaRepository.GetAllAsync();
        }

        public Tienda Update(int ID, Tienda tienda)
        {
            return _tiendaRepository.Update(ID, tienda);
        }

        public bool Delete(int ID)
        {
            return _tiendaRepository.Delete(ID);
        }
    }
}
