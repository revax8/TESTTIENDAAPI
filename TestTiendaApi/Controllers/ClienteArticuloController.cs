using Microsoft.AspNetCore.Mvc;
using TestTiendaApi.Models;
using TestTiendaApi.Services;
using TestTiendaApi.ViewModel;

namespace TestTiendaApi.Controllers;

    
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteArticuloController:Controller
    {
    private readonly IClienteArticuloService _caService;

    public ClienteArticuloController(IClienteArticuloService clienteArticuloService)
    {
        _caService = clienteArticuloService;
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] ClienteArticulo at)
    {
        IActionResult response = BadRequest();
        if (at != null)
        {
            if (_caService.Add(at))
                return Ok(at);
            else
                return response;
        }
        else
            return response;
    }



    [HttpGet("GetClienteXArticulo")]
    public IActionResult GetTiendaXArticulo(int idCliente, int idTienda)
    {
        IActionResult response = BadRequest();
        var result = _caService.GetClienteXArticulo(idCliente, idTienda);
        if (result != null)
        {
            response = Ok(result);
        }
        return response;
    }
}

