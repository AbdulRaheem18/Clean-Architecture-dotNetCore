using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOA.Application.Features.Authentication.Command.Register
{
    public class RegisterCommandRequest :IRequest<RegisterCommandResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Userrole { get; set; }

    }
}
