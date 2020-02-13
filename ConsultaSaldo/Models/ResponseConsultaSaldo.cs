using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaSaldo.Models
{
    public class ResponseConsultaSaldo
    {
        public string nsuCliente { get; set; }
        public string resultado { get; set; }
        public string saldoPontos { get; set; }
        public string saldoEmPontos { get; set; }
        public string saldoEmReais { get; set; }
        public string  mensagemErro { get; set; }
    }
}

