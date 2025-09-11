using infrastructure.Models;

namespace service.Interfaces;

public interface IService<TModel, TDto>
{
    Task<TModel> GetResult(Guid id);
    
    Task <IEnumerable<SimpelEntityDto>> GetSimpleList();
    
    Task<IEnumerable<TModel>> GetDetailedList();
    
    Task<bool> Delete(Guid id);
    
    Task<TModel> Create(TDto item);
    
    Task<TModel> Update(Guid id, TDto item);
    
}