﻿using LocadoraDeVeiculos.Dominio.ParceiroModule;
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
            Serilog.Log.Information($"Inserindo Parceiro [{registro.Nome}]");

            Serilog.Log.Debug($"SQL inserir parceiro: {sqlInserirParceiro}");
            registro.Id = Db.Insert(sqlInserirParceiro, ObtemParametrosParceiro(registro));
            return registro.Id != 0;
        }

        public override bool Editar(int id, Parceiro registro)
        {
            try
            {
                Serilog.Log.Information($"Editando Parceiro [{registro.Nome}]:{id}");

                Serilog.Log.Debug($"SQL editar parceiro: {sqlEditarParceiro}");

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
                Serilog.Log.Information($"Excluindo Parceiro {id}");

                Serilog.Log.Debug($"SQL excluir parceiro: {sqlExcluirParceiro}");
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
            Serilog.Log.Information($"Selecionando Parceiro por id: {id}");

            Serilog.Log.Debug($"SQL Selecionar parceiro por id: {sqlSelecionarParceiroPorId}");
            return Db.Get(sqlSelecionarParceiroPorId, ConverterEmParceiro, AdicionarParametro("ID", id));
        }

        public override List<Parceiro> SelecionarTodos()
        {
            Serilog.Log.Information($"Selecionando Parceiro todos os parceiros");

            Serilog.Log.Debug($"SQL Selecionar todos os parceiros: {sqlSelecionarTodosParceiros}");
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
