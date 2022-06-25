using ES2TP.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ES2TP.Models
{
    
    public class UsersMostrarModel
    {
        


        public UsersMostrarModel(Utilizador utilizador)
        {
            this.idUSer = utilizador.Iduser;
            this.Email = utilizador.Email;
            this.Username = utilizador.Username;
            this.Password = utilizador.Password;
            this.tipoUser = utilizador.tipoUser;
        }

        public int? tipoUser { get; set; }
        public string? Password { get; set; }

        public string Username { get; set; }

        public string? Email { get; set; }


        public int? idUSer { get; set; }
    
        
    }
    
}