using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using AppCredit.Api.Dtos;
using AutoMapper;
using Data.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCredit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly GenericService _genericService;
        private readonly IMapper _mapper;

        public PaymentController(GenericService genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        // GET: api/Addresses
        [HttpGet("getpaymentsdate")]
        public IEnumerable<Payment> GetPaymentsDate()
        {
            Expression<Func<Payment, bool>> where = i => i.Date.Date == DateTimeOffset.UtcNow.AddHours(-4).Date;
            var result = _genericService.GetAll(where: where);

            return result;
        }
    }
}