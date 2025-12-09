using AlfabetizaJa.DAL;
using AlfabetizaJa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AlfabetizaJa.Controllers
{
    [Authorize(Roles = "Login")]
    public class SalaController : Controller
    {
        
        [HttpGet]
        public IActionResult Index(int id, int id2)
        {

            SalaDAO sala = new SalaDAO();
            HistoriaDAO Historia = new HistoriaDAO();
            var logins = User.Identity.Name;

            int salaAberta = sala.SalaAberta(Convert.ToInt32(logins));

            if (salaAberta == 0)
            {
                LoginDAO login = new LoginDAO();

                ViewBag.HistoriaAtualizar = Historia.getTodasHistorias().Where(x => x.hist_id == id).FirstOrDefault();

                ViewBag.LoginAtualizar = login.getTodosLOgins().Where(x => x.log_id == id2).FirstOrDefault();


                return View();

            }
            else if (salaAberta == 1)
            {
                return RedirectToAction("Index", "Professor");
            }

            

          
        
            return View();
            
        }

        [HttpPost]
        public IActionResult ajax(int id, string url, bool sala)
        {
            SalaDAO salaDAO = new SalaDAO();
            Salas salas = new Salas();
            salas.log_id = id;
            salas.sala_url = url;
            salas.sala_aberta = sala;

            try
            {
                
                salaDAO.InserirSala(salas);

                
                return RedirectToAction("Index", "Professor");
            }
            catch (Exception ex)
            {
                
                return Json(new { success = false, message = "Ocorreu um erro durante o processamento da solicitação: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult update(int id)
        {

            SalaDAO salaDAO = new SalaDAO();
            Salas salas = new Salas();
            salas.log_id = id;
            salaDAO.update(salas);
            AlunosDAO AlunosTabela = new AlunosDAO();
            AlunosTabela.Delete(id);
            return RedirectToAction("Index", "Home");

        }





    }
}
