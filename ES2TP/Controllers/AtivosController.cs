using Microsoft.AspNetCore.Mvc;

using ES2TP.Entities;
using Microsoft.AspNetCore.Mvc;
using ES2TP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ES2TP.Context;


namespace ES2TP.Controllers
{
    public class AtivosController : Controller
    {
        private readonly MyDbContext _context;
        
        public AtivosController()
        {
            _context = new MyDbContext();
        }
        public IActionResult AtivosMenu()
        {
            return View();
        }
        
        
        //MENU
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Criar()
        {
            return RedirectToAction(controllerName: "Ativos", actionName: "CriarAtivo");
        }

        public IActionResult Editar()
        {
            throw new NotImplementedException();
        }

        public IActionResult Apagar()
        {
            throw new NotImplementedException();
        }
        
        //Criar Ativo
        
        
        public IActionResult CriarAtivo()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarAtivo(Ativofinanceiro ativofinanceiro)
        {
            var date01 = new DateTime();
            date01 = ativofinanceiro.Dataini;
            date01.ToString("yy-MM-dd");
            
            if (ativofinanceiro.Dataini != null && ativofinanceiro.Duracao != null && ativofinanceiro.Percentagemimposto != null)
            {
                _context.Add(ativofinanceiro);
                _context.SaveChanges();
                return RedirectToAction(controllerName: "Ativos", actionName: "AtivosMenu");
            }

            ViewData["HasError"] = true;
            
            return View("CriarAtivo");
        }
    }
}

