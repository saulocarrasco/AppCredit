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
        public Loan GetAmortization(decimal capital, double bankRate, int quantityAliquot, int modality, DateTimeOffset startDate)
        {

            List<FeeInformation> loadDetails = new List<FeeInformation>();

            var loan = new Loan
            {
                CreationDate = DateTimeOffset.UtcNow.AddHours(-4),
                PaymentMethod = (PaymentMethod)modality,
                Begining = startDate,
                IsDeleted = false
            };

            var bankRateFixed = bankRate / 100; /// modality;
            var dividend = ((Math.Pow((1 + bankRateFixed), quantityAliquot)) * bankRateFixed);
            var divider = (Math.Pow((1 + bankRateFixed), quantityAliquot) - 1);
            var formulaRigth = dividend / divider;

            //cuota
            var feeAmount = capital * Convert.ToDecimal(formulaRigth);

            var currentCapital = capital;

            for (int i = 0; i <= quantityAliquot; i++)
            {
                //interes pagado
                decimal interestPaid = currentCapital * Convert.ToDecimal(bankRateFixed);

                //pago a capital
                decimal paymentToCapital = feeAmount - interestPaid;

                loadDetails.Add(new FeeInformation
                {
                    TotalFee = feeAmount,
                    CapitalPayment = paymentToCapital,
                    RateAmount = interestPaid,
                    CurrentAmount = currentCapital,
                    CreationDate = DateTimeOffset.UtcNow.AddHours(-4),
                    IsDeleted = false,
                    DeletedDate = null
                });

                currentCapital -= paymentToCapital;
            }

            loan.FeeInformations = loadDetails;

            return loan;
        }
    }
}
