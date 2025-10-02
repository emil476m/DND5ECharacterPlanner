using infrastructure.Interfaces;
using infrastructure.Models.Items;
using service.Interfaces;

namespace service.Implementation;

public class ItemService : IItemService
{
    
    private readonly IItemRepository _itemRepository;
    
    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    
    public Task<IEnumerable<ItemModel>> GetAllItems()
    {
        return _itemRepository.GetAllItems();
    }

    public Task<ItemModel?> GetItemById(Guid id)
    {
        return _itemRepository.GetItemById(id);
    }

    public Task<bool> DeleteItem(Guid id)
    {
        return _itemRepository.DeleteItem(id);
    }

    public Task<ItemModel> CreateArmor(ArmorModel armor)
    {
        return _itemRepository.CreateArmor(armor);
    }

    public Task<ItemModel> CreateWeapon(WeaponModel weapon)
    {
        return _itemRepository.CreateWeapon(weapon);
    }

    public Task<ItemModel> CreateTool(ToolModel tool)
    {
        return _itemRepository.CreateTool(tool);
    }

    public Task<ItemModel> CreateCurrency(CurrencyModel currency)
    {
        return _itemRepository.CreateCurrency(currency);
    }

    public Task<ItemModel> CreateWondrous(WondrousItemModel wondrous)
    {
        return _itemRepository.CreateWondrous(wondrous);
    }

    public Task<ItemModel> UpdateArmor(ArmorModel armor)
    {
        return _itemRepository.UpdateArmor(armor);
    }

    public Task<ItemModel> UpdateWeapon(WeaponModel weapon)
    {
        return _itemRepository.UpdateWeapon(weapon);
    }

    public Task<ItemModel> UpdateTool(ToolModel tool)
    {
        return _itemRepository.UpdateTool(tool);
    }

    public Task<ItemModel> UpdateCurrency(CurrencyModel currency)
    {
        return _itemRepository.UpdateCurrency(currency);
    }

    public Task<ItemModel> UpdateWondrous(WondrousItemModel wondrous)
    {
        return _itemRepository.UpdateWondrous(wondrous);
    }
}