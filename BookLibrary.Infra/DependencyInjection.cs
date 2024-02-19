using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary2.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {

            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies(assembly));

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
