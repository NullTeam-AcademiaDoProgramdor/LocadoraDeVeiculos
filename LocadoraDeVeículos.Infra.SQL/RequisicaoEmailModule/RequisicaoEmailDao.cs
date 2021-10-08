using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Infra.SQL.RequisicaoEmailModule
{
    public class RequisicaoEmailDao : IRepositorRequisicaoEmail
    {

        #region queries
        private readonly string sqlInserirEmail =
            @"INSERT INTO [RequisicaoEmail]
                (
                    [mensagem],
                    [emailDestino],
                    [nomePdf]
                )
            VALUES
                (
                    @mensagem,
                    @emailDestino,
                    @nomePdf
                );";

        private readonly string sqlExisteEmail =
            @"SELECT 
                COUNT(*) 
            FROM 
                [RequisicaoEmail]";

        private readonly string sqlSelecionarTodosEmail =
            @"SELECT
	            [Id],
	            [mensagem],
	            [emailDestino],
	            [nomePdf]
            FROM
	            [RequisicaoEmail];";

        private readonly string sqlExcluirEmail =
            @"DELETE FROM [RequisicaoEmail] 
                WHERE [ID] = @ID";

        #endregion


        public bool Excluir(int id)
        {
            try
            {
                Dictionary<string, object> parametro
                    = new Dictionary<string, object>()
                    {
                        {"ID", id }
                    };

                Db.Delete(sqlExcluirEmail, parametro);

            }
            catch (Exception e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }

            return true;
        }

        public bool ExisteAlgum()
        {
            int contagem =
                Db.Insert(sqlExisteEmail, new Dictionary<string, object>());

            return contagem != 0;
        }

        public bool InserirNovo(RequisicaoEmail registro)
        {
            registro.Id = Db.Insert(sqlInserirEmail, ObtemParametros(registro));
            return registro.Id != 0;
        }

        public List<RequisicaoEmail> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosEmail, ConverterEmEmail);
        }

        private Dictionary<string, object> ObtemParametros(RequisicaoEmail email)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("mensagem", email.Mensagem);
            parametros.Add("emailDestino", email.EmailDestino);
            parametros.Add("nomePdf", JuntarNomesPdf(email.Arquivos));

            return parametros;
        }

        private string JuntarNomesPdf(params string[] pdfs)
        {
            StringBuilder saida = new StringBuilder();

            for (int i = 0; i < pdfs.Length; i++)
            {
                saida.Append(pdfs[i]);

                if (i != pdfs.Length - 1)
                    saida.Append("#");
            }

            return saida.ToString();
        }

        private string[] SeperarNomesPdf(string arquivos)
        {
            return arquivos.Split('#');
        }

        private RequisicaoEmail ConverterEmEmail(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["id"]);
            string mensagem = Convert.ToString(reader["mensagem"]);
            string emailDestino = Convert.ToString(reader["emailDestino"]);
            string[] arquivos = SeperarNomesPdf(Convert.ToString(reader["nomePdf"]));

            RequisicaoEmail email
                = new RequisicaoEmail(mensagem, emailDestino, arquivos);

            email.id = id;

            return email;
        }
    }
}
