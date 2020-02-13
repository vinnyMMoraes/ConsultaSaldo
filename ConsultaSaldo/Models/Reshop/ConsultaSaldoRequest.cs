using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaSaldo.Models.Reshop
{
    public class ConsultaSaldoRequest : ViewModelBase
    {
        public ConsultaSaldoRequest(string numeroCartao)
        {
            if (String.IsNullOrEmpty(numeroCartao) || (numeroCartao.Length != 11))
                AddFalha("Documento deve ser informado com no máximo 11 caracteres!");

            NumeroCartao = numeroCartao;
        }

        public string NumeroCartao { get; private set; }
        public string ChaveIntegracao { get { return "4B335B6F-9C4D-47F7-B798-C46FFBC4881A"; } }
        public string CodigoLoja { get { return "1"; } }
        public string NsuCliente { get { return $"{NumeroCartao}{DateTime.Now.ToString("MMddyyyyHHmmss")}"; } }
        public string CodigoSeguranca
        {
            get { return ""; }
        }
    }
}