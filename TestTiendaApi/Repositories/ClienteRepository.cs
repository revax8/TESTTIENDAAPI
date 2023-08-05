using Microsoft.EntityFrameworkCore;
using TestTiendaApi.Models;

namespace TestTiendaApi.Repositories;

    public class ClienteRepository: IClienteRepository
    {
    private readonly DbtesttiendaContext _db;

    public ClienteRepository(DbtesttiendaContext db)
    {
        _db = db;
    }

    public bool Add(Cliente c)
    {
        bool success = false;
        try
        {
            _db.Clientes.Add(c);
            _db.SaveChanges();
            success = true;
        }
        catch (Exception ex)
        {
            success = false;
        }
        return success;
    }


    public Cliente Get(int ID)
    {
        try
        {
            return _db.Clientes.Where(c => c.Id == ID).FirstOrDefault();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _db.Clientes.ToListAsync();
    }

    public Cliente Update(int ID, Cliente c)
    {
        try
        {
            var cObj = _db.Clientes.Where(c => c.Id == ID).FirstOrDefault();
            if (cObj != null)
            {
                cObj.Nombre = c.Nombre;
                cObj.Apellidos = c.Apellidos;
                cObj.Direccion = c.Direccion;
                


                _db.Clientes.Update(cObj);
                _db.SaveChanges();
                return cObj;
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
            var c = _db.Clientes.Where(d => d.Id == ID).FirstOrDefault();
            if (c != null)
            {
                _db.Clientes.Remove(c);
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

