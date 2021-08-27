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
    class ControladorCupom : Controlador<Cupom>
    {
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
                        [PARCEIRO] =@PARCEIRO,
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
                        [ID],
                        [CODIGO],        
                        [PARCEIRO],      
                        [TIPO],          
                        [VALOR],         
                        [VALORMINIMO],  
                        [DATAVENCIMENTO],
                        [QTDUSOS]
                    FROM
                        CUPOM
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosCupons =
            @"SELECT
                        [ID],
                        [CODIGO],        
                        [PARCEIRO],      
                        [TIPO],          
                        [VALOR],         
                        [VALORMINIMO],  
                        [DATAVENCIMENTO],
                        [QTDUSOS]
	                FROM
                        CUPOM";

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
            throw new NotImplementedException();
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public override Cupom SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Cupom> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, object> ObtemParametrosCupom(Cupom cupom)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", cupom.Id);
            parametros.Add("CODIGO", cupom.Codigo);
            parametros.Add("PARCEIRO", cupom.Parceiro);
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
            var parceiro = ((Parceiro)reader["PARCEIRO"]);
            var tipo = Convert.ToString(reader["TIPO"]);
            var valor = Convert.ToDouble(reader["VALOR"]);
            var valorMinimo = Convert.ToDouble(reader["VALORMINIMO"]);
            var dataVencimento = Convert.ToDateTime(reader["DATAVENCIMENTO"]);

            Cupom cupom = new Cupom(codigo, parceiro, tipo, valor, valorMinimo, dataVencimento);

            cupom.Id = id;

            return cupom;
        }

    }
}
