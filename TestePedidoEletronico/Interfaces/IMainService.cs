﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestePedidoEletronico.ViewModel;

namespace TestePedidoEletronico.Interfaces
{
    public interface IMainService
    {
        Task<IEnumerable<MarcaViewModel>> ObterMarcas(string tipoVeiculo);
        Task<IEnumerable<ModeloViewModel>> ObterModelos(string tipoVeiculo, int codigoMarca);
        Task<IEnumerable<AnoViewModel>> ObterModelosPorAno(string tipoVeiculo, int codigoMarca, int codigoModelo);
        Task<TabelaFipeViewModel> ObterPreco(string tipoVeiculo, int codigoMarca, int codigoModelo);



    }
}