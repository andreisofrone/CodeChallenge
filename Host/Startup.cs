using Application;
using Application.Common;
using Application.Common.Repositories;
using Application.Common.Repositories.Contracts;
using AutoMapper;
using FluentValidation.AspNetCore;
using Host.Middlewares;
using Host.Pipelines;
using Infrastructure.DBExercise.Storage;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected Assembly[] Assemblies
        => new[] {
            typeof(IApplication).Assembly
        };

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAppliedAmountRepository, AppliedAmountRepository>();
            services.AddScoped<ITotalFutureDebtRepository, TotalFutureDebtRepository>();
            services.AddOptions();
            services.AddMediatR(Assemblies);

            //var domainAssembly = typeof(IApplication).GetTypeInfo().Assembly;
            services.AddFluentValidation(Assemblies);

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddJsonOptions(opt => opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetSection("AppSettings").GetSection("ConnectionString").Value);

            });          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<GeneralExceptionHandlerMiddleware>();
            app.UseMiddleware<FluentValidationExceptionHandlerMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
            }

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseMvc();
        }
    }
}
