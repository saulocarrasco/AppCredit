using Data.Entities;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GenericService : TransactionService
    {
        public GenericService(DbContext dbContext) :base(dbContext)
        {

        }
    }
}
