using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCredit.Api.Dtos
{
    public class UserCredentialsDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
