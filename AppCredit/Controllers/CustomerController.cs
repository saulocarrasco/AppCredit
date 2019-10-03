using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CustomerController : ControllerBase
    {
        private readonly GenericService _genericService;
        private readonly IMapper _mapper;

        public CustomerController(GenericService genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        // GET: api/Addresses
        [HttpGet]
        public Task<IEnumerable<Customer>> GetCustomers()
        {
            return _genericService.GetAll<Customer>(null, "Addresses,Identifications,Credits");
        }

        [HttpPost("insert")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Insert([FromBody]CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            customer.CreationDate = DateTimeOffset.UtcNow.AddHours(-4);
            customer.IsDeleted = false;

            var model = await _genericService.Insert(customer);
            var changesResult = await _genericService.SavesChanges();

            if (changesResult > 0)
            {
                return Ok(model);
            }

            return BadRequest();
        }
    }
}