using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ITransactionService<TModel>
    {
        Task<IEnumerable<TModel>> GetAll(string includes);
        Task<TModel> Insert(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
        Task<int> SavesChanges();
    }
}
