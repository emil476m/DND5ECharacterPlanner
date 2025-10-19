using api.Mappers;
using api.TransferModels.Feats;
using Core.Interfaces;
using Core.Models.Feats;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

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
        var response = result.ToFeatDto().ToResponseDto("Created Feat");

        return response != null ? Ok(response) : NotFound();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFeat([FromBody] Guid id)
    {
        if (string.IsNullOrEmpty(id.ToString())) return BadRequest();

        var result = await _featService.Delete(id);
        var response = result.ToReturnedBoolDto();
        return response != null ? Ok(response) : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFeat([FromBody] FeatCreateDto item, Guid id)
    {
        if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Effect)) return BadRequest();

        var result = await _featService.Update(id, item.ToFeatModel());
        var response = result.ToFeatDto().ToResponseDto("Updated Feat");

        return response != null ? Ok(response) : NotFound();
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