using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Logger;
using Geek.DataContexts;
using Geek.Infrastructure.Repository;
using Geek.Infrastructure.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

namespace Geek
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GeekContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<DbContext, GeekContext>();
            services.AddScoped<ICalcResultRepository, CalcResultRepository>();
            services.AddScoped<ICalculateService, CalculateService>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            env.ConfigureNLog("nlog.config");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            GlobalDiagnosticsContext.Set("connectionString", Configuration.GetConnectionString("DefaultConnection"));

            app.UseMvc();
        }
    }
}
