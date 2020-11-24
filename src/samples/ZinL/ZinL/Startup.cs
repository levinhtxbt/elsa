using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elsa.Activities.Email.Extensions;
using Elsa.Activities.Http.Extensions;
using Elsa.Activities.Timers.Extensions;
using Elsa.Dashboard.Extensions;
using Elsa.Persistence.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ZinL.Activities.Customer.Activities;
using ZinL.Domain;
using Microsoft.OpenApi.Models;
using ZinL.Services;

namespace ZinL
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddActivity<SayHelloWorld>();


            services
                // Required services for Elsa to work. Registers things like `IWorkflowInvoker`.
                .AddElsa(elsa => elsa
                    .AddEntityFrameworkStores<ElsaDBContext>(opt => opt
                        .UseSqlServer(_configuration.GetConnectionString("DefaultConnection")), true))
                .AddHttpActivities(options => options.Bind(_configuration.GetSection("Elsa:Http")))
                .AddEmailActivities(options => options.Bind(_configuration.GetSection("Elsa:Smtp")))
                .AddTimerActivities(options => options.Bind(_configuration.GetSection("Elsa:Timers")))
                .AddElsaDashboard();

            services.AddControllers();

            services.AddScoped<IWorkflowDefinitionService, WorkflowDefinitionService>();


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            app.UseHttpActivities();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
