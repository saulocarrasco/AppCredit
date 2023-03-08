using System.Linq.Expressions;
using AutoMapper;
using CreditApp.Core.Services;
using CreditApp.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CreditApp.Api.Controllers
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
            var result = _genericService.GetAll("Loan,Loan.Customer", where: where);

            return result;
        }
    }
}