using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model
{
    public class Treino
    {
        public int idUsuario { get; set; }

        public int idCurso { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime UltimoAcesso { get; set; }

        public DateTime DataConclusao { get; set; }
    }
}
