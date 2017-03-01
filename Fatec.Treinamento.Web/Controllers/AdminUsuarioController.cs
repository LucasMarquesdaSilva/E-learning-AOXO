using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
   [Authorize(Roles = "Administrador")]
    public class AdminUsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            var repo = new UsuarioRepository();

            var lista = repo.Listar();
            return View(lista);

        }
    

        [HttpGet]
        public ActionResult Excluir(Usuario usuario)
        {
            var repo = new UsuarioRepository();
            var aluno = repo.Obter(usuario.Id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);


        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(Usuario usuario)
        {
            var repo = new UsuarioRepository();
            repo.Excluir(usuario);

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            using (var repoPerfil = new PerfilRepository())
            {
                var listaPerfil = repoPerfil.Listar();

                var itemLista = new List<SelectListItem>();

                foreach (var item in listaPerfil)
                {
                    var itemSelect = new SelectListItem
                    {
                        Text = item.Nome,
                        Value = item.Id.ToString()
                    };

                    itemLista.Add(itemSelect);


                }

                ViewBag.ItensSelect = itemLista;

                using (var repo = new UsuarioRepository())
                {
                    var usuario = repo.Obter(id);

                    return View(usuario);
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Usuario usuario)
        {
            using (var repoPerfil = new PerfilRepository())
            {
                var listaPerfil = repoPerfil.Listar();

                var itemLista = new List<SelectListItem>();

                foreach (var item in listaPerfil)
                {
                    var itemSelect = new SelectListItem
                    {
                        Text = item.Nome,
                        Value = item.Id.ToString()

                    };

                    itemLista.Add(itemSelect);

                    usuario.IdPerfil = item.Id.ToString();
                }

                ViewBag.ItensSelect = itemLista;



                using (var repo = new UsuarioRepository())
                {
                    usuario = repo.Atualizar(usuario);

                    return RedirectToAction("Index");
                }

            }
        }








        [HttpGet]
        public ActionResult Detalhes(Usuario usuario)
        {
            var repo = new UsuarioRepository();
            var user = repo.Obter(usuario.Id);
            return View (user);
        }
    }
}