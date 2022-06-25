using ES2TP.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ES2TP.Models
{
    
    public class AdminMostrarModel
    {
        


        public AdminMostrarModel(Administrador administrador)
        {
            this.idAdmin = administrador.Idadmin;
            this.Email = administrador.Email;
            this.Username = administrador.Username;
            this.Password = administrador.Password;
        }

        public string? Password { get; set; }

        public string Username { get; set; }

        public string? Email { get; set; }


        public int? idAdmin { get; set; }
    
        
    }
    
}