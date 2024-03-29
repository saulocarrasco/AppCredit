﻿using System.Linq.Expressions;
using System.Net;
using AutoMapper;
using CreditApp.Core.Services;
using CreditApp.Infrastructure.Entities;
using CreditApp.Shared.Services.Common.Dtos;
using CreditApp.Shared.Services.Common.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreditApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly GenericService _genericService;
        private readonly IMapper _mapper;

        public AuthenticationController(GenericService genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        [HttpPost("insertuser")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Insert(User userModel)
        {

            var changesResult = 0;
            User model = null;

            try
            {
                userModel.CreationDate = DateTimeOffset.UtcNow.AddHours(-4);
                userModel.IsDeleted = false;
                userModel.Password = PasswordHelper.GetHash(userModel.Password);

                model = await _genericService.Insert(userModel);
                
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

        [HttpPost("login")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public User Login(UserCredentialsDto dataModel)
        {

            Expression<Func<User, bool>> where = i => i.UserName == dataModel.UserNameOrEmail || i.Email == PasswordHelper.GetHash(dataModel.UserNameOrEmail);

           var model = _genericService.Get(where: where);

            return model;
        }

    }
}
