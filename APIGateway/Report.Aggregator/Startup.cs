using EventBus;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Report.Aggregator.ConsumerServices;
using Report.Aggregator.ConsumerServices.Interfaces;
using Report.Aggregator.Services;
using Report.Aggregator.Services.Interfaces;
using System;

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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMassTransit(config =>
            {
                config.AddConsumer<ConsumerService>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);

                    cfg.ReceiveEndpoint(EventBusConstants.ReportQueue, c =>
                    {
                        c.ConfigureConsumer<ConsumerService>(ctx);
                    });
                });
            });

            services.AddMassTransitHostedService();

            services.AddScoped<ConsumerService>();

            services.AddHostedService<QueuedHostedService>();

            services.AddSingleton<IBackgroundTaskQueue>(ctx =>
            {
                if (!int.TryParse("2", out var queueCapacity))
                    queueCapacity = 100;
                return new DefaultBackgroundTaskQueue(queueCapacity);
            });

            services.AddHealthChecksUI().AddInMemoryStorage();
            services.AddHttpClient<IContactService, ContactService>(c =>
              c.BaseAddress = new Uri(Configuration["ApiSettings:ContactUrl"]));
            //.AddHttpMessageHandler<LoggingDelegatingHandler>();
            //.AddPolicyHandler(GetRetryPolicy())
            //.AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddHttpClient<IReportService, ReportService>(c =>
               c.BaseAddress = new Uri(Configuration["ApiSettings:ReportUrl"]));
            //.AddHttpMessageHandler<LoggingDelegatingHandler>();
            //.AddPolicyHandler(GetRetryPolicy())
            //.AddPolicyHandler(GetCircuitBreakerPolicy());


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


            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecksUI();
                endpoints.MapControllers();
            });
        }
    }
}
