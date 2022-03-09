using AutoMapper;
using CR.Report.Application.Mappers;
using CR.Report.Application.PipelineBehaviors;
using CR.Report.Application.Services;
using CR.Report.Application.Services.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CR.Report.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));


            //services.AddScoped<IContactContext, ContactContext>();
            services.AddScoped<IReportService, ReportService>();

            #region Configure Mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod is not null && (p.GetMethod.IsPublic || p.GetMethod.IsAssembly);
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            #endregion

            return services;
        }
    }
}