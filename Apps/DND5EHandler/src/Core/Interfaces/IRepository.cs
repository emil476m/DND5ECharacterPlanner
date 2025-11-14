using Core.Models;

namespace Core.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetResult(Guid id);

    Task<IEnumerable<DndEntitySimpleModel>> GetSimpleList();

    Task<IEnumerable<T>> GetDetailedList();

    Task<bool> Delete(Guid id);

    Task<T> Create(T item);

    Task<T> Update(Guid id, T item);
}