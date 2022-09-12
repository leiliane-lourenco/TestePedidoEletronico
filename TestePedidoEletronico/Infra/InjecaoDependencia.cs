using Microsoft.Extensions.DependencyInjection;
using System;
using TestePedidoEletronico.Interfaces;
using TestePedidoEletronico.Services;

namespace TestePedidoEletronico.Infra
{
    public static class InjecaoDependencia
    {
        public static IServiceProvider Registrar()
        {
            var services = new ServiceCollection();

            services.AddScoped<ITabelaFipeService, TabelaFipeService>();

            services.AddScoped<IMainService, MainService>();

            return services.BuildServiceProvider();
        }
    }
}
