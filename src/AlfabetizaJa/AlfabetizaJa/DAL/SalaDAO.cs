using AlfabetizaJa.Models;
using Dapper;
using System.Data.SqlClient;

namespace AlfabetizaJa.DAL
{
    public class SalaDAO
    {
        private SqlConnection _conexao;

        public SalaDAO()
        {
            _conexao = ConexaoBD.getConexao();
        }

        public List<Salas> getTodasSalas()
        {
            var sql = "select * from Salas";
            var dados = (List<Salas>)_conexao.Query<Salas>(sql);
            return dados;

        }
        public bool InserirSala(Salas Salas)
        {
            try
            {
                string sql = "insert Salas (log_id, sala_url, sala_aberta) values (@log_id, @sala_url,@sala_aberta)";

                int qtdInserida = _conexao.Execute(sql, Salas);

                return qtdInserida > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool update(Salas Salas)
        {
            try
            {
                string sql = "UPDATE Salas SET sala_aberta = 0 WHERE log_id = @log_id";

                int qtdInserida = _conexao.Execute(sql, Salas);

                return qtdInserida > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

    


        public int SalaAberta(int id)
        {
            var sql = $"SELECT sala_aberta FROM salas WHERE log_id = {id} ORDER BY sala_id DESC";
            var salaAberta = _conexao.ExecuteScalar<int>(sql);
            return salaAberta;
        }

        public int SalaUrl(int id)
        {
            var sql = $"SELECT sala_url FROM salas WHERE log_id = {id} ORDER BY sala_id DESC";
            var salaAberta = _conexao.ExecuteScalar<int>(sql);
            return salaAberta;
        }



    }
}
