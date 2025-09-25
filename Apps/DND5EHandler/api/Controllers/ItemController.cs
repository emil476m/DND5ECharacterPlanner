using infrastructure.Models.Items;
using Microsoft.AspNetCore.Mvc;
using service.Interfaces;

namespace api.Controllers;
[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
       _itemService = itemService;
    }

    // Read Endpoints
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _itemService.GetAllItems();
        return result != null ? Ok(result) : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _itemService.GetItemById(id);
        return result != null ? Ok(result) : NotFound();
    }
    
    // Delete item by id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        var result = await _itemService.DeleteItem(id);
        return result ? Ok() : NotFound();
    }

    // Create Endpoints
    
    [HttpPost("Armor")]
    public async Task<ActionResult<ItemModel>> CreateArmor([FromBody] ArmorModel armor)
    {
        var result = await _itemService.CreateArmor(armor);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPost("Weapon")]
    public async Task<ActionResult<ItemModel>> CreateWeapon([FromBody] WeaponModel weapon)
    {
        var result = await _itemService.CreateWeapon(weapon);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPost("Tool")]
    public async Task<ActionResult<ItemModel>> CreateTool([FromBody] ToolModel tool)
    {
        var result = await _itemService.CreateTool(tool);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPost("Currency")]
    public async Task<ActionResult<ItemModel>> CreateCurrency([FromBody] CurrencyModel currency)
    {
        var result = await _itemService.CreateCurrency(currency);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPost("Wondrous")]
    public async Task<ActionResult<ItemModel>> CreateWondrous([FromBody] WondrousItemModel wondrous)
    {
        var result = await _itemService.CreateWondrous(wondrous);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
    
    // Update Endpoints
    
    [HttpPut("Armor")]
    public async Task<ActionResult<ItemModel>> UpdateArmor([FromBody] ArmorModel armor)
    {
        var result = await _itemService.CreateArmor(armor);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("Weapon")]
    public async Task<ActionResult<ItemModel>> UpdateWeapon([FromBody] WeaponModel weapon)
    {
        var result = await _itemService.CreateWeapon(weapon);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("Tool")]
    public async Task<ActionResult<ItemModel>> UpdateTool([FromBody] ToolModel tool)
    {
        var result = await _itemService.CreateTool(tool);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("Currency")]
    public async Task<ActionResult<ItemModel>> UpdateCurrency([FromBody] CurrencyModel currency)
    {
        var result = await _itemService.CreateCurrency(currency);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("Wondrous")]
    public async Task<ActionResult<ItemModel>> UpdateWondrous([FromBody] WondrousItemModel wondrous)
    {
        var result = await _itemService.CreateWondrous(wondrous);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
}