﻿using Fatec.Treinamento.Model;
using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Data.Repositories.Interfaces
{
    public interface IVideoRepository : ICrudRepository<Video>
    {
        IEnumerable<VideoPorCapitulo> ListarTotalVideoPorCapitulo(int id);
    }
}
