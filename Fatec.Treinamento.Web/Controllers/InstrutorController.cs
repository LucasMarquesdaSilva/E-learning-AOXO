using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    [Authorize(Roles = "Instrutor")]
    public class InstrutorController : Controller
    {
        // GET: Instrutor
        public ActionResult Index(Usuario usuario)
        {
            usuario.Id = int.Parse(User.Identity.GetUserId().ToString());
            var repo = new UsuarioRepository();
            var lista = repo.Obter(usuario.Id);

            return View(lista);
        }
    }
}