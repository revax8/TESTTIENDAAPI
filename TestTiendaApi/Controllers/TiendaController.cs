using Microsoft.AspNetCore.Mvc;
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
}
