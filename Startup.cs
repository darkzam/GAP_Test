using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAP.Insurance.Context;
using GAP.Insurance.Entities;
using GAP.Insurance.Models;
using GAP.Insurance.Services;
using GAP.Insurance.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GAP.Insurance
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InsuranceContext>(options => options.UseSqlServer(_configuration.GetConnectionString("Gap.Insurance")));

            services.AddMvc().AddJsonOptions(jsonOptions =>
                jsonOptions.SerializerSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Error
            )
            .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services.AddScoped<IPolicyService, PolicyService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");

                    });
                });
            }

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Policy, PolicyDto>()
                .ForMember(dest => dest.DateStart, opt => opt.MapFrom(src =>
                 $"{src.Date.ToString("dd-MM-yyyy")}"
                 ));

                cfg.CreateMap<PolicyCreateDto, Policy>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src =>
                 Convert.ToDateTime(src.Date)
                 ));


            });

            app.UseMvc();
        }
    }
}
