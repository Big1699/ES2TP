using Microsoft.AspNetCore.Mvc.Rendering;

namespace ES2TP.Models;

public class AtivoFinanceiroModel
{

    public int ativoOpcao { get; set; }
    public DateTime Dataini { get; set; }
   
    public int Duracao { get; set; }
    
    public double Percentagemimposto { get; set; }
    
}