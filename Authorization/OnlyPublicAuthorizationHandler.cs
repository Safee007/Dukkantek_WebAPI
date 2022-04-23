using Dukkantek_WebAPI.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Authorization
{
    public class OnlyPublicAuthorizationHandler : AuthorizationHandler<OnlyPublicRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyPublicRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Public))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
