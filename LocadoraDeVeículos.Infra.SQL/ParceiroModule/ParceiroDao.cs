using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeículos.Infra.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Infra.SQL.ParceiroModule
{
    public class ParceiroDao : RepositorBase<Parceiro>
    {
        #region Queries
        private const string sqlInserirParceiro =
            @"INSERT INTO [PARCEIRO]
                (       
                    [NOME]
                )
            VALUES
                (
                    @NOME
                )";

        private const string sqlEditarParceiro =
            @" UPDATE [PARCEIRO]
                SET 
                    [NOME] = @NOME
                WHERE [ID] = @ID";

        private const string sqlExcluirParceiro =
            @"DELETE FROM [PARCEIRO] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarParceiroPorId =
            @"SELECT
                        [ID],
		                [NOME]
	                FROM
                        PARCEIRO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosParceiros =
            @"SELECT
                        [ID],
		                [NOME]
	                FROM
                        PARCEIRO";

        private const string sqlExisteParceiro =
            @"SELECT 
                COUNT(*) 
            FROM 
                [PARCEIRO]
            WHERE 
                [ID] = @ID";

        #endregion

        public override bool InserirNovo(Parceiro registro)
        {
            Log.log.Info($"Inserindo Parceiro [{registro.Nome}]");

            Log.log.Debug($"SQL inserir parceiro: {sqlInserirParceiro}");
            registro.Id = Db.Insert(sqlInserirParceiro, ObtemParametrosParceiro(registro));
            return registro.Id != 0;
        }

        public override bool Editar(int id, Parceiro registro)
        {
            try
            {
                Log.log.Info($"Editando Parceiro [{registro.Nome}]:{id}");

                Log.log.Debug($"SQL editar parceiro: {sqlEditarParceiro}");

                registro.Id = id;
                Db.Update(sqlEditarParceiro, ObtemParametrosParceiro(registro));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Excluir(int id)
        {
            try
            {
                Log.log.Info($"Excluindo Parceiro {id}");

                Log.log.Debug($"SQL excluir parceiro: {sqlExcluirParceiro}");
                Db.Delete(sqlExcluirParceiro, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteParceiro, AdicionarParametro("ID", id));
        }


        public override Parceiro SelecionarPorId(int id)
        {
            Log.log.Info($"Selecionando Parceiro por id: {id}");

            Log.log.Debug($"SQL Selecionar parceiro por id: {sqlSelecionarParceiroPorId}");
            return Db.Get(sqlSelecionarParceiroPorId, ConverterEmParceiro, AdicionarParametro("ID", id));
        }

        public override List<Parceiro> SelecionarTodos()
        {
            Log.log.Info($"Selecionando Parceiro todos os parceiros");

            Log.log.Debug($"SQL Selecionar todos os parceiros: {sqlSelecionarTodosParceiros}");
            return Db.GetAll(sqlSelecionarTodosParceiros, ConverterEmParceiro);
        }

        private Dictionary<string, object> ObtemParametrosParceiro(Parceiro registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro.Id);
            parametros.Add("NOME", registro.Nome);

            return parametros;
        }

        private Parceiro ConverterEmParceiro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);

            Parceiro parceiro = new Parceiro(nome);

            parceiro.Id = id;

            return parceiro;
        }
    }
}
