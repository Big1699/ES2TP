using System;
using System.Collections.Generic;

namespace ES2TP.Entities
{
    public partial class Utilizador
    {
        public Utilizador()
        {
            Ativofinanceiros = new HashSet<Ativofinanceiro>();
        }

        public int Iduser { get; set; }
        public string? Email { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Ativofinanceiro> Ativofinanceiros { get; set; }
    }
}
