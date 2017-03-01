using Fatec.Treinamento.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fatec.Treinamento.Model;
using Fatec.Treinamento.Data.Repositories.Base;
using Dapper;
using Fatec.Treinamento.Model.DTO;

namespace Fatec.Treinamento.Data.Repositories
{
    public class CapituloRepository : RepositoryBase, ICapituloRepository
    {
        public Capitulo Atualizar(Capitulo capitulo)
        {
            Connection.Execute(
               @"UPDATE Capitulo SET 
                    Nome = @Nome,
                    IdCurso = @IdCurso,
                    Pontos = @Pontos
                WHERE Id = @Id",
               param: new
               {
                   capitulo.Nome,
                   capitulo.Id,
                   capitulo.IdCurso,
                   capitulo.Pontos
               }
            );

            return capitulo;
        }

        public void Excluir(Capitulo capitulo)
        {

            Connection.Execute(
                "DELETE FROM Capitulo WHERE Id = @Id",
                param: new { Id = capitulo.Id }
            );

        }

        public Capitulo Inserir(Capitulo capitulo)
        {
            var id = Connection.ExecuteScalar<int>(
                @"INSERT INTO Capitulo (Nome, IdCurso, Pontos) 
                 VALUES (@Nome, @IdCurso, @Pontos); 
               SELECT SCOPE_IDENTITY()",
                param: new
                {
                    capitulo.Nome,
                    capitulo.IdCurso,
                    capitulo.Pontos
                }
            );

            capitulo.Id = id;
            return capitulo;
        }

        public IEnumerable<Capitulo> Listar()
        {
            return Connection.Query<Capitulo>(
               @"SELECT Id, Nome, Pontos,IdCurso FROM capitulo
                ORDER BY Nome ASC"
             ).ToList();
        }

        public Capitulo Obter(int id)
        {
            return Connection.Query<Capitulo>(
               "SELECT Id,Nome,Pontos, IdCurso FROM Capitulo WHERE Id = @id",
               param: new { Id = id }
           ).FirstOrDefault();
        }




        public IEnumerable<CapituloPorCurso> ListarTotalCapituloPorCurso(int id)
        {
            return Connection.Query<CapituloPorCurso>(
              @"Select cap.Nome, cap.Pontos, cap.Id
                FROM curso c INNER JOIN Capitulo cap on c.Id = cap.IdCurso
                WHERE c.Id = @id
                
                ORDER BY cap.Nome", new { Id = id }
            ).ToList();
        }


        public Capitulo Criar(Capitulo capitulo)
        {
            Connection.Execute(
               @"INSERT INTO Capitulo (Nome, idCurso, Pontos) 
                 VALUES (@Nome, @idCurso, @Pontos); 
               SELECT SCOPE_IDENTITY()",
               param: new
               {
                   capitulo.Nome,
                   capitulo.IdCurso,
                   capitulo.Pontos,

               }
           );

            return capitulo;
        }
    }
}
