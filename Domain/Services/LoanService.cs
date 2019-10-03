using Data.Entities;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class LoanService : ILoanService
    {
        public Loan GetAmortization(decimal capital, decimal bankRate, int quantityAliquot, int modality, DateTimeOffset startDate)
        {

            IEnumerable<FeeInformation> loadDetails = new List<FeeInformation>();

            var loan = new Loan
            {
                CreationDate = DateTimeOffset.UtcNow.AddHours(-4),
                PaymentMethod = (PaymentMethod)modality,
                Begining = startDate
            };

            for (int i = 0; i <= quantityAliquot; i++)
            {

            }

            return loan;
        }
    }
}
