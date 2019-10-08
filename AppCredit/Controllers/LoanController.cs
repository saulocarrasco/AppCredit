﻿using System;
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
        [HttpPost]
        public Loan GetAmortization(LoanStartInformationDto loanStartInformationDto)
        {
            return _creditService.GetAmortization(loanStartInformationDto.Capital, loanStartInformationDto.BankRate, loanStartInformationDto.QuantityAliquot, loanStartInformationDto.Modality, loanStartInformationDto.StartDate);
        }

        public IEnumerable<Loan> GetLoansOfDate()
        {
            Expression<Func<Loan, bool>> expresionFilter = i => i.Begining.Date <= DateTimeOffset.UtcNow.AddHours(-4).Date
            && i.End < DateTimeOffset.UtcNow.AddHours(-4) && i.FeeInformations.Any(f => f.Date == DateTimeOffset.UtcNow.AddHours(-4).Date);


            return _genericService.GetAll("FeeInformations, Customer", expresionFilter);
        }
    }
}