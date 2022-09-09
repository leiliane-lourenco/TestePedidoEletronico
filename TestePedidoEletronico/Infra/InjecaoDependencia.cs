using Microsoft.Extensions.DependencyInjection;
using System;
using TestePedidoEletronico.Services;

namespace TestePedidoEletronico.Infra
{
    public static class InjecaoDependencia
    {
        public static IServiceProvider Registrar()
        {
            var services = new ServiceCollection();

            services.AddScoped<ITabelaFipeService, TabelaFipeService>();

            return services.BuildServiceProvider();
        }
    }
}
