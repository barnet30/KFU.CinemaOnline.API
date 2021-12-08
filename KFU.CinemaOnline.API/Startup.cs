using System;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using KFU.CinemaOnline.BL;
using KFU.CinemaOnline.Common;
using KFU.CinemaOnline.DAL;
using KFU.CinemaOnline.DAL.Account;
using KFU.CinemaOnline.DAL.Cinema;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Rest;
using Newtonsoft.Json;

namespace KFU.CinemaOnline.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(typeof(ApiMapperProfile));
                cfg.AddProfile(typeof(BlMapperProfile));
            });
            services.AddControllers();

            services.Configure<AuthOptions>(Configuration.GetSection("Auth"));
            
            var authOptions = Configuration.GetSection("Auth").Get<AuthOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,

                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,

                        ValidateLifetime = true,

                        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });
                
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            services.AddSwaggerGen(c =>
            {
                var assemblyVersion = new Version("1.0");
                c.CustomSchemaIds(type => type.ToString());
                c.CustomOperationIds(d => (d.ActionDescriptor as ControllerActionDescriptor)?.ActionName);
                c.SwaggerDoc($"v{assemblyVersion}", new OpenApiInfo
                {
                    Version = $"v{assemblyVersion}",
                    Title = "KFU CinemaOnline API",
                });
            });
            services.AddMvc();
            
            services.AddDbContextPool<AccountDbContext>(x =>
                x.UseNpgsql(Configuration.GetConnectionString("AccountConnectionString")));
            services.AddDbContextPool<CinemaDbContext>(x =>
                x.UseNpgsql(Configuration.GetConnectionString("CinemaConnectionString")));

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DataAccessDependencyModule>();
            
            builder.RegisterModule<BusinessLogicDependencyModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(context => GlobalErrorHandler(context, env));
            });

            app.UseStatusCodePages();

            app.UseSwagger(c => { c.SerializeAsV2 = true; });

            app.UseSwaggerUI(c =>
            {
                var assemblyVersion = new Version("1.0");
                const string apiName = "KFU CinemaOnline";
                c.SwaggerEndpoint($"/swagger/v{assemblyVersion}/swagger.json", $"{apiName} API V{assemblyVersion}");
                c.RoutePrefix = string.Empty;
                c.DocumentTitle = $"{apiName} Documentation";
                c.DocExpansion(DocExpansion.None);
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private static async Task GlobalErrorHandler(HttpContext context, IHostEnvironment env)
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

            var commonError = exceptionHandlerPathFeature?.Error;
            if (commonError == null)
            {
                return;
            }

            int statusCode;
            string errorType;
            string message;

            switch (commonError)
            {
                case HttpOperationException httpError:
                {
                    switch (httpError.Response.StatusCode)
                    {
                        case HttpStatusCode.BadRequest:
                            statusCode = (int) HttpStatusCode.BadRequest;
                            errorType = HttpStatusCode.BadRequest.ToString();
                            break;
                        case HttpStatusCode.NotFound:
                            statusCode = (int) HttpStatusCode.NotFound;
                            errorType = HttpStatusCode.NotFound.ToString();
                            break;
                        case HttpStatusCode.Conflict:
                            statusCode = (int) HttpStatusCode.Conflict;
                            errorType = HttpStatusCode.Conflict.ToString();
                            break;
                        case HttpStatusCode.Forbidden:
                            statusCode = (int) HttpStatusCode.Forbidden;
                            errorType = HttpStatusCode.Forbidden.ToString();
                            break;
                        case HttpStatusCode.MethodNotAllowed:
                            statusCode = (int) HttpStatusCode.MethodNotAllowed;
                            errorType = HttpStatusCode.Forbidden.ToString();
                            break;
                        case HttpStatusCode.Unauthorized:
                            statusCode = (int) HttpStatusCode.Unauthorized;
                            errorType = HttpStatusCode.Unauthorized.ToString();
                            break;
                        default:
                            statusCode = (int) HttpStatusCode.InternalServerError;
                            errorType = HttpStatusCode.InternalServerError.ToString();
                            break;
                    }

                    message = httpError.Response.Content;
                    break;
                }
                case UnauthorizedAccessException _:
                    statusCode = (int) HttpStatusCode.Unauthorized;
                    errorType = HttpStatusCode.Unauthorized.ToString();
                    message = commonError.Message;
                    break;
                default:
                    statusCode = (int) HttpStatusCode.InternalServerError;
                    errorType = HttpStatusCode.InternalServerError.ToString();
                    message = env.IsDevelopment() ? commonError.ToString() : commonError.Message;
                    break;
            }
            var error = new ErrorModel
            {
                StatusCode = statusCode,
                Error = errorType,
                Message = message,
                Time = DateTime.Now
            };
            await context.Response.WriteAsJsonAsync(error);
        }
    }
}
