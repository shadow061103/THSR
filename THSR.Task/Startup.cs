using System;
using System.IO;
using System.Linq;
using AutoMapper;
using CoreProfiler.Web;
using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using THSR.Repository.Models.Context;
using THSR.Task.Infrastructure.DI;
using THSR.Task.Infrastructure.Extension;
using THSR.Task.Infrastructure.Hangfire;
using THSR.Task.Interfaces;

namespace THSR.Task
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private HangfireSettings HangfireSettings { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region hangfire

            var hangfireSettings = new HangfireSettings();
            this.Configuration
                .GetSection("HangfireSettings")
                .Bind(hangfireSettings);
            this.HangfireSettings = hangfireSettings;

            var hangfireConnection = this.Configuration.GetConnectionString("Hangfire");
            services.AddHangfire(x =>
            {
                x.UseSqlServerStorage
                    (
                        nameOrConnectionString: hangfireConnection,
                        options: new SqlServerStorageOptions
                        {
                            SchemaName = hangfireSettings.SchemaName,
                            PrepareSchemaIfNecessary = hangfireSettings.PrepareSchemaIfNecessary,
                            JobExpirationCheckInterval = TimeSpan.FromSeconds(60)
                        }
                    )
                    .UseConsole()
                    .UseDashboardMetric(SqlServerStorage.ActiveConnections)
                    .UseDashboardMetric(SqlServerStorage.TotalConnections)
                    .UseDashboardMetric(DashboardMetrics.EnqueuedAndQueueCount)
                    .UseDashboardMetric(DashboardMetrics.ProcessingCount)
                    .UseDashboardMetric(DashboardMetrics.FailedCount)
                    .UseDashboardMetric(DashboardMetrics.SucceededCount);
            });

            #endregion hangfire

            #region swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "THSR Task",
                    Description = "This is THSR ASP.NET Core 3.1 RESTful API."
                });

                var basePath = AppContext.BaseDirectory;
                var xmlFiles = Directory.EnumerateFiles(basePath, $"*.xml", SearchOption.TopDirectoryOnly);

                foreach (var xmlFile in xmlFiles)
                {
                    c.IncludeXmlComments(xmlFile, true);
                }
            });

            #endregion swagger

            services.AddElasticsearch(Configuration);

            services.AddDependencyInjection(Configuration);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //EF
            services.AddDbContext<THSRContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("THSR")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, THSRContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCoreProfiler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET Core 3.1 THSR v1.0.0");
            });

            var queues = this.HangfireSettings.Queues.Any()
                ? this.HangfireSettings.Queues
                : new[] { "default" };

            app.UseHangfireServer
            (
                options: new BackgroundJobServerOptions
                {
                    ServerName = $"{Environment.MachineName}:{HangfireSettings.ServerName}",
                    WorkerCount = this.HangfireSettings.WorkerCount,
                    Queues = queues
                }
            );

            app.UseHangfireDashboard
            (
                pathMatch: "/hangfire",
                options: new DashboardOptions
                {
                    IgnoreAntiforgeryToken = true
                }
            );

            context.Database.EnsureCreated();

            //啟動定時工作
            var jobTrigger = serviceProvider.GetService<IJobTrigger>();
            jobTrigger.OnStart();
        }
    }
}