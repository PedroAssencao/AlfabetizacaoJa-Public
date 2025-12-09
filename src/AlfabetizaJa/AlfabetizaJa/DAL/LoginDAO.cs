using AlfabetizaJa.Models;
using Dapper;
using System.Data.SqlClient;

namespace AlfabetizaJa.DAL
{
    public class LoginDAO
    {
        private SqlConnection _conexao;

        public LoginDAO()
        {
            _conexao = ConexaoBD.getConexao();
        }

        public List<Login> getTodosLOgins()
        {

            var sql = "select * from Login";
            var dados = (List<Login>)_conexao.Query<Login>(sql);
            return dados;

        }

        public bool InserirConta(Login Login)
        {
            try
            {
                string sql = "insert Login (log_user, log_email, log_senha, log_numeroW) values (@log_user, @log_email,@log_senha,@log_numeroW)";

                int qtdInserida = _conexao.Execute(sql, Login);

                return qtdInserida > 0;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}
