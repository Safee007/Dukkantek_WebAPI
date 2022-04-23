using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Authorization
{
    public class OnlyDevelopersAuthorizationHandler : AuthorizationHandler<OnlyDevelopersRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyDevelopersRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Developer))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
