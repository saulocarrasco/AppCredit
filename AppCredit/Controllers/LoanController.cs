using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet]
        public Loan GetAmortization(LoanStartInformationDto loanStartInformationDto)
        {
            return _creditService.GetAmortization(loanStartInformationDto.Capital, loanStartInformationDto.BankRate, loanStartInformationDto.QuantityAliquot, loanStartInformationDto.Modality, loanStartInformationDto.StartDate);
        }
    }
}