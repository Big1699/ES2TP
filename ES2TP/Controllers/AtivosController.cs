using Microsoft.AspNetCore.Mvc;

using ES2TP.Entities;
using Microsoft.AspNetCore.Mvc;
using ES2TP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ES2TP.Context;
using Microsoft.EntityFrameworkCore;


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
        

        //Criar Ativo
        public IActionResult CriarAtivo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarAtivo(Ativofinanceiro ativofinanceiro,
            AtivoFinanceiroModel ativoFinanceiroModel)
        {
            if (ativofinanceiro.Dataini != null && ativofinanceiro.Duracao != null &&
                ativofinanceiro.Percentagemimposto != null)
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
            if (imovelarrendado.Designacao != null && imovelarrendado.Localizacao != null &&
                imovelarrendado.Valorimovel != null && imovelarrendado.Valormensalcondominio != null
                && imovelarrendado.Valorrenda != null && imovelarrendado.Valoranual != null)
            {
                imovelarrendado.IdAtivoFinanceiro = UserSession.idAtivoFinanceiro;
                _context.Add(imovelarrendado);
                _context.SaveChanges();

                return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosImovel");

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
        public async Task<IActionResult> CriarDeposito(Depositosprazo depositosprazo)
        {
            if (depositosprazo.Valor != null && depositosprazo.Banco != null && depositosprazo.Numeroconta != null &&
                depositosprazo.Titulares != null
                && depositosprazo.Taxajurosanual != null)
            {
                depositosprazo.IdAtivoFinanceiro = UserSession.idAtivoFinanceiro;
                _context.Add(depositosprazo);
                _context.SaveChanges();

                return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosDeposito");

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
        public async Task<IActionResult> CriarFundos(Fundosinvestimento fundosinvestimento)
        {
            if (fundosinvestimento.Nome != null && fundosinvestimento.Montanteinvestido != null &&
                fundosinvestimento.Taxajuro != null)
            {
                fundosinvestimento.IdAtivoFinanceiro = UserSession.idAtivoFinanceiro;
                _context.Add(fundosinvestimento);
                _context.SaveChanges();

                return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosFundos");

            }

            ViewData["HasError"] = true;

            return View("CriarFundos");
        }


        //Mostrar Dados Imovel

        public IActionResult RecebeDadosImovel()
        {
            var db = new MyDbContext();

            var imo = db.Imovelarrendados;
            return View(imo.Select(m => new ImovelMostrarModel(m)).ToList());
        }


        //Mostrar Dados Depositos

        public IActionResult RecebeDadosDeposito(string searching)
        {
            var db = new MyDbContext();

            var depo = db.Depositosprazos;
            return View(depo.Select(m => new DepositosMostarModel(m)).ToList());
        }

        //Mostrar Dados Fundos


        public IActionResult RecebeDadosFundos()
        {
            var db = new MyDbContext();

            var fund = db.Fundosinvestimentos;
            return View(fund.Select(m => new FundosMostarModel(m)).ToList());
        }

        //Mostrar Dados Ativos
        public IActionResult RecebeDadosAtivos(string searching)
        {
            using var db = new MyDbContext();

            IQueryable<Ativofinanceiro> ativ = db.Ativofinanceiros;
            if (int.TryParse(searching, out int option))
            {
                ativ = ativ.Where(m => m.ativoOpcao == option);
            }
            return View(ativ.Select(m => new AtivosMostrarModel(m)).ToList());
        }
        

//  var result = ativ.Where(m => m.ativoOpcao.Equals(searching)).ToList();


        //Listar Ativos, Imoveis, Depositos e Fundos para poder pesquisar
        public IActionResult ListarAtivos()
        {
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosAtivos");
        }

        public IActionResult ListarImoveis()
        {
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosImovel");
        }

        public IActionResult ListarDepositos()
        {
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosDeposito");
        }

        public IActionResult ListarFundos()
        {
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosFundos");
        }


// editar e eliminar ativos

// EliminarAtivo
        public async Task<IActionResult> EliminarAtivo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ativ = await _context.Ativofinanceiros.FirstOrDefaultAsync(m => m.Idativofinanceiro == id);
            if (ativ == null)
            {
                return NotFound();
            }

            return View(ativ);
        }

        // EliminarAtivo
        [HttpPost, ActionName("EliminarAtivo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarAtivo(int id)
        {
            var ativofinanceiro = await _context.Ativofinanceiros.FindAsync(id);
            _context.Ativofinanceiros.Remove(ativofinanceiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosAtivos");
        }
        
        // EliminarDeposito
        public async Task<IActionResult> EliminarDepo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depo = await _context.Depositosprazos.FirstOrDefaultAsync(m => m.Iddepositos == id);
            if (depo == null)
            {
                return NotFound();
            }

            return View(depo);
        }

        // EliminarDepo
        [HttpPost, ActionName("EliminarDepo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarDepo(int id)
        {
            var depositosprazo = await _context.Depositosprazos.FindAsync(id);
            _context.Depositosprazos.Remove(depositosprazo);
            await _context.SaveChangesAsync();
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosDeposito");
        }
        
        // EliminarFund
        public async Task<IActionResult> EliminarFundos(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fund = await _context.Fundosinvestimentos.FirstOrDefaultAsync(m => m.Idfundos == id);
            if (fund == null)
            {
                return NotFound();
            }

            return View(fund);
        }

        // EliminarFund
        [HttpPost, ActionName("EliminarFundos")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarFundos(int id)
        {
            var fundos = await _context.Fundosinvestimentos.FindAsync(id);
            _context.Fundosinvestimentos.Remove(fundos);
            await _context.SaveChangesAsync();
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosFundos");
        }
        
        // EliminarImovel
        public async Task<IActionResult> EliminarImovel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imo = await _context.Imovelarrendados.FirstOrDefaultAsync(m => m.Idimovel == id);
            if (imo == null)
            {
                return NotFound();
            }

            return View(imo);
        }

        // EliminarImovel
        [HttpPost, ActionName("EliminarImovel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarImovel(int id)
        {
            var imoveis = await _context.Imovelarrendados.FindAsync(id);
            _context.Imovelarrendados.Remove(imoveis);
            await _context.SaveChangesAsync();
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosImovel");
        }
        
        
        //Editar
        
        public async Task<IActionResult> EditarAtivo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ativofinanceiro = await _context.Ativofinanceiros.FindAsync(id);
            if (ativofinanceiro != null)
            {   
                AtivosMostrarModel aim = new AtivosMostrarModel(ativofinanceiro);
                return View(aim);
            }
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosAtivos");
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarAtivo(int id, [Bind("Idativofinanceiro,Dataini,Duracao,Percentagemimposto,IdUser, ativoOpcao")] Ativofinanceiro ativofinanceiro)
        {
            if (id != ativofinanceiro.Idativofinanceiro)
            {
                return NotFound();
            }

            var errors = new List<string>();

            /*if (ativofinanceiro.Dataini is empty)
            {
               errors.Add("The number of calories can't be negative");
            }*/
            if (ativofinanceiro.Duracao is < 0)
            {
                errors.Add("A duração não pode ser negativa");
            }
            if (ativofinanceiro.Percentagemimposto is < 0)
            {
                errors.Add("A percentagem de imposto  não pode ser negativa");
            }

            if (ModelState.IsValid && errors.Count <= 0)
            {
                try
                {
                    _context.Update(ativofinanceiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtivofinanceiroExists(ativofinanceiro.Idativofinanceiro))
                    {   
                        
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(RecebeDadosAtivos));
            }
            ViewData["idUser"] = new SelectList(_context.Utilizadors, "idUser", "username", ativofinanceiro.IdUser);
            ViewData["Errors"] = errors;
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosAtivos");
        }
        //Verificar se existe
        private bool AtivofinanceiroExists(int id)
        {
            return _context.Ativofinanceiros.Any(e => e.Idativofinanceiro == id);
        }



        public async Task<IActionResult> EditarFundos(int? fund)
        {
            if (fund == null)
            {
                return NotFound();
            }
            var fundosinvestimento = await _context.Fundosinvestimentos.FindAsync(fund);
            if (fundosinvestimento != null)
            {   
                FundosMostarModel aim = new FundosMostarModel(fundosinvestimento);
                return View(aim);
            }
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosFundos");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarFundos(int fund, [Bind("Nome,Montanteinvestido, Taxajuro")] Fundosinvestimento fundosinvestimento)
        {
            if (fund != fundosinvestimento.Idfundos)
            {
                return NotFound();
            }

            var errors = new List<string>();
            
            if (fundosinvestimento.Nome is null)
            {
                errors.Add("O nome não pode ser null");
            }
            if (fundosinvestimento.Montanteinvestido is < 0)
            {
                errors.Add("O Montante Investido não pode ser negativo");
            }
            if (fundosinvestimento.Taxajuro is < 0)
            {
                errors.Add("A taxa juro não pode ser negativa");
            }
            
            
            if (ModelState.IsValid && errors.Count <= 0)
            {
                try
                {
                    _context.Update(fundosinvestimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundosInvestimentoExists(fundosinvestimento.Idfundos))
                    {   
                        
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }       
                }
                return RedirectToAction(nameof(RecebeDadosFundos));
            }
            ViewData["UserId"] = new SelectList(_context.Utilizadors, "idUser", "username", fundosinvestimento.IdAtivoFinanceiroNavigation!.IdUser);
            ViewData["Errors"] = errors;
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosFundos");
        }
        
        private bool FundosInvestimentoExists(int id)
        {
            return _context.Fundosinvestimentos.Any(e => e.Idfundos == id);
        }

      


        public async Task<IActionResult> EditarImovel(int? im)
        {
            if (im == null)
            {
                return NotFound();
            }
            var imovelarrendado  = await _context.Imovelarrendados.FindAsync(im);
            if (imovelarrendado != null)
            {   
                ImovelMostrarModel aim = new ImovelMostrarModel(imovelarrendado);
                return View(aim);
            }
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosImovel");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarImovel(int im, [Bind("Designacao,Localizacao,Valorimovel,Valormensalcondominio,Valorrenda,Valoranual")] Imovelarrendado imovelarrendado)
        {
            if (im != imovelarrendado.Idimovel)
            {
                return NotFound();
            }

            var errors = new List<string>();
            
            if (imovelarrendado.Designacao is null)
            {
                errors.Add("A designação não pode ser null");
            }
            if (imovelarrendado.Localizacao is null)
            {
                errors.Add("A localização não pode ser null");
            }
            if (imovelarrendado.Valorimovel is < 0)
            {
                errors.Add("O valor do imovel não pode ser negativo");
            }
            if (imovelarrendado.Valormensalcondominio is < 0)
            {
                errors.Add("O valor mensal do condominio não pode ser negativo");
            }
            if (imovelarrendado.Valorrenda is < 0)
            {
                errors.Add("O valor da renda não pode ser negativo");
            }
            if (imovelarrendado.Valoranual is < 0)
            {
                errors.Add("O valor anual não pode ser negativo");
            }
            
            
            if (ModelState.IsValid && errors.Count <= 0)
            {
                try
                {
                    _context.Update(imovelarrendado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelArrendadoExists(imovelarrendado.Idimovel))
                    {   
                        
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }       
                }
                return RedirectToAction(nameof(RecebeDadosImovel));
            }
            //ViewData["idAtivoFinanceiro"] = new SelectList(_context.Ativofinanceiros, "idAtivoFinanceiro", "idativofinanceiro", Ativofinanceiro.);
            ViewData["Errors"] = errors;
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosImovel");
        }
        
        private bool ImovelArrendadoExists(int id)
        {
            return _context.Imovelarrendados.Any(e => e.Idimovel == id);
        }
        
     
        public async Task<IActionResult> EditarDeposito(int? depo)
        {
            if (depo == null)
            {
                return NotFound();
            }
            var depositosprazo = await _context.Depositosprazos.FindAsync(depo);
            if (depositosprazo != null)
            {   
                DepositosMostarModel aim = new DepositosMostarModel(depositosprazo);
                return View(aim);
            }
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosDeposito");
        }
        
         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarDeposito(int depo, [Bind("Iddepositos,Valor,Banco,Numeroconta,Titulares, Taxajurosanual,IdAtivoFinanceiro")] Depositosprazo depositosprazo)
        {
            if (depo != depositosprazo.Iddepositos)
            {
                return NotFound();
            }

            var errors = new List<string>();

            /*if (ativofinanceiro.Dataini is empty)
            {
               errors.Add("The number of calories can't be negative");
            }*/
            if (depositosprazo.Valor is < 0)
            {
                errors.Add("A duração não pode ser negativa");
            }
            if (depositosprazo.Numeroconta is < 0)
            {
                errors.Add("A percentagem de imposto  não pode ser negativa");
            }

            if (ModelState.IsValid && errors.Count <= 0)
            {
                try
                {
                    _context.Update(depositosprazo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepositosprazoExists(depositosprazo.Iddepositos))
                    {   
                        
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(RecebeDadosAtivos));
            }
            ViewData["idUser"] = new SelectList(_context.Utilizadors, "idUser", "username", depositosprazo.IdAtivoFinanceiroNavigation!.IdUser);
            ViewData["Errors"] = errors;
            return RedirectToAction(controllerName: "Ativos", actionName: "RecebeDadosDeposito");
        }
        //Verificar se existe
        private bool DepositosprazoExists(int depo)
        {
            return _context.Depositosprazos.Any(e => e.Iddepositos == depo);
        }

    }
}
    


