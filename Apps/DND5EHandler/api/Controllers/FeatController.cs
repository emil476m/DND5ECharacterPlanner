using api.Mappers.DndEntities;
using api.Mappers.Feats;
using api.Mappers.Generic;
using api.TransferModels.DndEntities;
using api.TransferModels.Feats;
using api.TransferModels.GenericDto;
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
    
    private readonly IService<FeatModel> _featService;

    public FeatController(IService<FeatModel> featService)
    {
        _featService = featService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeat([FromBody] FeatCreateDto item)
    {
        if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Effect)) return BadRequest();
        
        FeatModel result = await _featService.Create(item.ToFeatModel());
        ResponseDto response = result.ToFeatDto().ToResponseDto("Created Feat");
        
        return response != null ? Ok(response) : NotFound();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteFeat([FromBody] Guid id)
    {
        if (string.IsNullOrEmpty(id.ToString())) return BadRequest();

        bool result = await _featService.Delete(id);
        ReturnBoolDto response = result.ToReturnedBoolDto();
        return response != null ? Ok(response) : NotFound();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateFeat([FromBody] FeatCreateDto item, Guid id)
    {
        if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Effect)) return BadRequest();
        
        FeatModel result = await _featService.Update(id, item.ToFeatModel());
        ResponseDto response = result.ToFeatDto().ToResponseDto("Updated Feat");
        
        return response != null ? Ok(response) : NotFound();
    }
    
    [HttpGet]
    [Route("Feat/{featId}")]
    public async Task<IActionResult> GetSpecificFeat([FromRoute] Guid featId)
    {
        if (string.IsNullOrEmpty(featId.ToString())) return BadRequest();
        
        FeatModel result = await _featService.GetResult(featId);
        FeatDto response = result.ToFeatDto();
        return response != null ? Ok(response) : NotFound();
    }
    
    [HttpGet]
    [Route("Feat/SimpleList")]
    public async Task<IActionResult> GetSimpleFeatList()
    {
        IEnumerable<DndEntitySimpleModel> result = await _featService.GetSimpleList();
        IEnumerable<DndEntitySimpleDto> response = result.Select(x => x.ToDndEntitySimpleDto());
        return response != null ? Ok(response) : NotFound();
    }
    
    [HttpGet]
    [Route("Feat/DetailedList")]
    public async Task<IActionResult> GetDetailedFeatList()
    {
        IEnumerable<FeatModel> result = await _featService.GetDetailedList();
        
        IEnumerable<FeatDto> response = result.Select(x => x.ToFeatDto());
        
        return response != null ? Ok(response) : NotFound();
    }
    
}