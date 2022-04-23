using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Authentication.APIKey
{
    public interface IGetAllApiKeysQuery
    {
        Task<APIKeyModel> Execute(string providedApiKey);
    }
}
