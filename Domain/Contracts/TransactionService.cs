using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public abstract class TransactionService
    {
        protected readonly DbContext _dbContext;

        public void Delete<TModel>(TModel model) where TModel : class, ITransactionEntity
        {
            model.IsDeleted = true;
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public async Task<IEnumerable<TModel>> GetAll<TModel>(string includes) where TModel : class, ITransactionEntity
        {
            var result = await _dbContext.Set<TModel>().Include(includes).ToArrayAsync();

            return result;
        }

        public async Task<TModel> Insert<TModel>(TModel model) where TModel : class, ITransactionEntity
        {
            await _dbContext.Set<TModel>().AddAsync(model);

            return model;
        }

        public async Task<int> SavesChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Update<TModel>(TModel model) where TModel : class, ITransactionEntity
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
