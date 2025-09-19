using infrastructure.Models;
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
    public async Task<IActionResult> CreateFeat([FromBody] FeatCreateModelDto item)
    {
        if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Effect)) return BadRequest();
        
        FeatModel result = await _featService.Create(item);
        
        return result != null ? Ok(result) : NotFound();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteFeat([FromBody] Guid id)
    {
        if (string.IsNullOrEmpty(id.ToString())) return BadRequest();

        bool result = await _featService.Delete(id);
        
        return result != null ? Ok(result) : NotFound();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateFeat([FromBody] FeatCreateModelDto item, Guid id)
    {
        if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Effect)) return BadRequest();
        
        FeatModel result = await _featService.Update(id, item);
        
        return result != null ? Ok(result) : NotFound();
    }
    
    [HttpGet]
    [Route("Feat/{featId}")]
    public async Task<IActionResult> GetSpecificFeat([FromRoute] Guid featId)
    {
        if (string.IsNullOrEmpty(featId.ToString())) return BadRequest();
        
        FeatModel result = await _featService.GetResult(featId);
        
        return result != null ? Ok(result) : NotFound();
    }
    
    [HttpGet]
    [Route("Feat/SimpleList")]
    public async Task<IActionResult> GetSimpleFeatList()
    {
        IEnumerable<SimpelEntityDto> result = await _featService.GetSimpleList();
        
        return result != null ? Ok(result) : NotFound();
    }
    
    [HttpGet]
    [Route("Feat/DetailedList")]
    public async Task<IActionResult> GetDetailedFeatList()
    {
        IEnumerable<FeatModel> result = await _featService.GetDetailedList();
        
        return result != null ? Ok(result) : NotFound();
    }
    
}