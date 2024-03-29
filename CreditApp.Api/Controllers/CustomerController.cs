﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using CreditApp.Core.Services;
using AutoMapper;
using CreditApp.Infrastructure.Entities;
using CreditApp.Shared.Services.Common.Dtos;

namespace CreditApp.Api.Controllers
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
        public IEnumerable<Customer> GetCustomers()
        {
            var result = _genericService.GetAll<Customer>("Addresses,Identifications,Loans");

            return result;
        }

        [HttpGet("delete/{id}")]
        public async Task<int> Delete(int id)
        {
            Expression<Func<Customer, bool>> where = i => i.Id == id;

            var result = _genericService.Get("Loans", where);

            if (result.Loans.Count() > 0)
            {
                foreach (var loan in result.Loans)
                {
                    loan.IsDeleted = true;
                    _genericService.Update(loan);
                }
            }

            _genericService.Delete(result);

            return await _genericService.SavesChanges();
        }

        [HttpPost("insert")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Insert([FromBody] CustomerDto customerDto)
        {

            var changesResult = 0;
            Customer model = null;

            try
            {
                var customer = _mapper.Map<Customer>(customerDto);

                customer.CreationDate = DateTimeOffset.UtcNow.AddHours(-4);
                customer.IsDeleted = false;

                model = await _genericService.Insert(customer);

                changesResult = await _genericService.SavesChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            if (changesResult > 0)
            {
                return Ok(model);
            }

            return BadRequest();
        }
    }
}