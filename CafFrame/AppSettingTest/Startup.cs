using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.Injector;
using Caf.Core.DependencyInjection;
using Capgemini.Caf;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using AspectCore.Injector;

namespace AppSettingTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IServiceCollection Services { get; set; }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureModule<sampleModule>(Configuration);
            Services = services;
        }

        public void ConfigureContainer(IServiceContainer builder)
        {
            builder.BuildServiceProviderFromFactory(Services);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplicationRun();
        }
    }
}
