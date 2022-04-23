using Dukkantek_WebAPI.Authentication.APIKey;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dukkantek_WebAPI.Repository;
using Dukkantek_WebAPI.Authorization;

namespace Dukkantek_WebAPI.Helper
{

    public class ApplicationHelper : IApplicationHelper
    {

        private static Dictionary<string, string> dicAPIKeys;
        
        IConfiguration _iConfiguration;

        public ApplicationHelper(IConfiguration configuration)
        {
            LoadAPIKeys();
            _iConfiguration = configuration;
            
        }

        public void LoadAPIKeys()
        {
            dicAPIKeys = new Dictionary<string, string>();
            dicAPIKeys.Add("010", "a3b5b5a782f3636a46d0021ec3fab6e991fb7701f9e813574c616901bfa3adb5");
        }

        public bool IsValidAPIKey(string value)
        {
            if (dicAPIKeys.ContainsValue(value))
            {
                string key = dicAPIKeys.FirstOrDefault(r => r.Value == value).Key;

                if (dicAPIKeys.ContainsKey(key))
                {
                    return true;
                }
            }

            return false;
        }
        
        public List<APIKeyModel> GetApiKey()
        {
            List<APIKeyModel> modelList = new List<APIKeyModel>();


            List<string> roles = new List<string>();
            roles.Add(Roles.Developer);
                            

            APIKeyModel model = new APIKeyModel(1, "Developer", "a3b5b5a782f3636a46d0021ec3fab6e991fb7701f9e813574c616901bfa3adb5", DateTime.Now, roles); ;

            return modelList;
        }
    }
}
