using Api.Mappers;
using Api.Mappers.Background;
using Api.TransferModels.Background;
using Core.Interfaces;
using Core.Models.Backgrounds;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BackgroundController : ControllerBase
{
    private readonly IService<BackgroundModel> _backgroundService;

    public BackgroundController(IService<BackgroundModel> backgroundService)
    {
        _backgroundService = backgroundService;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateBackground([FromBody] BackgroundCreateDto item)
    {
        if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Description)) return BadRequest();

        var result = await _backgroundService.Create(item.ToBackgroundModel());
        var response = result.ToBackgroundDto();

        return response != null ? Created("Created background", response) : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteBackground([FromRoute] Guid id)
    {
        if (id == Guid.Empty) return BadRequest();

        var deleted = await _backgroundService.Delete(id);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateBackground([FromRoute] Guid id, [FromBody] BackgroundCreateDto item)
    {
        if (id == Guid.Empty) return BadRequest();
        if (string.IsNullOrWhiteSpace(item.Name) || string.IsNullOrWhiteSpace(item.Description)) return BadRequest();

        var updated = await _backgroundService.Update(id, item.ToBackgroundModel());
        return updated != null ? Ok(updated) : NotFound();
    }

    [HttpGet]
    [Route("{backgroundId}")]
    public async Task<IActionResult> GetSpecificBackground([FromRoute] Guid backgroundId)
    {
        if (string.IsNullOrEmpty(backgroundId.ToString())) return BadRequest();

        var result = await _backgroundService.GetResult(backgroundId);
        var response = result.ToBackgroundDto();
        return response != null ? Ok(response) : NotFound();
    }

    [HttpGet]
    [Route("SimpleList")]
    public async Task<IActionResult> GetSimpleBackgroundList()
    {
        var result = await _backgroundService.GetSimpleList();
        var response = result.Select(x => x.ToDndEntitySimpleDto());
        return response != null ? Ok(response) : NotFound();
    }

    [HttpGet]
    [Route("DetailedList")]
    public async Task<IActionResult> GetDetailedBackgroundList()
    {
        var result = await _backgroundService.GetDetailedList();

        var response = result.Select(x => x.ToBackgroundDto());

        return response != null ? Ok(response) : NotFound();
    }
}