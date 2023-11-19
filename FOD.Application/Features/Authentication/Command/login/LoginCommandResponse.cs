using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FOA.Application.Features.Authentication.Command.login
{
    public class LoginCommandResponse
    {
        public List<Claim> authClaims { set; get; }
    }
}
