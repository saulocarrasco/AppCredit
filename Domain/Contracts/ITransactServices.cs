using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ITransactServices<TModel>
    {
        Task<IEnumerable<TModel>> GetAll();
        Task Insert(TModel model);
        Task Update(TModel model);
        Task Delete(TModel model);
        Task SavesChanges();
    }
}
