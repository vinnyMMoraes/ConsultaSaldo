using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaSaldo.Models
{
    public class RequestConsultaSaldo
    {
        public string chaveIntegracao { get; set; }
        public string codigoLoja { get; set; }
        public string numeroCartao { get; set; }
        public string nsuCliente { get; set; }
        public string codigoSeguranca { get; set; }
    }
}