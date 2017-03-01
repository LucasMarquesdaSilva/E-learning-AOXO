using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fatec.Treinamento.Web.Models;
using Fatec.Treinamento.Model.DTO;

namespace Fatec.Treinamento.Web.Controllers
{
    // Obs: Colocando o atributo [Authorize] no controller, garante que todas as actions so podem ser
    // acessadas quando o usuário estiver autorizado a utilizar.
    // Quando informo o parametro "Roles", indico que só quem tiver o perfil administrador poderá acessar.


    public class TrilhaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var repo = new TrilhaRepository();

            var lista = repo.Listar();

            return View(lista);
        }


        [HttpGet]
        public ActionResult CursosVinculados(int id)
        {
            using (TrilhaRepository repo = new TrilhaRepository())
            {
                var trilha = repo.Obter(id);
                return View(trilha);
            }

        }


        [HttpPost]
        public ActionResult CursosVinculados(Trilha trilha)
        {
            trilha = new Trilha();

            return View(trilha);
        }





    }



}