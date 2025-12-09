using System.Data.SqlClient;

namespace AlfabetizaJa.DAL
{
    public class ConexaoBD
    {
        private static SqlConnection banco;

        public static SqlConnection getConexao()
        {
            if (banco == null)
            {
                banco = new SqlConnection("");
            }

            return banco;
        }
    }
}
