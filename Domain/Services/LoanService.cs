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

            List<FeeInformation> loadDetails = new List<FeeInformation>();

            var loan = new Loan
            {
                CreationDate = DateTimeOffset.UtcNow.AddHours(-4),
                PaymentMethod = (PaymentMethod)modality,
                Begining = startDate,
                IsDeleted = false
            };

            var bankRateFixed = bankRate; /// modality;
            var feeAmount = capital * Convert.ToDecimal((Math.Pow((1 + Convert.ToDouble(bankRate)), quantityAliquot) * quantityAliquot) / (Math.Pow((1 + Convert.ToDouble(bankRate)), quantityAliquot) - 1));
           
            var currentCapital = capital;

            for (int i = 0; i <= quantityAliquot; i++)
            {
                decimal interesPagado = currentCapital * bankRateFixed;
                decimal pagoCapital = Convert.ToDecimal(feeAmount) - interesPagado;

                loadDetails.Add(new FeeInformation
                {
                    TotalFee = Convert.ToDecimal(feeAmount),
                    CapitalPayment = pagoCapital,
                    CurrentAmount = currentCapital - Convert.ToDecimal(feeAmount),
                    CreationDate = DateTimeOffset.UtcNow.AddHours(-4),
                    IsDeleted = false,
                });

                currentCapital -= Convert.ToDecimal(feeAmount);
            }

            loan.FeeInformations = loadDetails;

            return loan;
        }
    }
}
