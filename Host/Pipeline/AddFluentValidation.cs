using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace Host.Pipelines
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services,IEnumerable<Assembly> assemblies, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            services.Add(new ServiceDescriptor(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>), lifetime));

            services.AddValidatorsFromAssemblies(assemblies, lifetime);

            return services;
        }
    }
}
