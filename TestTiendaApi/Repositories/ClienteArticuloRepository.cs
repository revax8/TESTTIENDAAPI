using Microsoft.EntityFrameworkCore;
using TestTiendaApi.Models;
using TestTiendaApi.ViewModel;

namespace TestTiendaApi.Repositories;

    public class ClienteArticuloRepository: IClienteArticuloRepository
    {
    private readonly DbtesttiendaContext _db;

    public ClienteArticuloRepository(DbtesttiendaContext db)
    {
        _db = db;
    }

    public bool Add(ClienteArticulo ca)
    {
        bool success = false;
        try
        {
            _db.ClienteArticulos.Add(ca);
            _db.SaveChanges();
            success = true;
        }
        catch (Exception ex)
        {
            success = false;
        }
        return success;
    }

    public List<ClienteXArticulo> GetClienteXArticulo(int idCliente, int idTienda)
    {
        try
        {
            //var query = from a in _db.Articulos
            //            from t in _db.Clientes
            //            join at in _db.ClienteArticulos
            //                 on new { IdCliente = t.Id, IdArticulo = a.Id } equals new { at.IdCliente, at.IdArticulo }
            //                 into clientArticuloGroup
            //            from at in clientArticuloGroup.DefaultIfEmpty()
            //            where t.Id == 4
            //            select new ClienteXArticulo
            //            {
            //                idArticulo = a.Id,
            //                Articulo = a.Codigo + " " + a.Descripcion,
            //                Cliente = t.Nombre + " " + t.Apellidos,
            //                idTienda = t.Id,
            //                Asignada = at == null ? false : true
            //            };
            var query = from a in _db.Articulos
                        from t in _db.Clientes
                        join at in _db.ClienteArticulos
                             on new { IdCliente = t.Id, IdArticulo = a.Id } equals new { at.IdCliente, at.IdArticulo }
                             into clientArticuloGroup
                        from at in clientArticuloGroup.DefaultIfEmpty()
                        join art in _db.ArticuloTienda on a.Id equals art.IdArticulo
                        where t.Id == idCliente && art.IdTienda == idTienda
                        select new ClienteXArticulo
                        {
                            idArticulo = a.Id,
                            Articulo = a.Codigo + " " + a.Descripcion,
                            Cliente = t.Nombre + " " + t.Apellidos,
                            idCliente = t.Id,
                            Asignada = at == null ? false : true,
                            idTienda= art.IdTienda
                        };
            return query.ToList();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

   

}

