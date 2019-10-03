using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ILoanService
    {
        Loan GetAmortization(decimal capital, decimal bankRate, int quantityAliquot, int modality, DateTimeOffset startDate);
    }
}
