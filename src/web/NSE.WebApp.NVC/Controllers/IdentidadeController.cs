using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.NVC.Models;

namespace NSE.WebApp.NVC.Controllers
{
    public class IdentidadeController : Controller
    {
        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsarioRegistro usuarioRegistro) 
        {

        }

        [HttpGet]
        [Route("login")]
        public IActionResult login() 
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin) 
        {

        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        { 

        }
    }
}
