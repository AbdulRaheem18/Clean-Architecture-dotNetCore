using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOA.Application.Features.Authentication.Command.Register
{
    public class RegisterCommandResponse
    {
        public string Username {  get; set; }

        public string UserRole { get; set; }

        public string Id { get; set; }

    }
}
