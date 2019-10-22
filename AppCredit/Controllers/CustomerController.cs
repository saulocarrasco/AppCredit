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
using System.Linq.Expressions;

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
        public IEnumerable<Customer> GetCustomers()
        {
            var result = _genericService.GetAll<Customer>("Addresses,Identifications,Loans");

            return result;
        }

        [HttpGet("delete/{id}")]
        public async Task<int> Delete(int id)
        {
            Expression<Func<Customer, bool>> where = i => i.Id == id;

            var result = _genericService.Get(where: where);
            _genericService.Delete(result);

            return await _genericService.SavesChanges();
        }

        [HttpPost("insert")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Insert([FromBody]CustomerDto customerDto)
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