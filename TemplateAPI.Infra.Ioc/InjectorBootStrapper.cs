using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Template.Application.DTOs;
using Template.Application.Interfaces;
using Template.Application.Mappings;
using Template.Application.Services;
using Template.Application.Validator;
using Template.Domain.Entities;
using Template.Domain.Interfaces;
using Template.Infra.Data;
using Template.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Infra.Ioc
{
    public static class InjectorBootStrapper
    {
        public static void Setup(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterAutoMapper(services);
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<AddressProfile>();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            //APP
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IUserService, UserService>();

            //DATA
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //VALIDATOR
            services.AddScoped<IValidator<AddressDto>, AddressValidator>();
            services.AddScoped<IValidator<UserDto>, UserValidator>();

        }
    }
}
