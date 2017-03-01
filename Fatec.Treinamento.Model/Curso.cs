using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int idAutor { get; set; }
        public int idAssunto { get; set; }
        public int Classificacao { get; set; }
    }
}
