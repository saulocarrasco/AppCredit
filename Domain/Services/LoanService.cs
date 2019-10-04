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
            var feeAmount = capital * Convert.ToDecimal(formulaRigth);

            var currentCapital = capital;
            var currentStartDate = startDate;

            for (int i = 0; i <= quantityAliquot; i++)
            {
                //interes pagado
                decimal interestPaid = currentCapital * Convert.ToDecimal(bankRateFixed);

                //pago a capital
                decimal paymentToCapital = feeAmount - interestPaid;

                var feeDetail = new FeeInformation
                {
                    TotalFee = feeAmount,
                    CapitalPayment = paymentToCapital,
                    RateAmount = interestPaid,
                    CurrentAmount = currentCapital,
                    CreationDate = DateTimeOffset.UtcNow.AddHours(-4),
                    IsDeleted = false,
                    DeletedDate = null
                };

                feeDetail.Date = currentStartDate.AddDays(modality);

                loadDetails.Add(feeDetail);

                currentStartDate = feeDetail.Date;
                currentCapital -= paymentToCapital;
            }

            loan.End = loadDetails.LastOrDefault().Date;
            loan.FeeInformations = loadDetails;

            return loan;
        }
    }
}
