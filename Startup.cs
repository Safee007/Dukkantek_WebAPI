using Dukkantek_WebAPI.Authentication.APIKey;
using Dukkantek_WebAPI.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Dukkantek_WebAPI.Middlewares.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dukkantek_WebAPI.Repository;
using Dukkantek_WebAPI.Helper;
using Dukkantek_WebAPI.Middlewares;
using System.Text.Json.Serialization;
using System.Globalization;
using Dukkantek_WebAPI.Context;
using Microsoft.EntityFrameworkCore;
using Dukkantek_WebAPI.DAL;
using Dukkantek_WebAPI.Repository.IDAL;

namespace Dukkantek_WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var logger = NLogBuilder.ConfigureNLog("Nlog.config").GetCurrentClassLogger();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();

            services.AddDbContext<DukkantekDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("ConnectionCon")));

            services.AddSingleton<IGetAllApiKeysQuery, GetApiKeys>();
            services.AddSingleton<IApplicationHelper, ApplicationHelper>();
            services.AddScoped<IProductCategoriesPost, ProductCategoriesPost>();
            services.AddScoped<IProducts, ProductsPost>();
            services.AddScoped<IProductSales, ProductSalesPost>();


            services.AddControllers()
               .AddNewtonsoftJson();

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    //options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Use this to avoid auto lower case conversion
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            })
            .AddApiKeySupport(options => { });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.OnlyDevelopers, policy => policy.Requirements.Add(new OnlyDevelopersRequirement()));
            });


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSingleton<IAuthorizationHandler, OnlyDevelopersAuthorizationHandler>();

            services.AddCors();

            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader()
                );


            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                        ForwardedHeaders.XForwardedProto
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.ConfigureCustomExceptionMiddleware();

            app.UseMiddleware<GlobalLogMiddleware>();

            app.UseMiddleware<APIKeyMiddleware>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
