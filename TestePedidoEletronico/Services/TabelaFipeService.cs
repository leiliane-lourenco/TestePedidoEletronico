using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using TestePedidoEletronico.Infra;
using TestePedidoEletronico.ViewModel;

namespace TestePedidoEletronico.Services
{
    public class TabelaFipeService : ITabelaFipeService
    {
        private HttpClient _httpClient;

        private readonly string _baseUrl;
        public TabelaFipeService()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _baseUrl = configuration.GetSection("BaseUrl").Value;            
        }

        private HttpClient ObterHttpClient()//metodo config acesso web
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_baseUrl)
            };
            return _httpClient;
        }
        public async Task<IEnumerable<MarcaViewModel>> ObterMarcas(string tipoVeiculo)
        {
            using (var httpClient = ObterHttpClient())
            {
                var serviceUrl = $"{tipoVeiculo}/marcas";
                var response = await httpClient.GetAsync($"{serviceUrl}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var marcasViewModel = JsonConvert.DeserializeObject<IEnumerable<MarcaViewModel>>(json);
                    return marcasViewModel;
                }
            }
            return new List<MarcaViewModel>();
        }
        public async Task<IEnumerable<ModeloViewModel>> ObterModelos(string tipoVeiculo, int codigoMarca)
        {
            using (var httpClient = ObterHttpClient())
            {
                var serviceUrl = $"{tipoVeiculo}/marcas/{codigoMarca}/modelos";
                var response = await httpClient.GetAsync($"{serviceUrl}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var dadosModeloView = JsonConvert.DeserializeObject<DadosModelo>(json);
                    return dadosModeloView.ModeloViewModels;
                }
            }

            return new List<ModeloViewModel>();
        }

        public async Task<IEnumerable<AnoViewModel>> ObterModelosPorAno(string tipoVeiculo, int codigoMarca, int codigoModelo)
        {
            using (var httpClient = ObterHttpClient())
            {
                var serviceUrl = $"{tipoVeiculo}/marcas/{codigoMarca}/modelos/{codigoModelo}/anos";
                var response = await httpClient.GetAsync($"{serviceUrl}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var anoView = JsonConvert.DeserializeObject<IEnumerable<AnoViewModel>>(json);
                    return anoView;
                }
            }

            return new List<AnoViewModel>();
        }

        public async Task<TabelaFipeViewModel> ObterPreco(string tipoVeiculo, int codigoMarca, int codigoModelo, string codigoAno)
        {
            using (var httpcliente = ObterHttpClient())
            {
                var serviceUrl = $"{tipoVeiculo}/marcas/{codigoMarca}/modelos/{codigoModelo}/anos/{codigoAno}";
                var response = await httpcliente.GetAsync($"{serviceUrl}");
                if (true)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var tabelafipeVielModel = JsonConvert.DeserializeObject<TabelaFipeViewModel>(json);
                    return tabelafipeVielModel;
                }               
            }

            return new TabelaFipeViewModel();
        }
    }
}
