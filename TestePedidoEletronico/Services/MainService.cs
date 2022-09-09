using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePedidoEletronico.Infra;
using TestePedidoEletronico.ViewModel;

namespace TestePedidoEletronico.Services
{
    public class StartService 
    {
        private static IServiceProvider _provider = InjecaoDependencia.Registrar();
        private readonly ITabelaFipeService _tabelaFipeService;

        public async Task<IEnumerable<MarcaViewModel>> ObterMarcas(string tipoVeiculo)
        {
            var _tabelaFipeService = _provider.GetRequiredService<ITabelaFipeService>();

            var marcasTipoVeiculo = await _tabelaFipeService.ObterMarcas(tipoVeiculo);

            marcasTipoVeiculo.ToList().ForEach(marca =>
            {
                Console.WriteLine($"Codigo: {marca.Codigo}\nNome: {marca.Nome}");
                Console.WriteLine();
            });

            return marcasTipoVeiculo;
        }

        public async Task<IEnumerable<ModeloViewModel>> ObterModelos(string tipoVeiculo, int codigoMarca)
        {
            var _tabelaFipeService = _provider.GetRequiredService<ITabelaFipeService>();

            var modelosView = await _tabelaFipeService.ObterModelos(tipoVeiculo, codigoMarca);

            modelosView.ToList().ForEach(modelo =>
            {
                Console.WriteLine($"Codigo: {modelo.Codigo}\nNome: {modelo.Nome}");
                Console.WriteLine();
            });
            return modelosView;
        }

        public async Task<IEnumerable<AnoViewModel>> ObterModelosPorAno(string tipoVeiculo, int codigoMarca, int codigoModelo)
        {
            var _tabelaFipeService = _provider.GetRequiredService<ITabelaFipeService>();

            var anoECombustivelModeloView = await _tabelaFipeService.ObterModelosPorAno(tipoVeiculo, codigoMarca, codigoModelo);

            anoECombustivelModeloView.ToList().ForEach(ano =>
            {
                Console.WriteLine($"Codigo: {ano.Codigo}\nNome: {ano.Nome}");
                Console.WriteLine();
            });
            return anoECombustivelModeloView;
        }
        public async Task<TabelaFipeViewModel> ObterPreco(string tipoVeiculo, int codigoMarca, int codigoModelo)
        {
            Console.WriteLine(" Digite o codigo do Ano?");
            Console.WriteLine();

            var codigoAno = Console.ReadLine();
             var _tabelaFipeService = _provider.GetRequiredService<ITabelaFipeService>();

            var dadosVeiculo = await _tabelaFipeService.ObterPreco(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);

            Console.WriteLine();
            Console.WriteLine($" Valor: {dadosVeiculo.Valor}");
            Console.WriteLine($" Marca: {dadosVeiculo.Marca}");
            Console.WriteLine($" Modelo: {dadosVeiculo.Modelo}");
            Console.WriteLine($" AnoModelo: {dadosVeiculo.AnoModelo}");
            Console.WriteLine($" Combustivel: {dadosVeiculo.Combustivel}");
            Console.WriteLine($" CodigoFipe: {dadosVeiculo.CodigoFipe}");
            Console.WriteLine($" MesReferencia: {dadosVeiculo.MesReferencia}");
            Console.WriteLine($" TipoVeiculo: {dadosVeiculo.TipoVeiculo}");
            Console.WriteLine($" SiglaCombustivel: {dadosVeiculo.SiglaCombustivel}");

            return dadosVeiculo;
        }
    }
}
