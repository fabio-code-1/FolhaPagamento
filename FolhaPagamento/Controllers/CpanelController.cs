using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FolhaPagamento.Controllers
{
    [Authorize(Policy = "RequireLoggedIn")]
    public class CpanelController : Controller
    {
        [Authorize(Roles = "1")]
        public IActionResult CpanelRh()
        {
            return View();
        }

        [Authorize(Roles = "2")]
        public IActionResult CpanelFuncionario()
        {
            return View();
        }

        public IActionResult Calculadora()
        {
            return View();
        }


    }
}
