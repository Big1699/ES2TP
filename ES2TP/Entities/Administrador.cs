using System;
using System.Collections.Generic;

namespace ES2TP.Entities
{
    public partial class Administrador
    {
        public int Idadmin { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
