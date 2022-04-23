using Dukkantek_WebAPI.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dukkantek_WebAPI.Repository;

namespace Dukkantek_WebAPI.Authentication.APIKey
{
    public class GetApiKeys : IGetAllApiKeysQuery
    {
        private readonly IDictionary<string, APIKeyModel> _apiKeys;
        private readonly IApplicationHelper iapplicationhelper;
        public GetApiKeys(IApplicationHelper iapplicationhelper)
        {
            this.iapplicationhelper = iapplicationhelper;
            var existingApiKeys = iapplicationhelper.GetApiKey();
            _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

        public Task<APIKeyModel> Execute(string providedApiKey)
        {
            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }
}
