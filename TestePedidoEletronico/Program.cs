using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestePedidoEletronico.Infra;
using TestePedidoEletronico.ViewModel.Enum;

namespace TestePedidoEletronico
{
    class Program
    {
        private static IServiceProvider _provider = InjecaoDependencia.Registrar();
        private readonly ITabelaFipeService _tabelaFipeService;

        public Program(ITabelaFipeService tabelaFipeService)
        {
            _tabelaFipeService = tabelaFipeService;
        }

        static async Task Main(string[] args)
        {           

            //==================== SELECIONAR TIPO VEICULO PARA RETORNAR MARCAS ==================================
            Console.WriteLine("<<<< PESQUISA PREÇOS TABELA FIPE >>>>");
            Console.WriteLine();
            Console.WriteLine(" O que você deseja pesquisar?");
            Console.WriteLine();
            Console.WriteLine(" Digite:\n 1- Carros\n 2- Motos\n 3- Caminhões");
            Console.WriteLine();

            var codigoTipoVeiculo = Convert.ToInt32(Console.ReadLine());

            var tipoVeiculo = ((TipoVeiculoEnum)codigoTipoVeiculo).ToString();

            var _tabelaFipeService = _provider.GetRequiredService<ITabelaFipeService>();

            var marcasTipoVeiculo = await _tabelaFipeService.ObterMarcas(tipoVeiculo);

            marcasTipoVeiculo.ToList().ForEach(marca =>
            {
                Console.WriteLine($"Codigo: {marca.Codigo}\nNome: {marca.Nome}");
                Console.WriteLine();
            });

            ////=================== SELECIONA MARCA DO VEICULO PARA  RETORNA MODELOS =============================
            
            Console.WriteLine(" Digite o codigo da Marca?");
            Console.WriteLine();

            var codigoMarca = Convert.ToInt32(Console.ReadLine());

            var modelosView = await _tabelaFipeService.ObterModelos(tipoVeiculo, codigoMarca);

            modelosView.ToList().ForEach(modelo =>
            {
                Console.WriteLine($"Codigo: {modelo.Codigo}\nNome: {modelo.Nome}");
                Console.WriteLine();
            });


            //// =================== SELECIONA MODELO DA MARCA ESCOLHIDA PARA RETORNA ANOS DOS MODELOS ===============

            Console.WriteLine(" Digite o codigo do modelo?");
            Console.WriteLine();

            var codigoModelo = Convert.ToInt32(Console.ReadLine());

            var anoECombustivelModeloView = await _tabelaFipeService.ObterModelosPorAno(tipoVeiculo, codigoMarca, codigoModelo);

            anoECombustivelModeloView.ToList().ForEach(ano =>
            {
                Console.WriteLine($"Codigo: {ano.Codigo}\nNome: {ano.Nome}");
                Console.WriteLine();
            });

            //// ======================== SELECIONA ANO MODELO PARA RETORNA PREÇO =============
            Console.WriteLine(" Digite o codigo do Ano?");
            Console.WriteLine();

            var codigoAno = Console.ReadLine();

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

        }
    }
}
