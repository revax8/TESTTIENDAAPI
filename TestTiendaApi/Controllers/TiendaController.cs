using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using TestTiendaApi.Models;
using TestTiendaApi.Services;

namespace TestTiendaApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TiendaController: Controller
{
    private readonly ITiendaService _tiendaService;

    public TiendaController(ITiendaService tiendaService)
    {
        _tiendaService = tiendaService;
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        IActionResult response = Unauthorized();
        var result = await _tiendaService.GetAllAsync();

        if (result != null)
            response = Ok(result);

        return response;
    }
    [HttpPost("Add")]
    public IActionResult Add([FromBody] Tienda tienda)
    {
        IActionResult response = BadRequest();
        if (tienda != null)
        {
            if (_tiendaService.Add(tienda))
                return Ok(tienda);
            else
                return response;
        }
        else
            return response;
    }

    [HttpGet("{id}")]
    public IActionResult GetID(int id)
    {

        IActionResult response = BadRequest();
        var result = _tiendaService.Get(id);
        if (result != null)
        {
            response = Ok(result);
        }
        return response;
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Tienda tienda, int id)
    {
        IActionResult response = Unauthorized();
        var result = _tiendaService.Update(id, tienda);

        if (result != null)
            response = Ok(result);

        return response;
    }
    [HttpDelete("Delete")]
    public Boolean Delete(int id)
    {
        bool resp = false;

        if (_tiendaService.Delete(id))
            return true;

        return resp;
    }
}
