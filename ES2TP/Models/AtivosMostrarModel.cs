using ES2TP.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ES2TP.Models
{
    
    public class AtivosMostrarModel
    {

        public AtivosMostrarModel(Ativofinanceiro ativofinanceiro)
        {
            this.Dataini = ativofinanceiro.Dataini;
            this.Duracao = ativofinanceiro.Duracao;
            this.Percentagemimposto = ativofinanceiro.Percentagemimposto;
            this.ativoOpcao = ativofinanceiro.ativoOpcao;
        }
    
        public int? ativoOpcao { get; set; }

        public double? Percentagemimposto { get; set; }

        public int? Duracao { get; set; }

        public DateTime Dataini { get; set; }
    }
    
}

