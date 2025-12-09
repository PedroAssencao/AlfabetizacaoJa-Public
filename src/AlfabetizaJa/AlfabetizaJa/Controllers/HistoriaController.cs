using AlfabetizaJa.DAL;
using AlfabetizaJa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlfabetizaJa.Controllers
{
    [Authorize(Roles = "Login")]
    public class HistoriaController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            HistoriaDAO Historia = new HistoriaDAO();
            ViewBag.ListaHistoria = Historia.getTodasHistorias();
            return View();
        }

        public IActionResult Create()
        {
            HistoriaDAO Historia = new HistoriaDAO();
            ViewBag.ListaHistoria = Historia.getTodasHistorias();
            return View();
        }

        [HttpGet]
        public IActionResult Apagar(int id, string imagem)
        {
            if (imagem != "'/img/default_book_cover_2015.jpg'")
            {
                var path = $@"wwwroot/{imagem}";
                System.IO.File.Delete(path);
            }
            Historia ApagarHistoria = new Historia();
            HistoriaDAO HistoriaTabela = new HistoriaDAO();
            ApagarHistoria.hist_id = Convert.ToInt32(id);
            HistoriaTabela.ApagarHistoria(ApagarHistoria);


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            HistoriaDAO Historia = new HistoriaDAO();
            ViewBag.HistoriaAtualizar = Historia.getTodasHistorias().Where(x => x.hist_id == id).FirstOrDefault();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, int hist_id, string hist_Autor, string hist_Titulo, string Hist_trecho, IFormFile novaImagem)
        {


            HistoriaDAO HistoriaTabela = new HistoriaDAO();
            var a = ViewBag.HistoriaAtualizar = HistoriaTabela.getTodasHistorias().FirstOrDefault(x => x.hist_id == id);
            a.hist_id = Convert.ToInt32(hist_id);
            a.hist_Autor = Convert.ToString(hist_Autor);
            a.hist_Titulo = Convert.ToString(hist_Titulo);
            a.Hist_trecho = Convert.ToString(Hist_trecho);

            if (novaImagem != null)
            {
                var filess = Directory.GetFiles($"wwwroot/img/Historia").Length + 1;
                string pathh = $"img/Historia/Historia-{filess + 1}.jpg";
                a.hist_img = pathh;
            }


            HistoriaTabela.AtualizarQuarto(a);


            var files = Directory.GetFiles($"wwwroot/img/Historia").Length + 1;

            string path = $"wwwroot/img/Historia/Historia-{files + 1}.jpg";

            if (novaImagem is not null)
            {

                using var stream = new MemoryStream();
                await novaImagem.CopyToAsync(stream);
                stream.Position = 0;
                using var fileStream = new FileStream($"{path}", FileMode.OpenOrCreate);
                await stream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                fileStream.Close();
                return RedirectToAction($"Index", "Historia");

            }
            else
            {
                return RedirectToAction($"Index", "Historia");
            }


        }


        [HttpPost]
        public async Task<IActionResult> CriarHistoria(string Titulo, IFormFile novaImagem, string Autor, string texto)
        {

            Historia historia = new Historia();
            historia.hist_Autor = Autor;
            historia.hist_Titulo = Titulo;
            historia.Hist_trecho = texto;

            var filess = Directory.GetFiles($"wwwroot/img/Historia").Length + 1;

            string pathh = $"img/Historia/Historia-{filess + 1}.jpg";

            historia.hist_img = pathh;

            HistoriaDAO dados = new HistoriaDAO();

            bool result = dados.InserirHistoria(historia);

            if (result)
            {
                var files = Directory.GetFiles($"wwwroot/img/Historia").Length + 1;

                string path = $"wwwroot/img/Historia/Historia-{files + 1}.jpg";

                if (novaImagem is not null)
                {
                    using var stream = new MemoryStream();
                    await novaImagem.CopyToAsync(stream);
                    stream.Position = 0;
                    using var fileStream = new FileStream($"{path}", FileMode.OpenOrCreate);
                    await stream.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                    fileStream.Close();
                    return RedirectToAction($"Index", "Historia");
                }
                else
                {
                    return RedirectToAction($"Index", "Historia");
                }


            }
            else
            {
                var files = Directory.GetFiles($"wwwroot/img/Historia").Length + 1;

                string path = $"wwwroot/img/Historia/Historia-{files + 1}.jpg";

                if (novaImagem is not null)
                {
                    using var stream = new MemoryStream();
                    await novaImagem.CopyToAsync(stream);
                    stream.Position = 0;
                    using var fileStream = new FileStream($"{path}", FileMode.OpenOrCreate);
                    await stream.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                    fileStream.Close();
                    return RedirectToAction($"Index", "Historia");
                }
                else
                {
                    return RedirectToAction($"Index", "Historia");
                }

            }


        }


    }
}