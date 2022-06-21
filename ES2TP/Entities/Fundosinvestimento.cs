using System;
using System.Collections.Generic;

namespace ES2TP.Entities
{
    public partial class Fundosinvestimento
    {
        public int Idfundos { get; set; }
        public string? Nome { get; set; }
        public double? Montanteinvestido { get; set; }
        public double? Taxajuro { get; set; }
        public int? IdAtivoFinanceiro { get; set; }

        public virtual Ativofinanceiro? IdAtivoFinanceiroNavigation { get; set; }
    }
}
