using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    [Authorize(Roles = "Instrutor")]
    public class InstrutorVideoController : Controller
    {
        // GET: InstrutorVideo
        public ActionResult Index(int id)
        {
            var repo = new VideoRepository();
            var lista = repo.ListarTotalVideoPorCapitulo(id);

            return View(lista);
        }

        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Video Video)
        {
            using (var repo = new VideoRepository())
            {
                var inserido = repo.Criar(Video);

                if (inserido.Id == 0)
                {
                    ModelState.AddModelError("", "Erro");
                }

            }

            return RedirectToAction("Index", new { id = Video.IdCapitulo });
        }


        [HttpGet]
        public ActionResult Editar(int id)
        {
            using (var repo = new VideoRepository())
            {
                var Video = repo.Obter(id);

                return View(Video);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Video Video)
        {
            using (var repo = new VideoRepository())
            {
                Video = repo.Atualizar(Video);

                return RedirectToAction("Index", new { id = Video.IdCapitulo });
            }
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {

            using (var repo = new VideoRepository())
            {
                var Video = repo.Obter(id);

                return View(Video);
            }
        }

        [HttpPost]
        public ActionResult Excluir(Video Video)
        {
            using (var repo = new VideoRepository())
            {
                repo.Excluir(Video);

                return RedirectToAction("Index", "InstrutorCursos");
            }
        }

        [HttpGet]
        public ActionResult Detalhes(int id)
        {

            using (var repo = new VideoRepository())
            {
                var Video = repo.Obter(id);

                return View(Video);
            }
        }
    }
}