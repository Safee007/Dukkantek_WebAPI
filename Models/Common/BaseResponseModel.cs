using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Models
{   
    public class BaseResponseModel
    {
        public BaseResponseModel()
        {
            this.Status = new ResponseModel();
        }

        public ResponseModel Status { get; set; }
    }

    public class ResponseModel
    {
        public string ResponseCode { get; set; }

        public string ResponseDescription { get; set; }

    }
}
