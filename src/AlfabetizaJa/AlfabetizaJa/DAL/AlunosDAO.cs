using AlfabetizaJa.Models;
using Dapper;
using System.Data.SqlClient;

namespace AlfabetizaJa.DAL
{
    public class AlunosDAO
    {
        private SqlConnection _conexao;

        public AlunosDAO()
        {
            _conexao = ConexaoBD.getConexao();
        }

        public List<Alunos> getTodosAlunos(int id)
        {

            
            var sql = $"SELECT * FROM Alunos WHERE log_id = {id}";
            var dados = (List<Alunos>)_conexao.Query<Alunos>(sql);
            return dados;

        }

        public bool Delete(int id)
        {
            try
            {
                string sql = $"DELETE FROM Alunos WHERE log_id = {id}";

                int qtdInserida = _conexao.Execute(sql);

                return qtdInserida > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InserirAlunos(Alunos Alunos)
        {
            try
            {
                string sql = "INSERT INTO Alunos (log_id, nome_aluno, nota) values (@log_id,@nome_aluno,@nota)";
                int qtdInserida = _conexao.Execute(sql, Alunos);

                return qtdInserida > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }





    }
}
