using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pedagio.Data;


namespace Pedagio.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginUsuario(string username, string password)
        {

            var User = username;
            var Password = password;

            int result = _loginRepository.BuscaUsuario(username, password);

            if (result == 1)
            {
                return RedirectToAction("CompararExcel", "Comparacao");

            }
            else
            {
                ViewBag.Messagem = "Não Localizado";
                return View("Index");
            }

            
        }

    }
}
