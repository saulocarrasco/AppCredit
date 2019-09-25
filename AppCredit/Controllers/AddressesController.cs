using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppCredit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GenericService _genericService;

        public AddressesController(GenericService genericService)
        {
            _genericService = genericService;
        }

        // GET: api/Addresses
        [HttpGet]
        public Task<IEnumerable<Address>> GetAddresses()
        {
            return _genericService.GetAll<Address>(null, "");
        }

        [HttpPost]
        public async Task<ActionResult> Insert(Address address)
        {
            var model = await _genericService.Insert(address);
            var changesResult = await _genericService.SavesChanges();

            if(changesResult > 0)
            {
                return Ok(model);
            }

            return BadRequest();
        }
    }
}
