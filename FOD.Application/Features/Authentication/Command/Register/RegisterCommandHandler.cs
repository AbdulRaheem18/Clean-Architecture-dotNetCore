using FOA.Application.Features.Users.Queries;
using FOA.Application.Mapper;
using FOA.Application.Services;
using FOD.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FOA.Application.Features.Authentication.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public RegisterCommandHandler(UserManager<IdentityUser> userManager
            )
        {
            _userManager = userManager;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {

            var userExists = await _userManager.FindByNameAsync(request.Username);
            if (userExists != null)
            {
                throw new ApplicationException("User already exist");
            }

            IdentityUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException("User creation failed");
            }

            if (request.Userrole == UserRoles.Admin)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            else
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            var registerResponse = FOAMapper.Mapper.Map<RegisterCommandResponse>(user);
            registerResponse.UserRole = request.Userrole;

            return registerResponse;



        }
    }

}
