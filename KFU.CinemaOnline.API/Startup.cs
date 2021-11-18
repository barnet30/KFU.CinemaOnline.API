using System;
using System.IO;
using System.Reflection;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

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
            services.AddControllers();
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


        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterModule<DataAccessDependencyModule>();

            builder.RegisterModule<MapperDependencyModule>();

            //builder.RegisterModule<CoreDependencyModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
