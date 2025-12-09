using AlfabetizaJa.DAL;
using Microsoft.AspNetCore.Mvc;

namespace AlfabetizaJa.Controllers
{
    public class LeituraController : Controller
    {
        [HttpGet]
        public IActionResult Index(int id, int login, int passe)
        {
            SalaDAO sala = new SalaDAO();
            HistoriaDAO Historia = new HistoriaDAO();
            int salaAberta = sala.SalaAberta(login);

            if (salaAberta == 0 && passe == 1) 
            {
                ViewBag.HistoriaAtualizar = Historia.getTodasHistorias().Where(x => x.hist_id == id).FirstOrDefault();
                return View();
              
            }
            else if (salaAberta == 0)
            {
                return RedirectToAction("Index", "Home");
            }

         
            ViewBag.HistoriaAtualizar = Historia.getTodasHistorias().Where(x => x.hist_id == id).FirstOrDefault();
            return View();
        }


    }
}