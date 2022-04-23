using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Models
{
    public class AuthTokenModel
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }

    }
}
