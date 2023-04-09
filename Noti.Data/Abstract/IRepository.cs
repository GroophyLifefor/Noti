using System.Linq.Expressions;

namespace Noti.Data.Abstract;

public interface IRepository<T> where T : class
{
    // Sync Methots
    List<T> GetAll();
    List<T> GetAll(Expression<Func<T, bool>> expression = null, Expression<Func<T, object>> include = null);
    T Get(Expression<Func<T, bool>> expression);
    T Find(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    int Save();

    // Async Methots
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    Task<T> GetAsync(Expression<Func<T, bool>> expression);
    Task<T> FindAsync(int id);
    Task AddAsync(T entity);
    Task<int> SaveAsync();
}
