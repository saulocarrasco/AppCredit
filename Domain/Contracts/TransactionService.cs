using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public abstract class TransactionService
    {
        protected readonly DbContext _dbContext;

        public TransactionService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TModel Get<TModel>(string includes = null, Expression<Func<TModel, bool>> where = null) where TModel : TransactionEntity
        {
            var result = _dbContext.Set<TModel>().AsQueryable();

            if (!string.IsNullOrEmpty(includes))
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    result = result.Include(includeProperty);
                }
            }

            return result.FirstOrDefault(where.Compile());
        }

        public void Delete<TModel>(TModel model) where TModel : TransactionEntity
        {
            model.IsDeleted = true;
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public IEnumerable<TModel> GetAll<TModel>(string includes = null, Expression<Func<TModel, bool>> where = null) where TModel : TransactionEntity
        {
            var result = _dbContext.Set<TModel>().AsQueryable();

            if(!string.IsNullOrEmpty(includes))
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    result = result.Include(includeProperty);
                }
            }
            
            if (where != null)
                result = result.Where(where);

            return result.AsEnumerable();
        }

        public async Task<TModel> Insert<TModel>(TModel model) where TModel : TransactionEntity
        {
            await _dbContext.Set<TModel>().AddAsync(model);

            return model;
        }

        public async Task<int> SavesChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Update<TModel>(TModel model) where TModel : TransactionEntity
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
