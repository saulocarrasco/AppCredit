using System.Linq.Expressions;
using AutoMapper;
using CreditApp.Core.Contracts;
using CreditApp.Core.Services;
using CreditApp.Infrastructure.Entities;
using CreditApp.Shared.Services.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CreditApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly GenericService _genericService;
        private readonly IMapper _mapper;
        private readonly ILoanService _creditService;

        public LoanController(GenericService genericService, IMapper mapper, ILoanService creditService)
        {
            _genericService = genericService;
            _mapper = mapper;
            _creditService = creditService;
        }

        // GET: api/GetAmortization
        [HttpPost("getamortization")]
        public Loan GetAmortization(LoanStartInformationDto loanStartInformationDto)
        {
            return _creditService.GetAmortization(loanStartInformationDto.Capital, loanStartInformationDto.BankRate, loanStartInformationDto.QuantityAliquot, loanStartInformationDto.Modality, loanStartInformationDto.StartDate);
        }

        [HttpGet("getloansofdate")]
        public IEnumerable<Loan> GetLoansOfDate()
        {
            Expression<Func<Loan, bool>> expresionFilter = i => i.Begining.Date <= DateTimeOffset.UtcNow.AddHours(-4).Date
            && i.End > DateTimeOffset.UtcNow.AddHours(-4) && i.FeeInformations.Any(f => f.FeeState == FeeState.Pending);


            return _genericService.GetAll("FeeInformations,Customer", expresionFilter);
        }

        [HttpGet("getloan/{id}")]
        public Loan GetLoan(int id)
        {
            Loan loan = _genericService.Get<Loan>("FeeInformations,Customer", i=>i.Id == id);
            var feeInformationsOrder = loan.FeeInformations.OrderBy(i => i.Date);
            loan.FeeInformations = feeInformationsOrder;

            return loan;
        }

        [HttpPost("createloan")]
        public async Task CreateLoan(LoanInformationDto loanInformationDto)
        {
            var loan = new Loan
            {
                CustomerId = loanInformationDto.CustomerId,
                CreationDate = DateTimeOffset.UtcNow.AddHours(-4),
                Begining = loanInformationDto.BasicInfoLoan.StartDate,
                FeeInformations = loanInformationDto.LoanInformation,
                PaymentMethod = (PaymentMethod)loanInformationDto.BasicInfoLoan.Modality,
                FeesNumber = loanInformationDto.BasicInfoLoan.QuantityAliquot,
                LoanAmount = loanInformationDto.BasicInfoLoan.Capital,
                GrossProfit = loanInformationDto.LoanInformation.Sum(i=>i.TotalFee),
                End = loanInformationDto.LoanInformation.LastOrDefault().Date,
                BankRate = loanInformationDto.BasicInfoLoan.BankRate
            };

            await _genericService.Insert(loan);

            await _genericService.SavesChanges();
        }

        [HttpPost("payFee")]
        public async Task PayFee(FeeInformationDto feeInformation)
        {
            Expression<Func<FeeInformation, bool>> where = i => i.Id == feeInformation.Id && i.LoanId == feeInformation.LoanId;
            var fee = _genericService.Get(where: where);
            fee.FeeState = FeeState.PaidOut;
            fee.SurCharge = feeInformation.SurCharge;

            var payment = new Payment
            {
                TotalAmount = fee.TotalFee,
                CapitalPayment = fee.CapitalPayment,
                Profit = fee.RateAmount,
                LoanId = fee.LoanId.Value,
                Date = DateTimeOffset.UtcNow.AddHours(-4),
                CreationDate = DateTimeOffset.UtcNow.AddHours(-4),
                SurCharge = feeInformation.SurCharge
            };

            _genericService.Update(fee);

            await _genericService.Insert(payment);

            await _genericService.SavesChanges();
        }
    }
}