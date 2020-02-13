using ConsultaSaldo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsultaSaldo.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }


        public async Task<ActionResult> Consultacliente(string document)
        {
            try
            {
                if (String.IsNullOrEmpty(document) || (document.Length != 11))
                    throw new ArgumentNullException(document, "Por favor Informe um Documento Válido");
                else
                {
                    string date = DateTime.Now.ToString("MMddyyyyHHmmss");
                    string nsucliente = document + date;

                    RequestConsultaSaldo Customer = new RequestConsultaSaldo();

                    Customer.chaveIntegracao = "4B335B6F-9C4D-47F7-B798-C46FFBC4881A";
                    Customer.codigoLoja = "1";
                    Customer.nsuCliente = nsucliente;
                    Customer.numeroCartao = document;
                    HttpClient client = new HttpClient();

                    var Url = "https://hfllinxintegracaogiftwebapi-hom.azurewebsites.net/LinxServiceApi/FidelidadeService/ConsultaFidelizacao";

                    HttpResponseMessage send = await client.PostAsJsonAsync(Url, Customer);

                    send.EnsureSuccessStatusCode();
                    string responseBody = await send.Content.ReadAsStringAsync();

                    ResponseConsultaSaldo response = JsonConvert.DeserializeObject<ResponseConsultaSaldo>(responseBody);

                    if (String.IsNullOrEmpty(response.saldoEmPontos))
                        throw new ArgumentNullException(response.saldoEmPontos, "o cliente está com a pontuação zerada");

                    ResponseViewModel ResponseViewModel = new ResponseViewModel();
                    ResponseViewModel.mensagemErro = response.mensagemErro;
                    ResponseViewModel.nsuCliente = response.nsuCliente;
                    ResponseViewModel.saldoEmPontos = response.saldoEmPontos;
                    ResponseViewModel.saldoPontos = response.saldoPontos;
                    ResponseViewModel.saldoEmReais = response.saldoEmReais;

                    return Json(ResponseViewModel, JsonRequestBehavior.AllowGet);
                }
            
            }
            catch (Exception ex)
            {
                return Json(0, JsonRequestBehavior.AllowGet);

                throw;
            }

            return Json(0, JsonRequestBehavior.AllowGet);
}
    }
}
