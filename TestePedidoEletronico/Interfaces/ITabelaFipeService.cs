using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestePedidoEletronico.ViewModel;

namespace TestePedidoEletronico.Infra
{
    public interface ITabelaFipeService
    {
        Task<IEnumerable<MarcaViewModel>> ObterMarcas(string marca);
        Task<IEnumerable<ModeloViewModel>> ObterModelos(string marca, int codigoMarca);
        Task<IEnumerable<AnoViewModel>> ObterModelosPorAno(string marca, int codigoMarca, int codigoModelo);
        Task<TabelaFipeViewModel> ObterPreco(string marca, int codigoMarca, int codigoModelo, string codigoAno);

    }
}
