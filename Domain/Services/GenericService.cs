using Data.Entities;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GenericService<TModel> : ITransactionService<TModel> where TModel : class, ITransactionEntity
    {
        private readonly DbContext _dbContext;
        public GenericService(DbContext dbContext) => _dbContext = dbContext;

        public void Delete(TModel model)
        {
            model.IsDeleted = true;
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public async Task<IEnumerable<TModel>> GetAll(string includes)
        {
            var result = await _dbContext.Set<TModel>().Include(includes).ToArrayAsync();

            return result;
        }

        public async Task<TModel> Insert(TModel model)
        {
            await _dbContext.Set<TModel>().AddAsync(model);

            return model;
        }

        public async Task<int> SavesChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Update(TModel model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
