using ES2TP.Context;
using ES2TP.Entities;
using ES2TP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ES2TP.Controllers;

public class UserManagerController : Controller
{

    private readonly MyDbContext _context;

    public UserManagerController()
    {
        _context = new MyDbContext();
    }

    public IActionResult UserManagerMenu()
    {
        return View();
    }

    public IActionResult CriarUtilizador()
    {
        return RedirectToAction(controllerName: "Regist", actionName: "Regist");
    }

    public IActionResult ListarUsers()
    {
        return RedirectToAction(controllerName: "UserManager", actionName: "MostrarDadosUtilizadores");
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

    public IActionResult MostrarDadosUtilizadores()
    {
        var db = new MyDbContext();

        var user = db.Utilizadors;
        return View(user.Select(m => new UsersMostrarModel(m)).ToList());
    }

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

            return RedirectToAction(nameof(ListarUsers));
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

    // EliminarAdmin
    [HttpPost, ActionName("EliminarUser")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EliminarUser(int id)
    {
        var user = await _context.Utilizadors.FindAsync(id);
        _context.Utilizadors.Remove(user);
        await _context.SaveChangesAsync();
        return RedirectToAction(controllerName: "UserManager", actionName: "ListarUsers");
    }

}