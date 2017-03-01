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
    public class InstrutorAlunosController : Controller
    {

        public ActionResult Index()
        {

            var repo = new UsuarioRepository();
            var lista = repo.Listar();

            return View(lista);

        }

        [HttpGet]
        public ActionResult Detalhes(Usuario usuario)
        {
            var repo = new UsuarioRepository();
            var user = repo.Obter(usuario.Id);

            return View(user);
        }
    }
}