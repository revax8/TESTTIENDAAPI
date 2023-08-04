using Microsoft.EntityFrameworkCore;
using TestTiendaApi.Models;

namespace TestTiendaApi.Repositories;

    public class ArticuloRepository: IArticuloRepository
    {
    private readonly DbtesttiendaContext _db;

    public ArticuloRepository(DbtesttiendaContext db)
    {
        _db = db;
    }

    public bool Add(Articulo at)
    {
        bool success = false;
        try
        {
            _db.Articulos.Add(at);
            _db.SaveChanges();
            success = true;
        }
        catch (Exception ex)
        {
            success = false;
        }
        return success;
    }


    public Articulo Get(int ID)
    {
        try
        {
            return _db.Articulos.Where(c => c.Id == ID).FirstOrDefault();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<Articulo>> GetAllAsync()
    {
        return await _db.Articulos.ToListAsync();
    }

    public Articulo Update(int ID, Articulo at)
    {
        try
        {
            var atObj = _db.Articulos.Where(c => c.Id == ID).FirstOrDefault();
            if (atObj != null)
            {
                atObj.Descripcion = at.Descripcion;
                atObj.Stock = at.Stock;
                atObj.Imagen = at.Imagen;
                atObj.Precio = at.Precio;


                _db.Articulos.Update(atObj);
                _db.SaveChanges();
                return atObj;
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
            var at = _db.Articulos.Where(d => d.Id == ID).FirstOrDefault();
            if (at != null)
            {
                _db.Articulos.Remove(at);
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

