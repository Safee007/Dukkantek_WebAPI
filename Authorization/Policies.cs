using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Authorization
{
    public static class Policies
    {
        public const string OnlyDevelopers = nameof(OnlyDevelopers);
        public const string OnlyPublic = nameof(OnlyPublic);
        public const string OnlyPortal = nameof(OnlyPortal);
        public const string Token = nameof(Token);
    }
}
