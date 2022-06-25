using System;
using ES2TP.Entities;


namespace ES2TP.Models
{

    public class FundosMostarModel
    {
        

        public FundosMostarModel(Fundosinvestimento fundosinvestimento)
        {
            this.Nome = fundosinvestimento.Nome;
            this.MontanteInvestido = fundosinvestimento.Montanteinvestido;
            this.TaxaJuro = fundosinvestimento.Taxajuro;
            this.idAtivoFinanceiro = fundosinvestimento.IdAtivoFinanceiro;
            this.idFundos = fundosinvestimento.Idfundos;
        }
        public int? idFundos { get; set; }
        public int? idAtivoFinanceiro { get; set; }

        public double? TaxaJuro { get; set; }

        public double? MontanteInvestido { get; set; }

        public string? Nome { get; set; }
    }

}