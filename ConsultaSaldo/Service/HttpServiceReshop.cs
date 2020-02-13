using ConsultaSaldo.Models.Reshop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ConsultaSaldo.Service
{
    public class HttpServiceReshop
    {
        private readonly HttpClient client;

        public HttpServiceReshop()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://hfllinxintegracaogiftwebapi-hom.azurewebsites.net/")
            };
        }

        public async Task<ConsultaSaldoResponse> ConsultaFidelizacao(ConsultaSaldoRequest request)
        {
            HttpResponseMessage send = await client.PostAsJsonAsync("LinxServiceApi/FidelidadeService/ConsultaFidelizacao", request);
            send.EnsureSuccessStatusCode();
            string responseBody = await send.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ConsultaSaldoResponse>(responseBody);
        }
    }
}