using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Authorization
{
    public class OnlyPortalRequirment : IAuthorizationRequirement
    {
    }
}
