using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AppCredit.Api.Dtos;
using Data.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCredit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly GenericService _genericService;

        public CustomerController(GenericService genericService)
        {
            _genericService = genericService;
        }

        // GET: api/Addresses
        [HttpGet]
        public Task<IEnumerable<Customer>> GetCustomers()
        {
            return _genericService.GetAll<Customer>(null, "");
        }

        [HttpPost("insert")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Insert([FromForm]CustomerDto customer)
        {
            //var model = await _genericService.Insert(customer);
            //var changesResult = await _genericService.SavesChanges();

            //if (changesResult > 0)
            //{
            //    return Ok(model);
            //}

            return Ok(1);
           // return BadRequest();
        }
    }
}