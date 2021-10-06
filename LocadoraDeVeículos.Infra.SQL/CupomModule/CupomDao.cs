using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Infra.SQL.CupomModule
{
    public class CupomDao : SQLDAOBase, IRepositorCupomBase
    {
        #region Queries
        private const string sqlInserirCupom =
            @"INSERT INTO CUPOM 
	                (         
                        [CODIGO],        
                        [PARCEIRO],      
                        [TIPO],          
                        [VALOR],         
                        [VALORMINIMO],  
                        [DATAVENCIMENTO],
                        [QTDUSOS]
	                ) 
	                VALUES
	                (
                        @CODIGO, 
                        @PARCEIRO,
                        @TIPO,
                        @VALOR,
                        @VALORMINIMO,
                        @DATAVENCIMENTO,
		                @QTDUSOS
	                )";

        private const string sqlEditarCupom =
            @"UPDATE Cupom
                    SET
                        [CODIGO] = @CODIGO, 
                        [PARCEIRO] = @PARCEIRO,
                        [TIPO] = @TIPO,
                        [VALOR] = @VALOR,
                        [VALORMINIMO] = @VALORMINIMO,
                        [DATAVENCIMENTO] = @DATAVENCIMENTO,
                        [QTDUSOS] = @QTDUSOS
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirCupom =
            @"DELETE 
                    FROM 
                        CUPOM
                    WHERE
                        ID = @ID";

        private const string sqlExisteCupom =
            @"SELECT 
                COUNT(*) 
            FROM 
                [CUPOM]
            WHERE 
                [ID] = @ID";

        private const string sqlSelecionarCupomPorId =
            @"SELECT
                        C.ID,
                        C.CODIGO,        
                        C.PARCEIRO,      
                        C.TIPO,          
                        C.VALOR,         
                        C.VALORMINIMO,  
                        C.DATAVENCIMENTO,
                        C.QTDUSOS,
                        P.NOME
                    FROM
	                    [CUPOM] as C LEFT JOIN
	                    [PARCEIRO] AS P
                    ON
	                    P.ID = C.PARCEIRO
                    WHERE 
                        C.ID = @ID";

        private const string sqlSelecionarCupomPorCodigo =
            @"SELECT
                        C.ID,
                        C.CODIGO,        
                        C.PARCEIRO,      
                        C.TIPO,          
                        C.VALOR,         
                        C.VALORMINIMO,  
                        C.DATAVENCIMENTO,
                        C.QTDUSOS,
                        P.NOME
                     FROM
	                    [CUPOM] as C LEFT JOIN
	                    [PARCEIRO] AS P
                    ON
	                    P.ID = C.PARCEIRO
                    WHERE 
                        CODIGO = @CODIGO";

        private const string sqlSelecionarCuponsAindaValidos =
            @"SELECT
                        C.ID,
                        C.CODIGO,        
                        C.PARCEIRO,      
                        C.TIPO,          
                        C.VALOR,         
                        C.VALORMINIMO,  
                        C.DATAVENCIMENTO,
                        C.QTDUSOS,
                        P.NOME
                     FROM
	                    [CUPOM] as C LEFT JOIN
	                    [PARCEIRO] AS P
                    ON
	                    P.ID = C.PARCEIRO
                    WHERE 
                        DATAVENCIMENTO >= @DATADEHOJE";

        private const string sqlSelecionarTodosCupons =
            @"SELECT
                        C.ID,
                        C.CODIGO,        
                        C.PARCEIRO,      
                        C.TIPO,          
                        C.VALOR,         
                        C.VALORMINIMO,  
                        C.DATAVENCIMENTO,
                        C.QTDUSOS,
                        P.NOME
	                FROM
	                    [CUPOM] as C LEFT JOIN
	                    [PARCEIRO] AS P
                    ON
	                    P.ID = C.PARCEIRO;";
        #endregion

        public  bool Editar(int id, Cupom registro)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Editando Cupom [{registro.Codigo}]:{id}");

                Serilog.Log.Debug($"SQL editar cupom: {sqlEditarCupom}");

                registro.Id = id;
                Db.Update(sqlEditarCupom, ObtemParametrosCupom(registro));
                return true;
            } 
            catch (Exception e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }
        }

        public  bool EditarQtdUsos(Cupom cupom)
        {
            Serilog.Log.Logger.Aqui().Information($"Editando a quantidade de usos do cupom [{cupom.Codigo}]");

            cupom.QtdUsos++;
            return Editar(cupom.Id, cupom);
        }

        public  bool Excluir(int id)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Excluindo Cupom {id}");

                Serilog.Log.Debug($"SQL excluir cupom: {sqlExcluirCupom}");

                Db.Delete(sqlExcluirCupom, AdicionarParametro("ID", id));
            }
            catch (Exception e )
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }

            return true;
        }

        public  bool Existe(int id)
        {
            return Db.Exists(sqlExisteCupom, AdicionarParametro("ID", id));
        }

        public  bool InserirNovo(Cupom registro)
        {
            Serilog.Log.Logger.Aqui().Information($"Inserindo Cupom [{registro.Codigo}]");

            Serilog.Log.Debug($"SQL inserir cupom: {sqlInserirCupom}");

            registro.Id = Db.Insert(sqlInserirCupom, ObtemParametrosCupom(registro));
            return registro.id != 0;
        }

        public  Cupom SelecionarPorId(int id)
        {

            Serilog.Log.Logger.Aqui().Information($"Selecionando Cupom por id: {id}");

            Serilog.Log.Debug($"SQL Selecionar cupom por id: {sqlSelecionarCupomPorId}");

            return Db.Get(sqlSelecionarCupomPorId, ConverterEmCupom, AdicionarParametro("ID", id));
        }

        public  List<Cupom> SelecionarTodos()
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Cupom todos os cupons");

            Serilog.Log.Debug($"SQL Selecionar todos os cupons: {sqlSelecionarTodosCupons}");

            return Db.GetAll(sqlSelecionarTodosCupons, ConverterEmCupom);
        }

        public  Cupom SelecionarPorCodigo(string codigo)
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Cupom por codigo: {codigo}");

            Serilog.Log.Debug($"SQL Selecionar cupom por codigo: {sqlSelecionarCupomPorCodigo}");

            return Db.Get(sqlSelecionarCupomPorCodigo, ConverterEmCupom, AdicionarParametro("CODIGO", codigo));
        }

        public  List<Cupom> SelecionarValidos()
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Cupons validos");

            Serilog.Log.Debug($"SQL Selecionar cupons validos: {sqlSelecionarCuponsAindaValidos}");

            return Db.GetAll(sqlSelecionarCuponsAindaValidos, ConverterEmCupom, AdicionarParametro("DATADEHOJE", DateTime.Today));
        }

        private Dictionary<string, object> ObtemParametrosCupom(Cupom cupom)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", cupom.Id);
            parametros.Add("CODIGO", cupom.Codigo);
            parametros.Add("PARCEIRO", cupom.Parceiro.Id);
            parametros.Add("TIPO", cupom.Tipo);
            parametros.Add("VALOR", cupom.Valor);
            parametros.Add("VALORMINIMO", cupom.ValorMinimo);
            parametros.Add("DATAVENCIMENTO", cupom.DataVencimento);
            parametros.Add("QTDUSOS", cupom.QtdUsos);

            return parametros;
        }

        private Cupom ConverterEmCupom(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var codigo = Convert.ToString(reader["CODIGO"]);

            var tipo = Convert.ToString(reader["TIPO"]);
            var valor = Convert.ToDouble(reader["VALOR"]);
            var valorMinimo = Convert.ToDouble(reader["VALORMINIMO"]);
            var dataVencimento = Convert.ToDateTime(reader["DATAVENCIMENTO"]);
            var qtdUsos = Convert.ToInt32(reader["QTDUSOS"]);
            var parceiro_Id = Convert.ToInt32(reader["PARCEIRO"]);

            var nome = Convert.ToString(reader["NOME"]);

            Parceiro parceiro = new Parceiro(nome)
            {
                Id = parceiro_Id
            };
            Cupom cupom = new Cupom(codigo, parceiro, tipo, valor, valorMinimo, dataVencimento, qtdUsos);

            cupom.Id = id;

            return cupom;
        }

        
    }
}
