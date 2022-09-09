using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestePedidoEletronico.ViewModel
{
    public class ModeloViewModel
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
    public class DadosModelo
    {
        [JsonProperty("modelos")]
        public IEnumerable<ModeloViewModel> ModeloViewModels {get; set;}
    }
}
