namespace infrastructure.Interfaces;

public interface IRepository<T> where T : class
{
    
    Task<bool> Delete(Guid id);
    
    Task<T> Create(T item);
    
    Task<T> Update(Guid id, T item);
}