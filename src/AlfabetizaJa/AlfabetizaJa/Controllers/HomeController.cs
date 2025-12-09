using AlfabetizaJa.DAL;
using AlfabetizaJa.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlfabetizaJa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            HistoriaDAO Historia = new HistoriaDAO();
            LoginDAO login = new LoginDAO();

            ViewBag.loginLista = login.getTodosLOgins();

            ViewBag.ListaHistoria = Historia.getTodasHistorias();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}