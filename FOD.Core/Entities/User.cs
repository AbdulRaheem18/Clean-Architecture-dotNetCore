using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FOD.Core.Entities
{
    public class User : IdentityUser
    {
        public UserType UserType { get; set; }  

    }
}
