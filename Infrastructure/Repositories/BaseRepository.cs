using Core.Exceptions;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public ContexDB _context;
        public readonly DbSet<T> _dbSet;

        public BaseRepository(ContexDB context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                var dataResult = await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return dataResult.Entity;
            }
            catch (Exception ex)
            {
                LogException logException = new LogException();
                logException.Message = ex.Message;
                logException.Name = "BaseRepository";
                throw new InternalServerErrorBusinessExceptions(logException);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                LogException logException = new LogException();
                logException.Message = ex.Message;
                logException.Name = "BaseRepository";
                throw new InternalServerErrorBusinessExceptions(logException);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                LogException logException = new LogException();
                logException.Message = ex.Message;
                logException.Name = "BaseRepository";
                throw new InternalServerErrorBusinessExceptions(logException);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var result = await _dbSet.FindAsync(id);
                return result ?? null;
            }
            catch (Exception ex)
            {
                LogException logException = new LogException();
                logException.Message = ex.Message;
                logException.Name = "BaseRepository";
                throw new InternalServerErrorBusinessExceptions(logException);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                LogException logException = new LogException();
                logException.Message = ex.Message;
                logException.Name = "BaseRepository";
                throw new InternalServerErrorBusinessExceptions(logException);
            }
        }
    }
}
