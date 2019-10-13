using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AppCredit.Api.Dtos;
using AutoMapper;
using Data.Entities;
using Domain.Contracts;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppCredit.Api.Controllers
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
            && i.End < DateTimeOffset.UtcNow.AddHours(-4) && i.FeeInformations.Any(f => f.Date == DateTimeOffset.UtcNow.AddHours(-4).Date);

            expresionFilter = null;


            return _genericService.GetAll("FeeInformations,Customer", expresionFilter);
        }

        [HttpGet("getloan/{id}")]
        public Loan GetLoan(int id)
        {
            return _genericService.Get<Loan>("FeeInformations,Customer", i=>i.Id == id);
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
              //  LoanAmount = loanInformationDto.BasicInfoLoan.Capital
            };

            await _genericService.Insert(loan);

            await _genericService.SavesChanges();
        }
    }
}