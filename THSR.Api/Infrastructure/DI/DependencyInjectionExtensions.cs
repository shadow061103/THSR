﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using THSR.Repository.Implements;
using THSR.Repository.Infrastructure.Helpers;
using THSR.Repository.Interfaces;
using THSR.Service.Implements;
using THSR.Service.Interface;

namespace THSR.Api.Infrastructure.DI
{
    /// <summary>
    /// DI
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddApplicationDependencyInjection();
            services.AddServiceDependencyInjection();
            services.AddRepositoryDependencyInjection();
            return services;
        }

        private static void AddApplicationDependencyInjection(this IServiceCollection services)
        {
        }

        private static void AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IStationService, StationService>();
            services.AddTransient<IFareService, FareService>();
            services.AddTransient<ITimetableService, TimetableService>();
        }

        private static void AddRepositoryDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IRestClient, RestClient>();
            services.AddSingleton<IApiHelper, ApiHelper>();
            services.AddTransient<IWsTHSRRepository, WsTHSRRepository>();
            services.AddScoped<IProxyRepository, ProxyRepository>();
        }
    }
}