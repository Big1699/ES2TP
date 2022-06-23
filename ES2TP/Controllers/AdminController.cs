using Microsoft.AspNetCore.Mvc;

namespace ES2TP.Controllers;

public class AdminController : Controller
{
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
    
}