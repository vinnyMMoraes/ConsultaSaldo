﻿namespace ConsultaSaldo.Models
{
    public class ResponseViewModel : ViewModelBase
    {
        public string NsuCliente { get; set; }
        public string Resultado { get; set; }
        public string SaldoPontos { get; set; }
        public string SaldoEmPontos { get; set; }
        public string SaldoEmReais { get; set; }
    }
}