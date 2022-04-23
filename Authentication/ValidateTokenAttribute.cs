
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Dukkantek_WebAPI.Models;


namespace Dukkantek_WebAPI.Authentication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ValidateTokenAttribute : ActionFilterAttribute
    {
        public ValidateTokenAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();


            IActionResult response = null;


            var connString = config.GetConnectionString("ConnectionCon");

            StringValues _token = "";
            context.HttpContext.Request.Headers.TryGetValue("Token", out _token);
            int UserId = ValidateToken(_token, connString);


            if (UserId == 0)
            {
                BaseErrorModel errorModel = new BaseErrorModel();
                errorModel.Status.ResponseCode = ((int)HttpStatusCode.Unauthorized).ToString();
                errorModel.Status.ResponseDescription = "Token Expired";

                var result = JsonConvert.SerializeObject(errorModel);

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                return;
            }
        }

        private int ValidateToken(string Token, string connectionString)
        {
            int UserId = 0;
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "spTelematics_ValidateUserToken";
                    cmd.Connection = sql;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Token", Token);

                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        if (dr.GetInt32(0) != 0)
                        {
                            UserId = dr.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                UserId = 0;
            }
            return UserId;
        }
    }
}
