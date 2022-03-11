using CR.Core;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Polly;
using Polly.Extensions.Http;
using Report.Aggregator.ConsumerServices;
using Report.Aggregator.Services;
using Report.Aggregator.Services.Interfaces;
using System;
using System.Net.Http;

namespace Report.Aggregator
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                opt.SerializerSettings.Culture = System.Globalization.CultureInfo.GetCultureInfo("tr-TR");
            });


            services.AddHealthChecksUI().AddInMemoryStorage();

            services.AddTransient<LoggingDelegatingHandler>();

            services.AddHttpClient<IContactService, ContactService>(c =>
               c.BaseAddress = new Uri(Configuration["ApiSettings:ContactUrl"]))
              //.AddHttpMessageHandler<LoggingDelegatingHandler>()
              .AddPolicyHandler(GetRetryPolicy())
              .AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddHttpClient<IReportService, ReportService>(c =>
               c.BaseAddress = new Uri(Configuration["ApiSettings:ReportUrl"]))
              //.AddHttpMessageHandler<LoggingDelegatingHandler>()
              .AddPolicyHandler(GetRetryPolicy())
              .AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddTransient<Consume>();
            services.AddMediatR(typeof(Program));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Report.Aggregator", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Report.Aggregator v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecksUI();
                endpoints.MapControllers();
            });
        }


        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {

            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(
                    retryCount: 5,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    onRetry: (exception, retryCount, context) =>
                    {
                        // Log.Error($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}, due to: {exception}.");
                    });
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 5,
                    durationOfBreak: TimeSpan.FromSeconds(30)
                );
        }
    }
}