using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Dukkantek_WebAPI.Models;

namespace Dukkantek_WebAPI.Middlewares.Logging
{
    public class GlobalExceptionHandlingMiddleware
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await Task.Run(() =>
                {
                    logger.Info(string.Format("SessionID: {0} | Exception {1}",context.Request.Headers["SessionID"], ex));
                });
                
                await HandleExceptionMessageAsync(context, ex);
            }
        }

        private Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


            BaseErrorModel errorModel = new BaseErrorModel();
            errorModel.Status.ResponseCode = ((int)HttpStatusCode.InternalServerError).ToString();
            errorModel.Status.ResponseDescription = "Internal Server Error";

            var result = JsonConvert.SerializeObject(errorModel);

            return context.Response.WriteAsync(result);
        }
    }
}

