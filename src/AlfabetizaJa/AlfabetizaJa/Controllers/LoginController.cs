using AlfabetizaJa.DAL;
using AlfabetizaJa.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace AlfabetizaJa.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();

        }
        [HttpGet]
        public IActionResult Cadastro()
        {

            return View();


        }

        [HttpPost]
        public IActionResult Create(string User, string email, string senha, string NumeroWhatsapp)
        {
            Login login = new Login();
            LoginDAO loginDAO = new LoginDAO();
            login.log_user = User;
            login.log_email = email;
            login.log_numeroW = NumeroWhatsapp;

          
                var a = Encoding.UTF8.GetBytes(senha);
                var b = Convert.ToBase64String(a);
                login.log_senha = b;
            loginDAO.InserirConta(login);
            return RedirectToAction("Index", "Login");
            
    
        }

        [HttpPost]
        public async Task<IActionResult> checarLogin(string email, string senha)
        {
            LoginDAO loginDAO = new LoginDAO();
            Login loginestabelecido = new Login();

            var logins = loginDAO.getTodosLOgins().ToList();
            var login = logins.FirstOrDefault(x => x.log_email == email && loginestabelecido.DescriptografaSenha(x.log_senha) == senha);
            if (login != null)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, login.log_id.ToString()),
                        new Claim(ClaimTypes.Role, "Login"),
                        new Claim(ClaimTypes.NameIdentifier, login.log_user)
                    };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Mensagem"] = "Erro: Não foi possível concluir a operação.";
                return RedirectToAction("Index", "Login");
            }


        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
