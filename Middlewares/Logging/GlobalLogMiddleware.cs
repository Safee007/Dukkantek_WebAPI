using Microsoft.AspNetCore.Http;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;

namespace Dukkantek_WebAPI.Middlewares.Logging
{
    public class GlobalLogMiddleware
    {
        private readonly RequestDelegate _next;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Logger loggerImages = LogManager.GetLogger("imagesLogFile");

        public GlobalLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sessionId = string.Format("{0}{1}", DateTime.Now.Ticks, Thread.CurrentThread.ManagedThreadId);
            context.Request.Headers.Add("SessionID", sessionId);

            

            var requestMessage = await FormatRequest(context.Request);
            var requestInfo = string.Format("{0} {1}", context.Request.Method, context.Request.GetDisplayUrl());
            string IPAddress = "";

            try
            {
                IPAddress = context.Connection.RemoteIpAddress.ToString();
            }
            catch
            {
                
            }

             var originalBodyStream = context.Response.Body;

            await Log("REQUEST", sessionId, requestInfo, requestMessage, IPAddress);

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                var response = await FormatResponse(context.Response);

                await Log("RESPONSE", sessionId, requestInfo, response, IPAddress);

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            var body = request.Body;

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            await request.Body.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body.Position = 0;

            request.Body = body;

            if (bodyAsText == "")
            {
                bodyAsText = "(No body present)";
            }

            return bodyAsText;
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            string text = await new StreamReader(response.Body).ReadToEndAsync();

            if (text == "")
            {
                text = "(No body present)";
            }

            response.Body.Seek(0, SeekOrigin.Begin);

            return $"{response.StatusCode}: {text}";
        }

        private async Task Log(string message, string sessionId, string requestInfo, string body, string clientIP)
        {
            if (requestInfo.Contains("userImages") || requestInfo.Contains("DocumentImages") || requestInfo.Contains("DocumentImages") || requestInfo.Contains("VerificationInformation"))
            {
                await Task.Run(() =>
                {
                    loggerImages.Info(string.Format("Client IP: {0} SessionID: {1} | {2}: {3} | Body: {4}", clientIP, sessionId, message, requestInfo, body));
                });
            }
            else
            {
                await Task.Run(() =>
                {
                    logger.Info(string.Format("Client IP: {0} SessionID: {1} | {2}: {3} | Body: {4}", clientIP, sessionId, message, requestInfo, body));
                });
            }
        }
    }
}
