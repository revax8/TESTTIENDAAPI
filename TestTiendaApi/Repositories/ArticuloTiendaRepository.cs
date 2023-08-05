using Microsoft.EntityFrameworkCore;
using TestTiendaApi.Models;

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
        return await _db.ArticuloTienda.ToListAsync();
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

