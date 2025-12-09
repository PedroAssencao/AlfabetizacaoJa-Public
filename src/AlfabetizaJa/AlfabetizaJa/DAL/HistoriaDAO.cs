using AlfabetizaJa.Models;
using Dapper;
using System.Data.SqlClient;

namespace AlfabetizaJa.DAL
{
    public class HistoriaDAO
    {
        private SqlConnection _conexao;

        public HistoriaDAO()
        {
            _conexao = ConexaoBD.getConexao();
        }

        public List<Historia> getTodasHistorias() {

            var sql = "select * from Historia";
            var dados = (List<Historia>)_conexao.Query<Historia>(sql);
            return dados;

        }

		public bool InserirHistoria(Historia historia)
		{
			try
			{
				string sql = "insert Historia (hist_Autor, hist_Titulo, Hist_trecho, hist_img) values (@hist_Autor, @hist_Titulo,@Hist_trecho,@hist_img)";

				int qtdInserida = _conexao.Execute(sql, historia);

				return qtdInserida > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

        public void ApagarHistoria(Historia delete)
        {
            string querry = "Delete from Historia WHERE hist_id = @hist_id; ";
            var qtdAtualizada = _conexao.Execute(querry, delete);
        }

        public void AtualizarQuarto(Historia atualizar)
        {
            string queery = "UPDATE Historia SET hist_Autor = @hist_Autor, hist_Titulo = @hist_Titulo, Hist_trecho = @Hist_trecho, hist_img = @hist_img  WHERE hist_id = @hist_id;";
            var qtdAtualizada = _conexao.Execute(queery, atualizar);
        }


    }
}
