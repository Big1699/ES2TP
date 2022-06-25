using ES2TP.Context;
using ES2TP.Entities;
using ES2TP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ES2TP.Controllers;

public class AdminController : Controller
{
    
    private readonly MyDbContext _context;

    public AdminController()
    {
        _context = new MyDbContext();
    }

    public IActionResult AdminMenu()
    {
        return View();
    }

    public IActionResult CriarAdmin()
    {
        return RedirectToAction(controllerName: "RegistAdmin", actionName: "RegistAdmin");
    }

    public IActionResult CriarUtilizador()
    {
        return RedirectToAction(controllerName: "Regist", actionName: "Regist");
    }

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
    
    
// EliminarUser
    public async Task<IActionResult> EliminarUser(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.Utilizadors.FirstOrDefaultAsync(m => m.Iduser == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // EliminarUser
    [HttpPost, ActionName("EliminarUser")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EliminarUser(int id)
    {
        var user = await _context.Utilizadors.FindAsync(id);
        _context.Utilizadors.Remove(user);
        await _context.SaveChangesAsync();
        return RedirectToAction(controllerName: "Admin", actionName: "AlterarPermissao");
    }

    public IActionResult AlterarPermissoes()
    {
        return RedirectToAction(controllerName: "Admin", actionName: "AlterarPermissao");
    }

    public IActionResult AlterarPermissao()
    {
        var db = new MyDbContext();

        var user = db.Utilizadors;
        return View(user.Select(m => new UsersMostrarModel(m)).ToList());
    }
    
    public IActionResult AlterarParaAdmin()
    {
        return RedirectToAction(controllerName: "Admin", actionName: "AlterarPermissao");
    }


    public IActionResult ListarAdmins()
    {
        return RedirectToAction(controllerName: "Admin", actionName: "ListarAdmin");
    }

    public IActionResult ListarAdmin()
    {
        var db = new MyDbContext();

        var admin = db.Administradors;
        return View(admin.Select(m => new AdminMostrarModel(m)).ToList());
    }
    
    //Editar
    
    public async Task<IActionResult> EditarUtilizador(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.Utilizadors.FindAsync(id);
        if (user != null)
        {
            UsersMostrarModel aim = new UsersMostrarModel(user);
            return View(aim);
        }

        return RedirectToAction(controllerName: "UserManager", actionName: "ListarUsers");
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditarUtilizador(int id,
        [Bind("Iduser,Email,Username,Password,tipoUser")] Utilizador utilizador)
    {
        if (id != utilizador.Iduser)
        {
            return NotFound();
        }

        var errors = new List<string>();


        if (ModelState.IsValid && errors.Count <= 0)
        {
            try
            {
                _context.Update(utilizador);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(utilizador.Iduser))
                {

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(AlterarPermissao));
        }

        ViewData["idUser"] = new SelectList(_context.Utilizadors, "idUser", "username", utilizador.Iduser);
        ViewData["Errors"] = errors;
        return RedirectToAction(controllerName: "UserManager", actionName: "ListarUsers");
    }

    //Verificar se existe
    private bool UserExists(int id)
    {
        return _context.Utilizadors.Any(e => e.Iduser == id);
    }
    
          public async Task<IActionResult> EditarAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var admin = await _context.Administradors.FindAsync(id);
            if (admin != null)
            {   
                AdminMostrarModel aim = new AdminMostrarModel(admin);
                return View(aim);
            }
            return RedirectToAction(controllerName: "Admin", actionName: "ListarAdmin");
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarAdmin(int id, [Bind("Idadmin,Email,Username,Password")] Administrador administrador)
        {
            if (id != administrador.Idadmin)
            {
                return NotFound();
            }

            var errors = new List<string>();
            

            if (ModelState.IsValid && errors.Count <= 0)
            {
                try
                {
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(administrador.Idadmin))
                    {   
                        
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListarAdmin));
            }
            ViewData["IdAdmin"] = new SelectList(_context.Administradors, "IdAdmin", "username", administrador.Idadmin);
            ViewData["Errors"] = errors;
            return RedirectToAction(controllerName: "Admin", actionName: "ListarAdmin");
        }
        //Verificar se existe
        private bool AdminExists(int id)
        {
            return _context.Administradors.Any(e => e.Idadmin == id);
        }
    
// EliminarAdmin
    public async Task<IActionResult> EliminarAdmin(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var admin = await _context.Administradors.FirstOrDefaultAsync(m => m.Idadmin == id);
        if (admin == null)
        {
            return NotFound();
        }

        return View(admin);
    }

    // EliminarAdmin
    [HttpPost, ActionName("EliminarAdmin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EliminarAdmin(int id)
    {
        var admin = await _context.Administradors.FindAsync(id);
        _context.Administradors.Remove(admin);
        await _context.SaveChangesAsync();
        return RedirectToAction(controllerName: "Admin", actionName: "ListarAdmin");
    }

}