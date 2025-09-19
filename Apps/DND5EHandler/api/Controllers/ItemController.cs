using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    

    public ItemController()
    {
       
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = "";
        return result != null ? Ok(result) : NotFound();
    }
}