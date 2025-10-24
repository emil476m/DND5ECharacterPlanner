using Api.Mappers;
using Api.TransferModels.Feats;
using Core.Interfaces;
using Core.Models.Feats;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FeatController : ControllerBase
{
    private readonly IService<FeatModel> _featService;

    public FeatController(IService<FeatModel> featService)
    {
        _featService = featService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeat([FromBody] FeatCreateDto item)
    {
        if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Effect)) return BadRequest();

        var result = await _featService.Create(item.ToFeatModel());
        var response = result.ToFeatDto();

        return response != null ? Created("Created Feat", response) : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteFeat([FromRoute] Guid id)
    {
        if (id == Guid.Empty) return BadRequest();

        var deleted = await _featService.Delete(id);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateFeat([FromRoute] Guid id, [FromBody] FeatCreateDto item)
    {
        if (id == Guid.Empty) return BadRequest();
        if (string.IsNullOrWhiteSpace(item.Name) || string.IsNullOrWhiteSpace(item.Effect)) return BadRequest();

        var updated = await _featService.Update(id, item.ToFeatModel());
        return updated != null ? Ok(updated) : NotFound();
    }

    [HttpGet]
    [Route("Feat/{featId}")]
    public async Task<IActionResult> GetSpecificFeat([FromRoute] Guid featId)
    {
        if (string.IsNullOrEmpty(featId.ToString())) return BadRequest();

        var result = await _featService.GetResult(featId);
        var response = result.ToFeatDto();
        return response != null ? Ok(response) : NotFound();
    }

    [HttpGet]
    [Route("Feat/SimpleList")]
    public async Task<IActionResult> GetSimpleFeatList()
    {
        var result = await _featService.GetSimpleList();
        var response = result.Select(x => x.ToDndEntitySimpleDto());
        return response != null ? Ok(response) : NotFound();
    }

    [HttpGet]
    [Route("Feat/DetailedList")]
    public async Task<IActionResult> GetDetailedFeatList()
    {
        var result = await _featService.GetDetailedList();

        var response = result.Select(x => x.ToFeatDto());

        return response != null ? Ok(response) : NotFound();
    }
}