using ConsultaSaldo.Models.Reshop;
using System.Threading.Tasks;
using ConsultaSaldo.Models;
using System.Web.Mvc;
using System;
using ConsultaSaldo.Service;

namespace ConsultaSaldo.Controllers
{
    public class HomeController : Controller
    {
        private HttpServiceReshop ServiceReshop;
        public HomeController()
        {
            //Implementar IOC
            ServiceReshop = new HttpServiceReshop();
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Consultacliente(string document)
        {
            var result = new ResponseViewModel();

            ConsultaSaldoRequest Customer = new ConsultaSaldoRequest(document);

            if (!Customer.IsValid)
            {
                result.AddFalha(Customer.MensagemErro);
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var resultConsulta = await ServiceReshop.ConsultaFidelizacao(Customer);

                //Implementar o Automapper
                if (string.IsNullOrEmpty(resultConsulta.MensagemErro))
                {
                    result = new ResponseViewModel
                    {
                        NsuCliente = resultConsulta.NsuCliente,
                        SaldoEmPontos = resultConsulta.SaldoEmPontos,
                        SaldoPontos = resultConsulta.SaldoPontos,
                        SaldoEmReais = resultConsulta.SaldoEmReais
                    };
                }
                else
                {
                    result.AddFalha(resultConsulta.MensagemErro);
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
