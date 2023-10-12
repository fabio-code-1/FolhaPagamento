using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FolhaPagamento.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace FolhaPagamento.Controllers
{
    public class AccountController : Controller
    {
        private readonly Contexto _context;

        public AccountController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string pass)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == pass);

            if (user != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username), // Nome de usuário
            new Claim(ClaimTypes.Role, user.UserRole.ToString()), // Papel
            new Claim(ClaimTypes.GivenName, user.Nome), // Nome completo do usuário
            new Claim("Cargo", user.Cargo), // Cargo do usuário
            new Claim("UserRoleDescription", user.UserRoleDescription) // UserRoleDescription
            // Adicione outras reivindicações conforme necessário
        };

                var identity = new ClaimsIdentity(claims, "MyCookieAuthenticationScheme");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuthenticationScheme", principal);

                if (user.UserRole == 1)
                {
                    return RedirectToAction("Index", "Users");
                }
                else if (user.UserRole == 2)
                {
                    return RedirectToAction("Index", "Ferias");
                }
                else
                {
                    ModelState.AddModelError("", "Credenciais inválidas");

                    // Chame a função JavaScript para exibir o popup de erro
                    ViewBag.ErrorMessage = "Credenciais inválidas";
                    return View(); // Página de login com erro
                }
            }
            else
            {
                ModelState.AddModelError("", "Credenciais inválidas");
                return View(); // Volte para a página de login com mensagem de erro
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuthenticationScheme");
            return RedirectToAction("Login", "Account");
        }




    }
}
