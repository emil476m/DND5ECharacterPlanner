using Api.Mappers.Items;
using Core.Interfaces;
using Core.Models.Items;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

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

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        if (string.IsNullOrEmpty(id.ToString())) return BadRequest();
        var result = await _itemService.GetItemById(id);
        return result != null ? Ok(result.ToItemDto()) : NotFound();
    }

    // Delete item by id

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteItemAsync([FromRoute] Guid id)
    {
        if (string.IsNullOrEmpty(id.ToString())) return BadRequest();
        var deleted = await _itemService.DeleteItem(id);
        return deleted ? NoContent() : NotFound();
    }

    // Create Endpoints

    [HttpPost("Armor")]
    public async Task<ActionResult<ItemModel>> CreateArmorAsync([FromBody] ArmorModel armor)
    {
        var result = await _itemService.CreateArmor(armor);
        var response = result.ToItemDto();
        return response != null ? Created("Created Item", response) : NotFound();
    }

    [HttpPost("Weapon")]
    public async Task<ActionResult<ItemModel>> CreateWeaponAsync([FromBody] WeaponModel weapon)
    {
        var result = await _itemService.CreateWeapon(weapon);
        var response = result.ToItemDto();
        return response != null ? Created("Created Item", response) : NotFound();
    }

    [HttpPost("GenericItem")]
    public async Task<ActionResult<ItemModel>> CreateGenericItemAsync([FromBody] GenericItemModel item)
    {
        //TODO: Create a create dto for all relevant endpoints

        var result = await _itemService.CreateGenericItem(item);
        var response = result.ToItemDto();
        return response != null ? Created("Created Item", response) : NotFound();
    }

    [HttpPost("Currency")]
    public async Task<ActionResult<ItemModel>> CreateCurrencyAsync([FromBody] CurrencyModel currency)
    {
        var result = await _itemService.CreateCurrency(currency);
        var response = result.ToItemDto();
        return response != null ? Created("Created Item", response) : NotFound();
    }

    [HttpPost("Wondrous")]
    public async Task<ActionResult<ItemModel>> CreateWondrousAsync([FromBody] WondrousItemModel wondrous)
    {
        var result = await _itemService.CreateWondrous(wondrous);
        var response = result.ToItemDto();
        return response != null ? Created("Created Item", response) : NotFound();
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