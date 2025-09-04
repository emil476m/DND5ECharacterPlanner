using infrastructure.Models.Feats;
using Microsoft.AspNetCore.Mvc;
using service.Implementation;
using service.Interfaces;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class FeatController : ControllerBase
{
    
    private readonly IService<FeatModel , FeatCreateModelDto> _featService;

    public FeatController(IService<FeatModel , FeatCreateModelDto> featService)
    {
        _featService = featService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(FeatCreateModelDto item)
    {
        if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Effect)) return BadRequest();
        
        FeatModel result = await _featService.Create(item);
        
        return result != null ? Ok(result) : NotFound();
    }
    
}