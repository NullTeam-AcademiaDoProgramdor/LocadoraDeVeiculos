using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LocadoraDeVeículos.Infra.SQL.TaxasEServicosModule
{
    public class TaxasEServicosDao : SQLDAOBase, IRepositorBase<TaxaEServico>
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

        public bool InserirNovo(TaxaEServico taxaOuServico)
        {
            Serilog.Log.Logger.Aqui().Information($"Inserindo Taxa ou Serviço [{taxaOuServico.Nome}]");

            Serilog.Log.Debug($"SQL inserir Taxa ou Serviço: {sqlInserirTaxaEServico}");

            taxaOuServico.Id = Db.Insert(sqlInserirTaxaEServico, ObtemParametrosTaxaEServico(taxaOuServico));
            return taxaOuServico.Id != 0;
        }

        public bool Editar(int id, TaxaEServico taxaOuServico)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Editando Taxa ou Serviço [{taxaOuServico.Nome}]:{id}");

                Serilog.Log.Debug($"SQL editar Taxa ou Serviço: {sqlEditarTaxaEServico}");

                taxaOuServico.Id = id;
                Db.Update(sqlEditarTaxaEServico, ObtemParametrosTaxaEServico(taxaOuServico));
                return true;
            }
            catch (Exception e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Excluindo Taxa ou Serviço {id}");

                Serilog.Log.Debug($"SQL excluir Taxa ou Serviço: {sqlExcluirTaxaEServico}");

                Db.Delete(sqlExcluirTaxaEServico, AdicionarParametro("ID", id));
            }
            catch (Exception e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteTaxaEServico, AdicionarParametro("ID", id));
        }        

        public TaxaEServico SelecionarPorId(int id)
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Taxa ou Serviço por id: {id}");

            Serilog.Log.Debug($"SQL Selecionar Taxa ou Serviço por id: {sqlSelecionarTaxaEServicoPorId}");

            return Db.Get(sqlSelecionarTaxaEServicoPorId, ConverterEmTaxaEServico, AdicionarParametro("ID", id));
        }

        public List<TaxaEServico> SelecionarTodos()
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Taxa ou Serviço todas as taxas e serviços");

            Serilog.Log.Debug($"SQL Selecionar todas as Taxa ou Serviço: {sqlSelecionarTodasTaxasEServicos}");

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
