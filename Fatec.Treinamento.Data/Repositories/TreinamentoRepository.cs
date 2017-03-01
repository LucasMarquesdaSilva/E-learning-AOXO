using Fatec.Treinamento.Data.Repositories.Base;
using Fatec.Treinamento.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fatec.Treinamento.Model;
using Dapper;

namespace Fatec.Treinamento.Data.Repositories
{
    public class TreinamentoRepository : RepositoryBase, ITreinamentoRepository
    {
        public Treino Atualizar(Treino treino)
        {
            Connection.Execute(
              @"UPDATE Capitulo SET 
                    Nome = @Nome,
                    IdCurso = @IdCurso,
                    Pontos = @Pontos
                WHERE Id = @Id",
              param: new
              {
                  treino.idCurso,
                  treino.idUsuario,
                  treino.DataInicio,
                  treino.UltimoAcesso,
                  treino.DataConclusao
                  
              }
           );

            return treino;
        }

        public void Excluir(Treino treino)
        {
            Connection.Execute(
                   "DELETE FROM Capitulo WHERE Id = @Id",
                   param: new { Id = treino.idCurso }
               );
        }

        public Treino Inserir(Treino treino)
        {
            Connection.Execute(
              @"INSERT INTO Treinamento(IdUsuario, IdCurso, DataInicio, UltimoAcesso,DataConclusao) 
				values(@idUsuario,@idCurso,GETDATE(),GETDATE(), null));",
              param: new
              {
                  treino.idUsuario,
                  treino.idCurso,
                  treino.DataInicio,
                  treino.UltimoAcesso,
                  treino.DataConclusao
              }
          );

            return treino;

        }

        public IEnumerable<Treino> Listar()
        {
            return Connection.Query<Treino>(
              "SELECT Id, Nome FROM Perfil"
            ).ToList();
        }

        public Treino Obter(int id)
        {

            return Connection.Query<Treino>(
                   "SELECT Id, Nome FROM Perfil WHERE Id = @Id",
                   param: new { Id = id }
               ).FirstOrDefault();
        }
    }
}
