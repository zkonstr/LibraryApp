﻿using Contracts;
using Repository;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Contracts;

namespace DebtNote.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()//WithOrigins("https://example.com")
            .AllowAnyMethod()       //WithMethods("POST", "GET") 
            .AllowAnyHeader());     //WithHeaders("accept", "contenttype")
            });
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => {});
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
                services.AddDbContext<RepositoryContext>(opts =>
                    opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

    }
}
