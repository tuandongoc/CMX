using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CMX.api.Repositories;
using CMX.api.Settings;
using CMX.Entities;
using CMX.Entities.Models.Core;
using CMX.Entities.Models.Works;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace CMX.api
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
            string securityKey = "dfe08d867458c032a10c22aff0714bbf";
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "CMX.app",
                        ValidAudience = "readers",
                        IssuerSigningKey = symmetricSecurityKey
                    };
                });


            services.AddSingleton(Configuration);
            services.AddDbContext<CWorksContext>(options => options.
             UseSqlServer(Configuration.GetConnectionString("works")),
               ServiceLifetime.Scoped);
            services.AddDbContext<CoreContext>(options => options.
             UseSqlServer(Configuration.GetConnectionString("core")),
               ServiceLifetime.Scoped);
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IOutstandingBalanceRepository, OutstandingBalanceRepository>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "CMX API", Version = "v1" });

                // Get xml comments path
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                // Set xml path
                options.IncludeXmlComments(xmlPath, false);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //Log Config
            AdvancedConfiguration.ConfigLog4net(Configuration, loggerFactory, "log4net.config", "Logging");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "CMX API V1");
            });

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
