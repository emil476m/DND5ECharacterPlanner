using Core.Models.Items;

namespace Core.Interfaces;

public interface IItemRepository
{
    Task<IEnumerable<ItemModel>> GetAllItems();
    Task<ItemModel?> GetItemById(Guid id);
    Task<bool> DeleteItem(Guid id);

    Task<ItemModel> CreateArmor(ArmorModel armor);
    Task<ItemModel> CreateWeapon(WeaponModel weapon);
    Task<ItemModel> CreateGenericItem(ItemModel item);
    Task<ItemModel> CreateCurrency(CurrencyModel currency);
    Task<ItemModel> CreateWondrous(WondrousItemModel wondrous);
    
    Task<ItemModel> UpdateArmor(ArmorModel armor);
    Task<ItemModel> UpdateWeapon(WeaponModel weapon);
    Task<ItemModel> UpdateGenericItem(ItemModel item);
    Task<ItemModel> UpdateCurrency(CurrencyModel currency);
    Task<ItemModel> UpdateWondrous(WondrousItemModel wondrous);
}