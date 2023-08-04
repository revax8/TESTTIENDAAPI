using Microsoft.AspNetCore.Mvc;
using TestTiendaApi.Models;
using TestTiendaApi.Services;

namespace TestTiendaApi.Controllers;

    
    [ApiController]
    [Route("api/[controller]")]
    public class ArticuloTiendaController:Controller
    {
    private readonly IArticuloTiendaService _atService;

    public ArticuloTiendaController(IArticuloTiendaService tiendaService)
    {
        _atService = tiendaService;
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        IActionResult response = Unauthorized();
        var result = await _atService.GetAllAsync();

        if (result != null)
            response = Ok(result);

        return response;
    }
    [HttpPost("Add")]
    public IActionResult Add([FromBody] ArticuloTiendum at)
    {
        IActionResult response = BadRequest();
        if (at != null)
        {
            if (_atService.Add(at))
                return Ok(at);
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
        var result = _atService.Get(id);
        if (result != null)
        {
            response = Ok(result);
        }
        return response;
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] ArticuloTiendum at, int id)
    {
        IActionResult response = Unauthorized();
        var result = _atService.Update(id, at);

        if (result != null)
            response = Ok(result);

        return response;
    }
    [HttpDelete("Delete")]
    public Boolean Delete(int id)
    {
        bool resp = false;

        if (_atService.Delete(id))
            return true;

        return resp;
    }

}

