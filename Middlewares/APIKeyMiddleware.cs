using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Dukkantek_WebAPI.Models;
using Dukkantek_WebAPI.Repository;

namespace Dukkantek_WebAPI.Middlewares
{
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "APIKey";

        IApplicationHelper applicatioHeler;
        public APIKeyMiddleware(RequestDelegate next, IApplicationHelper _applicatioHeler)
        {
            _next = next;
            applicatioHeler = _applicatioHeler;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            StringValues extractedApiKey = "";

            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out extractedApiKey))
            {
                BaseErrorModel errorModel = new BaseErrorModel();
                errorModel.Status.ResponseCode = ((int)HttpStatusCode.Unauthorized).ToString();
                errorModel.Status.ResponseDescription = "Invalid API Key";

                var result = JsonConvert.SerializeObject(errorModel);

                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                await context.Response.WriteAsync(result);
                return;
            }

            if (!applicatioHeler.IsValidAPIKey(extractedApiKey))
            {
                BaseErrorModel errorModel = new BaseErrorModel();
                errorModel.Status.ResponseCode = ((int)HttpStatusCode.Unauthorized).ToString();
                errorModel.Status.ResponseDescription = "Invalid API Key";

                var result = JsonConvert.SerializeObject(errorModel);

                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                await context.Response.WriteAsync(result);
                return;
            }

            await _next(context);
        }
    }
}
