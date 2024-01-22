﻿using Business.Case.Raizen.Api.Infra.Base;
using System.Data;

namespace Business.Case.Raizen.Api.Infra.Repositories.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            var implementationsType = typeof(DependencyInjectionExtensions).Assembly.GetTypes()
               .Where(t => typeof(IRepository).IsAssignableFrom(t) &&
                      t.BaseType != null
                     );

            foreach (var item in implementationsType)
                services.AddScoped(item);

            return services;
        }
    }
}
