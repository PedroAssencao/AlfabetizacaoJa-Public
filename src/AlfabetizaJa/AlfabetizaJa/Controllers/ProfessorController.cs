using AlfabetizaJa.DAL;
using AlfabetizaJa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlfabetizaJa.Controllers
{
    public class ProfessorController : Controller
    {
        [Authorize(Roles = "Login")]

        [HttpGet]
        public IActionResult Index()
        {
            AlunosDAO Alunos = new AlunosDAO();
            SalaDAO Sala = new SalaDAO();
            ViewBag.ListaAlunos = Alunos.getTodosAlunos(int.Parse(User?.Identity?.Name ?? 0.ToString()));
            ViewBag.sala = Sala.getTodasSalas().Where(x => x.log_id == int.Parse(User?.Identity?.Name ?? 0.ToString())).LastOrDefault();
            return View();
        }

        [HttpPost]
        public IActionResult rank(string name, string nota, int login)
        {
            Salas salaModel = new Salas();
            SalaDAO SalaDAOO = new SalaDAO();
            if (SalaDAOO.SalaAberta(login) == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Alunos UpdateAlunos = new Alunos();
                AlunosDAO AlunosTabela = new AlunosDAO();
                UpdateAlunos.nome_aluno = name;
                UpdateAlunos.nota = nota;
                UpdateAlunos.log_id = login;
                AlunosTabela.InserirAlunos(UpdateAlunos);
                return RedirectToAction("Index", "Home");
            }

        }
    }
}
