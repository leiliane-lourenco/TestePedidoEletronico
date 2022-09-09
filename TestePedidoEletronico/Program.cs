using System;
using System.Threading.Tasks;
using TestePedidoEletronico.Infra;
using TestePedidoEletronico.Services;
using TestePedidoEletronico.ViewModel.Enum;

namespace TestePedidoEletronico
{
    class Program
    {

        public static async Task Main(string[] args)
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

            MainService serviceMarca = new MainService();
           await  serviceMarca.ObterMarcas(tipoVeiculo);

            //=================== SELECIONA MARCA DO VEICULO PARA  RETORNA MODELOS =============================

            Console.WriteLine(" Digite o codigo da Marca");
            Console.WriteLine();

            var codigoMarca = Convert.ToInt32(Console.ReadLine());

            MainService serviceModelo = new MainService();
            await serviceModelo.ObterModelos(tipoVeiculo, codigoMarca);

            // =================== SELECIONA MODELO DA MARCA ESCOLHIDA PARA RETORNA ANOS DOS MODELOS ===============

            Console.WriteLine(" Digite o codigo do modelo");
            Console.WriteLine();

            var codigoModelo = Convert.ToInt32(Console.ReadLine());

            MainService serviceAno = new MainService();
            await serviceAno.ObterModelosPorAno(tipoVeiculo, codigoMarca, codigoModelo);

            // ======================== SELECIONA ANO MODELO PARA RETORNA PREÇO =============
            MainService servicePreco = new MainService();
            await servicePreco.ObterPreco(tipoVeiculo, codigoMarca, codigoModelo);

        }
        
    }
}
