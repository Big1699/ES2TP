
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
                UserSession.UserId = user.Iduser;
                UserSession.Username = user.Username;
                return RedirectToAction(controllerName: "Home", actionName: "Index");
            }

            ViewData["HasError"] = true;

            return View(login);
        }


    }
}