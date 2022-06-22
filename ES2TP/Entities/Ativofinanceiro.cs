using System;
using System.Collections.Generic;

namespace ES2TP.Entities
{
    public partial class Ativofinanceiro
    {
        public Ativofinanceiro()
        {
            Depositosprazos = new HashSet<Depositosprazo>();
            Fundosinvestimentos = new HashSet<Fundosinvestimento>();
            Imovelarrendados = new HashSet<Imovelarrendado>();
        }

        public int Idativofinanceiro { get; set; }
        public DateTime Dataini { get; set; }
        public int? Duracao { get; set; }
        public double? Percentagemimposto { get; set; }
        public int? IdUser { get; set; }

        public virtual Utilizador? IdUserNavigation { get; set; }
        public virtual ICollection<Depositosprazo> Depositosprazos { get; set; }
        public virtual ICollection<Fundosinvestimento> Fundosinvestimentos { get; set; }
        public virtual ICollection<Imovelarrendado> Imovelarrendados { get; set; }
    }
}
