using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public Loan GetAmortization(decimal capital, decimal bankRate, int quantityAliquot, int modality)
        {
            // return _creditService.GetAmortization(capital, bankRate, quantityAliquot, modality, DateTimeOffset.UtcNow);
            return _creditService.GetAmortization(10000, 0.666, 42, 360, DateTimeOffset.UtcNow);
        }
    }
}