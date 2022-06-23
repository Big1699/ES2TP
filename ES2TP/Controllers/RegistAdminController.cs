using ES2TP.Entities;
using Microsoft.AspNetCore.Mvc;
using ES2TP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ES2TP.Context;


namespace ES2TP.Controllers
{
    public class RegistAdminController : Controller
    {

        private readonly MyDbContext _context;

        public RegistAdminController()
        {
            _context = new MyDbContext();
        }

        public IActionResult RegistAdmin()
        {
            return View();
        }


        // POST: Meal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdmin(Administrador administrador)
        {
            if (administrador.Email != null && administrador.Username != null && administrador.Password != null)
            {
                _context.Add(administrador);
                _context.SaveChanges();
                return RedirectToAction(controllerName: "Auth", actionName: "Login");
            }

            ViewData["HasError"] = true;
            
            return View("RegistAdmin");
        }

        
    }

}
