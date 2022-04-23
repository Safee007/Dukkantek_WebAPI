using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotex_WebAPI.Models.Common
{
    public class Tokenization
    {
        public string Token { get; set; }
        public string TokenType { get; set; }
        public string Expiry { get; set; }
    }
}
