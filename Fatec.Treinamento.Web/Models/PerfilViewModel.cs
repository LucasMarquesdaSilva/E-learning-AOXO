using Fatec.Treinamento.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Models
{
    public class PerfilViewModel
    {
        public Assunto Trilha { get; set; }

        public IList<SelectListItem> AssuntosDisponiveis { get; set; }

        [DisplayName("Assuntos Selecionados")]
        public IList<int> AssuntosSelecionados { get; set; }

        public PerfilViewModel()
        {
            AssuntosDisponiveis = new List<SelectListItem>();
            AssuntosSelecionados = new List<int>();
        }
    }
}