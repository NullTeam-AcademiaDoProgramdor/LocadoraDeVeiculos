﻿using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeículos.Infra.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LocadoraDeVeículos.Infra.SQL.TaxasEServicosModule
{
    public class TaxasEServicosDao : IRepositor<TaxaEServico>
    {

        #region Queries
        private const string sqlInserirTaxaEServico =
            @"INSERT INTO [TAXAESERVICO]
                (
                    [EHFIXO],       
                    [PRECO],             
                    [NOME]     
                )
            VALUES
                (
                   @EHFIXO,
                   @PRECO,
                   @NOME
                 )";

        private const string sqlEditarTaxaEServico =
            @" UPDATE [TAXAESERVICO]
                SET 
                    [EHFIXO] = @EHFIXO, 
                    [PRECO] = @PRECO, 
                    [NOME] =  @NOME                    
                WHERE [ID] = @ID";

        private const string sqlExcluirTaxaEServico =
            @"DELETE FROM [TAXAESERVICO] 
                WHERE [ID] = @ID;";

        private const string sqlSelecionarTodasTaxasEServicos =
            @"SELECT 
                [ID],
                [EHFIXO],       
                [PRECO],             
                [NOME]
              FROM
                [TAXAESERVICO]";

        private const string sqlSelecionarTaxaEServicoPorNome =
            @"SELECT 
                [ID],
                [EHFIXO],       
                [PRECO],             
                [NOME]
             FROM
                [TAXAESERVICO]
             WHERE 
                [NOME] = @NOME";

        private const string sqlSelecionarTaxaEServicoPorId =
            @"SELECT 
                [ID],
                [EHFIXO],       
                [PRECO],             
                [NOME]
             FROM
                [TAXAESERVICO]
             WHERE 
                [ID] = @ID";

        private const string sqlExisteTaxaEServico =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TAXAESERVICO]
            WHERE 
                [ID] = @ID";



        #endregion

        public override bool InserirNovo(TaxaEServico taxaOuServico)
        {
            taxaOuServico.Id = Db.Insert(sqlInserirTaxaEServico, ObtemParametrosTaxaEServico(taxaOuServico));
            return taxaOuServico.Id != 0;
        }

        public override bool Editar(int id, TaxaEServico taxaOuServico)
        {
            try
            {
                taxaOuServico.Id = id;
                Db.Update(sqlEditarTaxaEServico, ObtemParametrosTaxaEServico(taxaOuServico));
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
                Db.Delete(sqlExcluirTaxaEServico, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteTaxaEServico, AdicionarParametro("ID", id));
        }        

        public override TaxaEServico SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarTaxaEServicoPorId, ConverterEmTaxaEServico, AdicionarParametro("ID", id));
        }

        public override List<TaxaEServico> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodasTaxasEServicos, ConverterEmTaxaEServico);
        }

        public TaxaEServico SelecionarPorNome(string nome)
        {
            return Db.Get(sqlSelecionarTaxaEServicoPorNome, ConverterEmTaxaEServico, AdicionarParametro("NOME", nome));
        }

        private TaxaEServico ConverterEmTaxaEServico(IDataReader reader)
        {
            var nome = Convert.ToString(reader["NOME"]);
            var preco = Convert.ToDouble(reader["PRECO"]);
            var ehFixo = Convert.ToBoolean(reader["EHFIXO"]);

            TaxaEServico taxaOuServicos = new TaxaEServico(nome, preco, ehFixo);

            taxaOuServicos.Id = Convert.ToInt32(reader["ID"]);

            return taxaOuServicos;
        }

        private Dictionary<string, object> ObtemParametrosTaxaEServico(TaxaEServico taxaOuServico)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", taxaOuServico.Id);
            parametros.Add("NOME", taxaOuServico.Nome);
            parametros.Add("PRECO", taxaOuServico.Preco);
            parametros.Add("EHFIXO", taxaOuServico.EhFixo);

            return parametros;
        }
    }
}
