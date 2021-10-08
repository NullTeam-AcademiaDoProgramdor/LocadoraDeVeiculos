using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Controladores.TaxasEServicosModule;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Controladores.LocacaoModule
{
    public class ControladorTaxasEServicosUsados
    {

        #region QUERIES
        private readonly string sqlInserirTaxaEServicoUsado =
            @"INSERT INTO [TaxasEServicosUsadas]
                (
	                [locacao],
	                [taxaEServico]
                )
                VALUES
                (
	                @locacao,
	                @taxaEServico
                );";

        private readonly string sqlExcluirTaxaEServicoUsado =
            @"DELETE FROM [TaxasEServicosUsadas]
                WHERE [Id] = @id;";

        private readonly string sqlSelecionarTodosUsados =
            @"SELECT
                [id],
                [taxaEServico],
                [locacao]
            FROM
                [TaxasEServicosUsadas]
            WHERE
                [locacao] = @locacao";
        #endregion

        private ControladorTaxasEServicos controladorTaxas
            = new ControladorTaxasEServicos();

        private class TaxaEServicoUsado
        {
            public int id;
            public TaxaEServico taxaEServico;
            public int locacao;

            public TaxaEServicoUsado(int id, TaxaEServico taxaEServico, int locacao)
            {
                this.id = id;
                this.taxaEServico = taxaEServico;
                this.locacao = locacao;
            }
        }

        private void InserirTaxaEServicosUsados(List<TaxaEServico> taxasEServicos, int locacaoId)
        {
            foreach (var taxaEServico in taxasEServicos)
            {
                Db.Insert(sqlInserirTaxaEServicoUsado, ObterParametros(taxaEServico, locacaoId));
            }
        }

        private bool ExcluirTaxaEServicoUsado(int taxaEServicoUsadoId)
        {
            try
            {
                var parametro = new Dictionary<string, object>()
                {
                    {"id", taxaEServicoUsadoId }
                };

                Db.Delete(sqlExcluirTaxaEServicoUsado, parametro);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private List<TaxaEServicoUsado> BuscarUsados(int locacaoId)
        {
            var parametro = new Dictionary<string, object>()
                {
                    {"locacao", locacaoId }
                };
            return Db.GetAll(sqlSelecionarTodosUsados, ConverterParaTaxaEServicoUsado, parametro);
        }

        public TaxaEServico[] Buscar(int locacaoId)
        {
            var taxas = this.BuscarUsados(locacaoId);

            return taxas.Select(t => t.taxaEServico).ToArray();
        }

        public void Modificar(List<TaxaEServico> taxasEServicos, int locacaoId)
        {
            List<TaxaEServicoUsado> taxasEmServidoDoDb = this.BuscarUsados(locacaoId);

            Dictionary<TaxaEServicoUsado, char> tabelaDeAlteracoes = GerarTabelaDeAlteracoes(taxasEServicos, locacaoId, taxasEmServidoDoDb);

            foreach (var alteraco in tabelaDeAlteracoes)
            {
                if (alteraco.Value == 'D')
                    this.ExcluirTaxaEServicoUsado(alteraco.Key.id);
                else if (alteraco.Value == 'A')
                    this.InserirTaxaEServicosUsados(
                        new List<TaxaEServico> { alteraco.Key.taxaEServico },
                        alteraco.Key.locacao);
            }

        }

        private static Dictionary<TaxaEServicoUsado, char> GerarTabelaDeAlteracoes(List<TaxaEServico> taxasEServicos, int locacaoId, List<TaxaEServicoUsado> taxasEmServidoDoDb)
        {
            Dictionary<TaxaEServicoUsado, char> tabelaDeAlteracoes =
                new Dictionary<TaxaEServicoUsado, char>();

            Dictionary<TaxaEServico, TaxaEServicoUsado> hashsTaxas =
                new Dictionary<TaxaEServico, TaxaEServicoUsado>();

            foreach (var taxa in taxasEmServidoDoDb)
            {
                tabelaDeAlteracoes.Add(taxa, 'D');
                hashsTaxas.Add(taxa.taxaEServico, taxa);
            }


            foreach (var taxaNova in taxasEServicos)
            {
                if (hashsTaxas.ContainsKey(taxaNova))
                    tabelaDeAlteracoes[hashsTaxas[taxaNova]] = 'M';
                else
                {
                    TaxaEServicoUsado tempTaxa = new TaxaEServicoUsado(0, taxaNova, locacaoId);
                    tabelaDeAlteracoes.Add(tempTaxa, 'A');
                    hashsTaxas.Add(taxaNova, tempTaxa);
                }
            }

            return tabelaDeAlteracoes;
        }

        private TaxaEServicoUsado ConverterParaTaxaEServicoUsado(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["id"]);

            TaxaEServico taxaEServico =
                controladorTaxas.SelecionarPorId(
                    Convert.ToInt32(reader["taxaEServico"]
                 )
             );

            int locacao = Convert.ToInt32(reader["locacao"]);

            return new TaxaEServicoUsado(id, taxaEServico, locacao);
        }

        private Dictionary<string, object> ObterParametros(TaxaEServico taxaEServico, int locacaoId)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("taxaEServico", taxaEServico.Id);
            parametros.Add("locacao", locacaoId);

            return parametros;
        }
    }
}