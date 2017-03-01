using Dapper;
using Fatec.Treinamento.Data.Repositories.Base;
using Fatec.Treinamento.Data.Repositories.Interfaces;
using Fatec.Treinamento.Model;
using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Data.Repositories
{
    public class VideoRepository : RepositoryBase, IVideoRepository
    {
        public Video Atualizar(Video video)
        {
            Connection.Execute(
               @"UPDATE Video SET 
                    Nome = @Nome,
                    Duracao = @Duracao,
                    CodigoYoutube = @CodigoYoutube
                WHERE Id = @Id",
               param: new
               {
                   video.Nome,
                   video.Id,
                   video.Duracao,
                   video.CodigoYoutube
               }
            );

            return video;
        }

        public void Excluir(Video Video)
        {

            Connection.Execute(
                "DELETE FROM Video WHERE Id = @Id",
                param: new { Id = Video.Id }
            );

        }

        public Video Inserir(Video Video)
        {
            var id = Connection.ExecuteScalar<int>(
                @"INSERT INTO Video (Nome, Duracao, CodigoYoutube) 
                 VALUES (@Nome, @Duracao, @CodigoYoutube); 
               SELECT SCOPE_IDENTITY()",
                param: new
                {
                    Video.Nome,
                    Video.Duracao,
                    Video.CodigoYoutube
                }
            );

            Video.Id = id;
            return Video;
        }

        public IEnumerable<Video> Listar()
        {
            return Connection.Query<Video>(
               @"SELECT Id,IdCapitulo, Nome, CodigoYoutube,Duracao FROM Video
                ORDER BY Nome ASC"
             ).ToList();
        }

        public Video Obter(int id)
        {
            return Connection.Query<Video>(
               "SELECT Id, Nome, IdCapitulo,CodigoYoutube, Duracao FROM Video WHERE Id = @id",
               param: new { Id = id }
           ).FirstOrDefault();
        }






        public Video Criar(Video Video)
        {
            Connection.Execute(
               @"INSERT INTO Video (Nome, Duracao, IdCapitulo, CodigoYoutube) 
                 VALUES (@Nome, @Duracao, @IdCapitulo, @CodigoYoutube); 
               SELECT SCOPE_IDENTITY()",
               param: new
               {
                   Video.Nome,
                   Video.Duracao,
                   Video.IdCapitulo,
                   Video.CodigoYoutube

               }
           );

            return Video;
        }

        public IEnumerable<VideoPorCapitulo> ListarTotalVideoPorCapitulo(int id)
        {
            return Connection.Query<VideoPorCapitulo>(
              @"Select V.Nome, V.IdCapitulo, V.Duracao,V.CodigoYouTube, V.Id
                FROM Capitulo cap INNER JOIN Video V on cap.Id = V.IdCapitulo
                WHERE cap.Id = @id
                
                ORDER BY V.Nome", new { Id = id }
            ).ToList();
        }
    }
}
