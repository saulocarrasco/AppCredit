using CreditApp.Infrastructure.Entities;

namespace CreditApp.Core.Contracts;
public interface ILoanService
{
    Loan GetAmortization(decimal capital, double bankRate, int quantityAliquot, int modality, DateTimeOffset startDate);
}
