using Microsoft.EntityFrameworkCore;
using TestTiendaApi.Models;

namespace TestTiendaApi.Repositories;

public class TiendaRepository : ITiendaRepository
{
    private readonly DbtesttiendaContext _db;

    public TiendaRepository(DbtesttiendaContext db)
    {
        _db = db;
    }

    public bool Add(Tienda tienda)
    {
        bool success = false;
        try
        {
            _db.Tiendas.Add(tienda);
            _db.SaveChanges();
            success = true;
        }
        catch (Exception ex)
        {
            success = false;
        }
        return success;
    }


    public Tienda Get(int ID)
    {
        try
        {
            return _db.Tiendas.Where(c => c.Id == ID).FirstOrDefault();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<Tienda>> GetAllAsync()
    {
        return await _db.Tiendas.ToListAsync();
    }

    public Tienda Update(int ID, Tienda tienda)
    {
        try
        {
            var tiendaObj = _db.Tiendas.Where(c => c.Id == ID).FirstOrDefault();
            if (tiendaObj != null)
            {
                tiendaObj.Direccion = tienda.Direccion;
                tiendaObj.Sucursal = tienda.Sucursal;

                _db.Tiendas.Update(tiendaObj);
                _db.SaveChanges();
                return tiendaObj;
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
            var doctor = _db.Tiendas.Where(d => d.Id == ID).FirstOrDefault();
            if (doctor != null)
            {
                _db.Tiendas.Remove(doctor);
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

