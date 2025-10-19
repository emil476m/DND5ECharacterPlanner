using System.Text.Json;
using api.Mappers.Items;
using api.TransferModels.Items;
using Core.Enums;
using Core.Interfaces;
using Core.Models.Items;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class ItemController : ControllerBase
{
    
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
       _itemService = itemService;
    }

    // Read Endpoints
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _itemService.GetAllItems();
        var responseDto = result.Select(x => x.ToItemDto());
        return Ok(responseDto);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _itemService.GetItemById(id);
        return result != null ? Ok(result.ToItemDto()) : NotFound();
    }
    
    // Delete item by id
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteItemAsync(Guid id)
    {
        var result = await _itemService.DeleteItem(id);
        return result ? Ok() : NotFound();
    }

    // Create Endpoints


    [HttpPost("Armor")]
    public async Task<ActionResult<ItemModel>> CreateArmorAsync([FromBody] ArmorModel armor)
    {
        var result = await _itemService.CreateArmor(armor);
        return Ok(result.ToItemDto());;
    }

    [HttpPost("Weapon")]
    public async Task<ActionResult<ItemModel>> CreateWeaponAsync([FromBody] WeaponModel weapon)
    {
        var result = await _itemService.CreateWeapon(weapon);
        return Ok(result.ToItemDto());
    }

    [HttpPost("GenericItem")]
    public async Task<ActionResult<ItemModel>> CreateGenericItemAsync([FromBody] GenericItemModel item)
    {
        //TODO: Create a create dto for all relevant endpoints
        
        var result = await _itemService.CreateGenericItem(item);
        return Ok(result.ToItemDto());
    }

    [HttpPost("Currency")]
    public async Task<ActionResult<ItemModel>> CreateCurrencyAsync([FromBody] CurrencyModel currency)
    {
        var result = await _itemService.CreateCurrency(currency);
        return Ok(result.ToItemDto());
    }

    [HttpPost("Wondrous")]
    public async Task<ActionResult<ItemModel>> CreateWondrousAsync([FromBody] WondrousItemModel wondrous)
    {
        var result = await _itemService.CreateWondrous(wondrous);
        return Ok(result.ToItemDto());
    }
    
    // Update Endpoints
    
    [HttpPut("Armor")]
    public async Task<ActionResult<ItemModel>> UpdateArmorAsync([FromBody] ArmorModel armor)
    {
        var result = await _itemService.UpdateArmor(armor);
        return Ok(result.ToItemDto());
    }

    [HttpPut("Weapon")]
    public async Task<ActionResult<ItemModel>> UpdateWeaponAsync([FromBody] WeaponModel weapon)
    {
        var result = await _itemService.UpdateWeapon(weapon);
        return Ok(result.ToItemDto());
    }

    [HttpPut("GenericItem")]
    public async Task<ActionResult<ItemModel>> UpdateGenericItemAsync([FromBody] GenericItemModel item)
    {
        var result = await _itemService.UpdateGenericItem(item);
        return Ok(result.ToItemDto());
    }

    [HttpPut("Currency")]
    public async Task<ActionResult<ItemModel>> UpdateCurrencyAsync([FromBody] CurrencyModel currency)
    {
        var result = await _itemService.UpdateCurrency(currency);
        return Ok(result.ToItemDto());
    }

    [HttpPut("Wondrous")]
    public async Task<ActionResult<ItemModel>> UpdateWondrousAsync([FromBody] WondrousItemModel wondrous)
    {
        var result = await _itemService.UpdateWondrous(wondrous);
        return Ok(result.ToItemDto());
        
        
    }
}