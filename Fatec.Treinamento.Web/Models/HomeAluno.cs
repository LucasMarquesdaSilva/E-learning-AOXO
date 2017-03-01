using Fatec.Treinamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fatec.Treinamento.Web.Models
{
    public class HomeAluno
    {

        public List <Usuario> Usuario{ get; set; }
        public List<Curso> Cursos  { get; set; }



    }
}