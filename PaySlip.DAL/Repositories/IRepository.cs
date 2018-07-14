using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaySlip.DAL.Repositories
{

  
    public interface IRepository<TEntity> where TEntity : class
    {
       
        TEntity Get(int id);

        Task<TEntity> GetAsnyc(int id);

        IEnumerable<TEntity> GetAll();

        
        Task<IEnumerable<TEntity>> GetAllAsync();

       
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }

  
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {

        private readonly DbSet<TEntity> _dbSet;
        public Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork), @"Unit of work cannot be null");
            }

            _dbSet = unitOfWork.DatabaseContext.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

      
        public async Task<TEntity> GetAsnyc(int id)
        {
            return await _dbSet.FindAsync(id);
        }

      
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();

        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

    }
}
