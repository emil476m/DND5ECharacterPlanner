namespace service.Interfaces;

public interface IService<TModel, TDto>
{
    Task<bool> Delete(Guid id);
    
    Task<TModel> Create(TDto item);
    
    Task<TModel> Update(Guid id, TDto item);
    
}