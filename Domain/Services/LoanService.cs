using Data.Entities;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class LoanService : ILoanService
    {
        public Loan GetAmortization(decimal capital, double bankRate, int quantityAliquot, int modality, DateTimeOffset startDate)
        {
            // var paymentMethod = (PaymentMethod) modality;

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
            var feeAmount = Math.Round(capital * Convert.ToDecimal(formulaRigth), 2);

            var currentCapital = capital;
            var currentStartDate = startDate;

            for (int i = 1; i <= quantityAliquot; i++)
            {
                //interes pagado
                decimal interestPaid = Math.Round(currentCapital * Convert.ToDecimal(bankRateFixed), 2);

                if (i == quantityAliquot)
                {
                    feeAmount = currentCapital;
                }

                //pago a capital
                decimal paymentToCapital = Math.Round((feeAmount - interestPaid), 2);


                var feeDetail = new FeeInformation
                {
                    TotalFee = feeAmount,
                    CapitalPayment = paymentToCapital,
                    RateAmount = interestPaid,
                    CurrentAmount = Math.Round(currentCapital, 2),
                    CreationDate = DateTimeOffset.UtcNow.AddHours(-4),
                    IsDeleted = false,
                    DeletedDate = null
                };

                currentStartDate = currentStartDate.AddDays(modality);

                if (currentStartDate.DayOfWeek == DayOfWeek.Sunday)
                {
                   currentStartDate = currentStartDate.AddDays(1);
                }

                feeDetail.Date = currentStartDate;

                loadDetails.Add(feeDetail);

                currentCapital -= paymentToCapital;
            }

            loan.End = loadDetails.LastOrDefault().Date;
            loan.FeeInformations = loadDetails;

            return loan;
        }

        public IEnumerable<Loan> GetCurrentLoans()
        {
            return null;
        }
    }
}
