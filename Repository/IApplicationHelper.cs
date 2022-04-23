using Dukkantek_WebAPI.Authentication.APIKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Repository
{
    public interface IApplicationHelper
    {
        void LoadAPIKeys();

        bool IsValidAPIKey(string value);

        List<APIKeyModel> GetApiKey();
    }
}
