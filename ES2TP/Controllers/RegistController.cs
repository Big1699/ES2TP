using ES2TP.Entities;
using Microsoft.AspNetCore.Mvc;
using ES2TP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ES2TP.Context;


namespace ES2TP.Controllers
{
    public class RegistController : Controller
    {

        private readonly MyDbContext _context;

        public RegistController()
        {
            _context = new MyDbContext();
        }

        public IActionResult Regist()
        {
            return View();
        }


        // POST: Meal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Utilizador utilizador)
        {
            if (utilizador.Email != null && utilizador.Username != null && utilizador.Password != null)
            {
                _context.Add(utilizador);
                _context.SaveChanges();
                return RedirectToAction(controllerName: "Auth", actionName: "Login");
            }

            ViewData["HasError"] = true;
            
            return View("Regist");
        }
    }

}

