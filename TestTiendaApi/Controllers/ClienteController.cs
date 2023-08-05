using Microsoft.AspNetCore.Mvc;
using TestTiendaApi.Models;
using TestTiendaApi.Services;

namespace TestTiendaApi.Controllers;

    
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController:Controller
    {
    private readonly IClienteService _cService;

    public ClienteController(IClienteService clienteService)
    {
        _cService = clienteService;
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        IActionResult response = Unauthorized();
        var result = await _cService.GetAllAsync();

        if (result != null)
            response = Ok(result);

        return response;
    }
    [HttpPost("Add")]
    public IActionResult Add([FromBody] Cliente at)
    {
        IActionResult response = BadRequest();
        if (at != null)
        {
            if (_cService.Add(at))
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
        var result = _cService.Get(id);
        if (result != null)
        {
            response = Ok(result);
        }
        return response;
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Cliente at, int id)
    {
        IActionResult response = Unauthorized();
        var result = _cService.Update(id, at);

        if (result != null)
            response = Ok(result);

        return response;
    }
    [HttpDelete("Delete")]
    public Boolean Delete(int id)
    {
        bool resp = false;

        if (_cService.Delete(id))
            return true;

        return resp;
    }

}

