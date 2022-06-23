using Microsoft.AspNetCore.Mvc.Rendering;

namespace ES2TP.Models
{
    public class DepositoModel
    {
        public int Valor  { get; set; }
   
        public string Banco { get; set; }
    
        public int Numeroconta { get; set; }
        
        public string Titulares { get; set; }
    
        public double Taxajurosanual { get; set; }
        
        

    
    }
}




