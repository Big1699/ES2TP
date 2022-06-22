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
        public async Task<IActionResult> CriarAtivo(Ativofinanceiro ativofinanceiro, AtivoFinanceiroModel ativoFinanceiroModel)
        {
            if (ativofinanceiro.Dataini != null && ativofinanceiro.Duracao != null && ativofinanceiro.Percentagemimposto != null)
            {
                ativofinanceiro.IdUser = UserSession.idutilizador;
                
                _context.Add(ativofinanceiro);
                
                _context.SaveChanges();
                UserSession.idAtivoFinanceiro = ativofinanceiro.Idativofinanceiro;

                if (ativoFinanceiroModel.ativoOpcao == 1)
                {
                    return RedirectToAction(controllerName: "Ativos", actionName: "CriarImovel");
                }
                
                if (ativoFinanceiroModel.ativoOpcao == 2)
                {
                    return RedirectToAction(controllerName: "Ativos", actionName: "CriarDeposito");
                }
                
                if (ativoFinanceiroModel.ativoOpcao == 3)
                {
                    return RedirectToAction(controllerName: "Ativos", actionName: "CriarFundos");
                }
                
                
                return RedirectToAction(controllerName: "Ativos", actionName: "AtivosMenu");
            }

            ViewData["HasError"] = true;
            
            return View("CriarAtivo");
        }

        //Criar Ativo do tipo Imovel
        public IActionResult CriarImovel()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarImovel(Imovelarrendado imovelarrendado)
        {
            if (imovelarrendado.Designacao != null && imovelarrendado.Localizacao != null && imovelarrendado.Valorimovel != null && imovelarrendado.Valormensalcondominio != null
                && imovelarrendado.Valorrenda != null && imovelarrendado.Valoranual != null)
            {
                imovelarrendado.IdAtivoFinanceiro = UserSession.idAtivoFinanceiro;
                _context.Add(imovelarrendado);
                _context.SaveChanges();
                
                return RedirectToAction(controllerName: "Ativos", actionName: "AtivosMenu");

            }

            ViewData["HasError"] = true;

            return View("CriarImovel");
        }

        
        //Criar Ativo do tipo Deposito
        public IActionResult CriarDeposito()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarDeposito(Depositosprazo depositosprazo, Ativofinanceiro ativofinanceiro)
        {
            if (depositosprazo.Valor != null && depositosprazo.Banco != null && depositosprazo.Numeroconta != null && depositosprazo.Titulares != null
                && depositosprazo.Taxajurosanual != null)
            {
                depositosprazo.IdAtivoFinanceiro = ativofinanceiro.Idativofinanceiro;
                _context.Add(depositosprazo);
                _context.SaveChanges();

            }

            ViewData["HasError"] = true;

            return View("CriarDeposito");
        }

        
        //Criar Ativo do tipo Fundos
        public IActionResult CriarFundos()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarFundos(Fundosinvestimento fundosinvestimento, Ativofinanceiro ativofinanceiro)
        {
            if (fundosinvestimento.Nome != null && fundosinvestimento.Montanteinvestido != null && fundosinvestimento.Taxajuro != null)
            {
                fundosinvestimento.IdAtivoFinanceiro = ativofinanceiro.Idativofinanceiro;
                _context.Add(fundosinvestimento);
                _context.SaveChanges();

            }

            ViewData["HasError"] = true;

            return View("CriarFundos");
        }
        
    }
}

