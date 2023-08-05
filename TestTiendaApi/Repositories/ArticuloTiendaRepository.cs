using Microsoft.EntityFrameworkCore;
using TestTiendaApi.Models;
using TestTiendaApi.ViewModel;

namespace TestTiendaApi.Repositories;

    public class ArticuloTiendaRepository: IArticuloTiendaRepository
    {
    private readonly DbtesttiendaContext _db;

    public ArticuloTiendaRepository(DbtesttiendaContext db)
    {
        _db = db;
    }

    public bool Add(ArticuloTiendum a)
    {
        bool success = false;
        try
        {
            _db.ArticuloTienda.Add(a);
            _db.SaveChanges();
            success = true;
        }
        catch (Exception ex)
        {
            success = false;
        }
        return success;
    }

    public List<TiendaXArticulo> GetTiendaXArticulo(int ID)
    {
        try
        {
            

            var resultado = from a in _db.Articulos
                            from t in _db.Tiendas
                            join at in _db.ArticuloTienda
                            on new { IdArticulo = a.Id, IdTienda = t.Id }
                            equals new { at.IdArticulo, at.IdTienda } into articuloTiendaJoin
                            from at in articuloTiendaJoin.DefaultIfEmpty()
                            where a.Id == 1
                            select new TiendaXArticulo
                            {
                                idArticulo = a.Id,
                                 Descripcion= a.Descripcion,
                                 Sucursal= t.Sucursal,
                                idTienda = t.Id,
                                Asignada = at.IdTienda != null ? true : false
                            };


            return resultado.ToList();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public ArticuloTiendum Get(int ID)
    {
        try
        {
            return _db.ArticuloTienda.Where(c => c.Id == ID).FirstOrDefault();



        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<ArticuloTiendum>> GetAllAsync()
    {
        return await _db.ArticuloTienda.Where(x=> x.IdArticulo == 1) .ToListAsync();
    }

    public ArticuloTiendum Update(int ID, ArticuloTiendum a)
    {
        try
        {
            var aObj = _db.ArticuloTienda.Where(c => c.Id == ID).FirstOrDefault();
            if (aObj != null)
            {
                aObj.Fecha = a.Fecha;
               


                _db.ArticuloTienda.Update(aObj);
                _db.SaveChanges();
                return aObj;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
        return null;
    }

    public bool Delete(int ID)
    {
        bool success = false;
        try
        {
            var at = _db.ArticuloTienda.Where(d => d.Id == ID).FirstOrDefault();
            if (at != null)
            {
                _db.ArticuloTienda.Remove(at);
                _db.SaveChanges();
                success = true;
            }
        }
        catch (Exception ex)
        {
            success = false;
        }
        return success;
    }

}

