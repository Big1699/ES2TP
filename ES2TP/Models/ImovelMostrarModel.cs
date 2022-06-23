using System;
using ES2TP.Entities;


namespace ES2TP.Models
{
    
    public class ImovelMostrarModel
    {
        

        public ImovelMostrarModel(Imovelarrendado imovelarrendado)
        {
            this.Designacao = imovelarrendado.Designacao;
            this.Localizacao = imovelarrendado.Localizacao;
            this.ValorImovel = imovelarrendado.Valorimovel;
            this.ValorMensalCond = imovelarrendado.Valormensalcondominio;
            this.ValorRenda = imovelarrendado.Valorrenda;
            this.ValorAnual = imovelarrendado.Valoranual;
            this.idAtivoFinanceiro = imovelarrendado.IdAtivoFinanceiro;
      
        }
        public int? idAtivoFinanceiro { get; set; }

        public double? ValorAnual { get; set; }

        public double? ValorRenda { get; set; }

        public double? ValorMensalCond { get; set; }

        public double? ValorImovel { get; set; }

        public string? Localizacao { get; set; }

        public string? Designacao { get; set; }
    }
    
}

