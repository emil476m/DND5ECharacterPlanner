using Core.Interfaces;
using Core.Models.Items;

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
        //TODO: Move Guid generation responsibility to database
        armor.Id = Guid.NewGuid();
        return _itemRepository.CreateArmor(armor);
    }

    public Task<ItemModel> CreateWeapon(WeaponModel weapon)
    {
        weapon.Id = Guid.NewGuid();
        return _itemRepository.CreateWeapon(weapon);
    }

    public Task<ItemModel> CreateGenericItem(ItemModel item)
    {
        item.Id = Guid.NewGuid();
        return _itemRepository.CreateGenericItem(item);
    }

    public Task<ItemModel> CreateCurrency(CurrencyModel currency)
    {
        currency.Id = Guid.NewGuid();
        return _itemRepository.CreateCurrency(currency);
    }

    public Task<ItemModel> CreateWondrous(WondrousItemModel wondrous)
    {
        wondrous.Id = Guid.NewGuid();
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

    public Task<ItemModel> UpdateGenericItem(ItemModel item)
    {
        return _itemRepository.UpdateGenericItem(item);
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