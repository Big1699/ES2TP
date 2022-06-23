using System;
using ES2TP.Entities;


namespace ES2TP.Models
{
    public class DepositosMostarModel
    {

        public DepositosMostarModel(Depositosprazo depositosprazo)
        {
            this.Banco = depositosprazo.Banco;
            this.NumeroConta = depositosprazo.Numeroconta;
            this.TaxaJurosAnual = depositosprazo.Taxajurosanual;
            this.Valor = depositosprazo.Valor;
            this.Titulares = depositosprazo.Titulares;
            this.idAtivoFinanceiro = depositosprazo.IdAtivoFinanceiro;
        }

        public string? Titulares { get; set; }

        public int? Valor { get; set; }

        public double? TaxaJurosAnual { get; set; }

        public int? NumeroConta { get; set; }

        public string? Banco { get; set; }
        
        public int? idAtivoFinanceiro { get; set; }
    }
}

