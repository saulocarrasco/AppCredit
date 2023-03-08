using CreditApp.Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CreditApp.Core.Services;
public class GenericService : TransactionService
{
    public GenericService(DbContext dbContext) : base(dbContext)
    {

    }
}

