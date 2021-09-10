using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Controladores.CupomModule
{
    public class ControladorCupom : Controlador<Cupom>
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

        public override string InserirNovo(Cupom cupom)
        {
            string resultadoValidacao = cupom.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                cupom.Id = Db.Insert(sqlInserirCupom, ObtemParametrosCupom(cupom));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, Cupom cupom)
        {
            string resultadoValidacao = cupom.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                cupom.Id = id;
                Db.Update(sqlEditarCupom, ObtemParametrosCupom(cupom));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirCupom, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteCupom, AdicionarParametro("ID", id));
        }

        public void EditarQtdUsos(Cupom cupom)
        {
            cupom.QtdUsos++;
            Editar(cupom.Id, cupom);
        }

        public override Cupom SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarCupomPorId, ConverterEmCupom, AdicionarParametro("ID", id));
        }

        public Cupom SelecionarPorCodigo(string codigo)
        {
            return Db.Get(sqlSelecionarCupomPorCodigo, ConverterEmCupom, AdicionarParametro("CODIGO", codigo));
        }

        public List<Cupom> SelecionarValidos()
        {
            return Db.GetAll(sqlSelecionarCuponsAindaValidos, ConverterEmCupom, AdicionarParametro("DATADEHOJE", DateTime.Today));

        }

        public override List<Cupom> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosCupons, ConverterEmCupom);
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