using System;
using System.Collections.Generic;
using ES2TP.Models;

namespace ES2TP.Entities
{
    public partial class Imovelarrendado
    {
        public int Idimovel { get; set; }
        public string? Designacao { get; set; }
        public string? Localizacao { get; set; }
        public double? Valorimovel { get; set; }
        public double? Valormensalcondominio { get; set; }
        public double? Valorrenda { get; set; }
        public double? Valoranual { get; set; }
        public int? IdAtivoFinanceiro { get; set; }

        public virtual Ativofinanceiro? IdAtivoFinanceiroNavigation { get; set; }

        
    }
}
