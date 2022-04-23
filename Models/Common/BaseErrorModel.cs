using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Models
{
    public class BaseErrorModel
    {
        public BaseErrorModel()
        {
            this.Status = new ErrorModel();
        }

        public ErrorModel Status { get; set; }
    }

    public class ErrorModel
    {
        public string ResponseCode { get; set; }

        public string ResponseDescription { get; set; }
    }
}
