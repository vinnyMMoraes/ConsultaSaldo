using System;

namespace ConsultaSaldo.Models
{
    public class ViewModelBase
    {
        public bool IsValid { get { return !IsError; } }

        public string MensagemErro { get; set; }
        private bool IsError { get; set; }

        public void AddError(Exception ex)
        {

            this.IsError = true;
            this.MensagemErro = ex.Message;
        }

        public void AddFalha(string msg)
        {

            this.IsError = true;
            this.MensagemErro = msg;
        }
    }
}