using infrastructure.Interfaces;
using infrastructure.Models.Items;

namespace infrastructure.Implementations;

public class ItemRepository : IItemRepository
{
    public Task<IEnumerable<ItemModel>> GetAllItems()
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel?> GetItemById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> CreateArmor(ArmorModel armor)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> CreateWeapon(WeaponModel weapon)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> CreateTool(ToolModel tool)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> CreateCurrency(CurrencyModel currency)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> CreateWondrous(WondrousItemModel wondrous)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> UpdateArmor(ArmorModel armor)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> UpdateWeapon(WeaponModel weapon)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> UpdateTool(ToolModel tool)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> UpdateCurrency(CurrencyModel currency)
    {
        throw new NotImplementedException();
    }

    public Task<ItemModel> UpdateWondrous(WondrousItemModel wondrous)
    {
        throw new NotImplementedException();
    }
}