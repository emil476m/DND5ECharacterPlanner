using Domain.Models;

namespace service.Interfaces;

public interface IService<T>
{
    Task<T> GetResult(Guid id);
    
    Task <IEnumerable<DndEntitySimpleModel>> GetSimpleList();
    
    Task<IEnumerable<T>> GetDetailedList();
    
    Task<bool> Delete(Guid id);
    
    Task<T> Create(T item);
    
    Task<T> Update(Guid id, T item);
    
}