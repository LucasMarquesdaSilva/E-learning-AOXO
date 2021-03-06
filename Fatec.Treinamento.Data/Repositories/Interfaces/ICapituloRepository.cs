﻿using Fatec.Treinamento.Model;
using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Data.Repositories.Interfaces
{
    interface ICapituloRepository : ICrudRepository<Capitulo>
    {
        IEnumerable<CapituloPorCurso> ListarTotalCapituloPorCurso(int id);
    }
}
