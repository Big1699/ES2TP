using System;
using System.Collections.Generic;

namespace ES2TP.Entities
{
    public partial class Depositosprazo
    {
        public int Iddepositos { get; set; }
        public int? Valor { get; set; }
        public string? Banco { get; set; }
        public int? Numeroconta { get; set; }
        public string? Titulares { get; set; }
        public double? Taxajurosanual { get; set; }
        public int? IdAtivoFinanceiro { get; set; }

        public virtual Ativofinanceiro? IdAtivoFinanceiroNavigation { get; set; }
    }
}
