using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YouTube.AspNetCore.API.Tutorial.Basic.Context;
using YouTube.AspNetCore.API.Tutorial.Basic.GenericRepositories;
using YouTube.AspNetCore.API.Tutorial.Basic.MapperApp.ClientMapper;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Services.ClientServices;
using YouTube.AspNetCore.API.Tutorial.Basic.Services.InvoiceServices;
//using YouTube.AspNetCore.API.Tutorial.Basic.Validators;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection LoadServiceExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("SqlConnection")));

            //services.AddTransient<IValidator<ClientCreateDto>, ClientCreateValidator>();

            // Fix: Use a lambda to configure AutoMapper
            services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
