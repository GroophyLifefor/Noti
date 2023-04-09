using Microsoft.EntityFrameworkCore;
using Noti.Data.Abstract;
using Noti.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace Noti.Data.Concrete;

public class Repository<T> : IRepository<T> where T : class, IEntity, new()
{
    internal DatabaseContext _context;
    internal DbSet<T> _dbSet;

    public Repository(DatabaseContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public T Find(int id)
    {
        return _dbSet.Find(id);
    }

    public async Task<T> FindAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public T Get(Expression<Func<T, bool>> expression)
    {
        return _dbSet.FirstOrDefault(expression);
    }

    public List<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public List<T> GetAll(Expression<Func<T, bool>> expression = null, Expression<Func<T, object>> include = null)
    {
        IQueryable<T> result = _dbSet;
        if (expression is not null)
            result = result.Where(expression);

        if (include is not null)
            result = result.Include(include);

        return result.ToList();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.Where(expression).ToListAsync();
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> expression)
    {
        return _dbSet.FirstOrDefaultAsync(expression);
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }
}
