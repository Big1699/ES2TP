using System.Collections;

namespace ES2TP.Models
{
    public class ImovelModel : IEnumerable
    {
        public string Designacao  { get; set; }
   
        public string Localizacao { get; set; }
    
        public double ValorImovel { get; set; }

        public double ValorMensalCond { get; set; }
        
        public double ValorRenda { get; set; }
        
        public double ValorAnual { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    
}

