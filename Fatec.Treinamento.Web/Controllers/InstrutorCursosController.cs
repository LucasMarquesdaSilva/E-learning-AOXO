using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    [Authorize(Roles = "Instrutor")]
    public class InstrutorCursosController : Controller
    {


        public ActionResult Index()
        {
            IEnumerable<DetalhesCurso> lista = new List<DetalhesCurso>();

            using (CursoRepository repo = new CursoRepository())
            {
                lista = repo.ListarCursos();
            }

            return View(lista);
        }

        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Curso curso)
        {
            using (var repo = new CursoRepository())
            {
                var inserido = repo.Criar(curso);


                return RedirectToAction("Index");

            }
        }

        [HttpGet]
        public ActionResult Detalhes(Curso curso)
        {
            var repo = new CursoRepository();
            var lista = repo.ObterDetalhesCurso(curso.Id);

            return View(lista);
        }

        [HttpGet]
        public ActionResult Excluir(Curso curso)
        {
            var repo = new CursoRepository();
            var excluir = repo.ObterDetalhesCurso(curso.Id);
            if (excluir == null)
            {
                return HttpNotFound();
            }
            return View(excluir);

        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(Curso curso)
        {
            var repo = new CursoRepository();
            repo.Excluir(curso);

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            using (var repo = new CursoRepository())
            {
                var curso = repo.ObterCursoPorId(id);

                return View(curso);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Curso curso)
        {
            using (var repo = new CursoRepository())
            {
                curso = repo.Atualizar(curso);

                return RedirectToAction("Index");
            }
        }


    }
}