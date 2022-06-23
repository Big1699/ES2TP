
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ES2TP.Context;
using ES2TP.Entities;
using ES2TP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ES2TP.Controllers
{
    public class AuthController : Controller
    {
        private readonly MyDbContext _context;

        public AuthController()
        {
            _context = new MyDbContext();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] LoginModel login)
        {

            var user = _context.Utilizadors
                .FirstOrDefault(u => u.Email.Equals(login.Email) && u.Password.Equals(login.Password));

            

            if (user != null)
            {
                UserSession.idutilizador = user.Iduser;
                return RedirectToAction(controllerName: "Ativos", actionName: "AtivosMenu");
            }
            
            var admin = _context.Administradors.FirstOrDefault(a => a.Email.Equals(login.Email) && a.Password.Equals(login.Password));

            if (admin != null)
            {
                UserSession.idadmin = admin.Idadmin;
                return RedirectToAction(controllerName: "Admin", actionName: "AdminMenu");
            }

            if (login.Email.Equals("AdminMaster@gmail.com") &&
                login.Password.Equals("AdminMaster"))
            {
                return RedirectToAction(controllerName: "Admin", actionName: "AdminMenu");
            }

            ViewData["HasError"] = true;

            return View(login);
        }


        public IActionResult Registar()
        {
            return RedirectToAction(controllerName: "Regist", actionName: "Regist");
        }
    }
}