using Business.Case.Raizen.Api.Domain.Interfaces;
using Business.Case.Raizen.Api.Infra.Context;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Business.Case.Raizen.Api.Domain.Static;

namespace Business.Case.Raizen.Api.Infra.DependencyInjection
{
    public static class DependencyInjectionExtension
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var implementationsType = typeof(DependencyInjectionExtension).Assembly.GetTypes()
              .Where(t => typeof(IService).IsAssignableFrom(t) &&
                     t.BaseType != null);

            foreach (var item in implementationsType)
                services.AddScoped(item);

            return services;
        }
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {

            services.AddScoped(sp =>
            {
                return new dbBusinessCaseContext(new SqlConnection(RuntimeConfig.ConnectStringSqlServer));
            });

            return services;
        }
        private static string ToBase64(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
    }
}
