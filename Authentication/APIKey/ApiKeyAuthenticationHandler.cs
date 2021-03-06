using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Dukkantek_WebAPI.Models;
using Newtonsoft.Json;

namespace Dukkantek_WebAPI.Authentication.APIKey
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private const string ProblemDetailsContentType = "application/problem+json";
        private readonly IGetAllApiKeysQuery _getApiKeyQuery;
        private const string ApiKeyHeaderName = "APIKey";
        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<ApiKeyAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IGetAllApiKeysQuery getApiKeyQuery) : base(options, logger, encoder, clock)
        {
            _getApiKeyQuery = getApiKeyQuery ?? throw new ArgumentNullException(nameof(getApiKeyQuery));
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyHeaderValues))
            {
                return AuthenticateResult.NoResult();
            }

            var providedApiKey = apiKeyHeaderValues.FirstOrDefault();

            if (apiKeyHeaderValues.Count == 0 || string.IsNullOrWhiteSpace(providedApiKey))
            {
                return AuthenticateResult.NoResult();
            }

            var existingApiKey = await _getApiKeyQuery.Execute(providedApiKey);

            if (existingApiKey != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, existingApiKey.Owner)
            };

                claims.AddRange(existingApiKey.Roles.Select(role => new Claim(ClaimTypes.Role, role)));

                var identity = new ClaimsIdentity(claims, Options.AuthenticationType);
                var identities = new List<ClaimsIdentity> { identity };
                var principal = new ClaimsPrincipal(identities);
                var ticket = new AuthenticationTicket(principal, Options.Scheme);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Invalid API Key provided.");
        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            BaseErrorModel errorModel = new BaseErrorModel();
            errorModel.Status.ResponseCode = "401";
            errorModel.Status.ResponseDescription = "Invalid API Key";

            var errorObject = JsonConvert.SerializeObject(errorModel);

            Response.StatusCode = 401;

            Response.ContentType = ProblemDetailsContentType;

            await Response.WriteAsync(errorObject);
        }

        protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            BaseErrorModel errorModel = new BaseErrorModel();
            errorModel.Status.ResponseCode = "401";
            errorModel.Status.ResponseDescription = "Invalid Token";

            var errorObject = JsonConvert.SerializeObject(errorModel);

            Response.StatusCode = 401;

            Response.ContentType = ProblemDetailsContentType;

            await Response.WriteAsync(errorObject);
        }
    }
}
