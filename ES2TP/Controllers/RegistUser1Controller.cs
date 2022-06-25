using ES2TP.Entities;
using Microsoft.AspNetCore.Mvc;
using ES2TP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ES2TP.Context;


namespace ES2TP.Controllers
{
    public class RegistUser1Controller : Controller
    {

        private readonly MyDbContext _context;

        public RegistUser1Controller()
        {
            _context = new MyDbContext();
        }

        public IActionResult RegistUser()
        {
            return View();
        }


       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Utilizador utilizador)
        {
            if (utilizador.Email != null && utilizador.Username != null && utilizador.Password != null)
            {
                utilizador.tipoUser = 1;
                _context.Add(utilizador);
                _context.SaveChanges();
                return RedirectToAction(controllerName: "Auth", actionName: "Login");
            }

            ViewData["HasError"] = true;
            
            return View("RegistUser");
        }

        
    }

}