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
    public class InstrutorCapituloController : Controller
    {
        // GET: InstrutorCapitulo
        public ActionResult Index(int id)
        {
            var repo = new CapituloRepository();
            var lista = repo.ListarTotalCapituloPorCurso(id);


            ViewBag.IdCurso = id;


            return View(lista);
        }

        [HttpGet]
        public ActionResult Criar(int idCurso)
        {
            var capitulo = new Capitulo {IdCurso = idCurso};

            return View(capitulo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Capitulo capitulo)
        {
            using (var repo = new CapituloRepository())
            {
                var inserido = repo.Criar(capitulo);

                if (inserido.Id == 0)
                {
                    ModelState.AddModelError("", "Erro");
                }

            }

            return RedirectToAction("Index", new { id = capitulo.IdCurso });
        }


        [HttpGet]
        public ActionResult Editar(int id)
        {
            using (var repo = new CapituloRepository())
            {
                var capitulo = repo.Obter(id);

                return View(capitulo);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Capitulo capitulo)
        {
            using (var repo = new CapituloRepository())
            {
                capitulo = repo.Atualizar(capitulo);

                return RedirectToAction("Index", new { id = capitulo.IdCurso });
            }
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {

            using (var repo = new CapituloRepository())
            {
                var capitulo = repo.Obter(id);

                return View(capitulo);
            }
        }

        [HttpPost]
        public ActionResult Excluir(Capitulo capitulo)
        {
            using (var repo = new CapituloRepository())
            {
                repo.Excluir(capitulo);

                return RedirectToAction("Index", "InstrutorCursos");
            }
        }

        [HttpGet]
        public ActionResult Detalhes(int id)
        {

            using (var repo = new CapituloRepository())
            {
                var capitulo = repo.Obter(id);

                return View(capitulo);
            }
        }



    }
}