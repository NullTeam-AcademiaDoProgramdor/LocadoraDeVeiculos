using LocadoraDeVeiculos.Controladores.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Controladores.AutomovelModule
{
    internal class ControladorSelecionarIdsAutomoveisDisponiveis
    {
        private const string sqlSelecionarDatasDevolucaoAutomoveis =
            @"SELECT
	            A.id,
	            L.id as locacaoId,
	            L.dataDevolucao
            FROM
	            [Automovel] A LEFT JOIN
	            [Locacao] L
		            ON A.id = L.automovel";

        private class EntidadeAutomovelDataDevolucao
        {
            public int automovelId;
            public int? locacaoId;
            public DateTime? dataDevolucao;

            public EntidadeAutomovelDataDevolucao(int automovelId, int? locacaoId, DateTime? dataDevolucao)
            {
                this.automovelId = automovelId;
                this.locacaoId = locacaoId;
                this.dataDevolucao = dataDevolucao;
            }
        }

        public int[] SelecionarIdsDisponiveis()
        {
            var automoveis = Db.GetAll(sqlSelecionarDatasDevolucaoAutomoveis, ConverterParaEntidade);
            Dictionary<int, bool> tabelaDeFiltragem = new Dictionary<int, bool>();

            foreach (var entidade in automoveis)
            {
                if (entidade.locacaoId == null)
                {
                    tabelaDeFiltragem.Add(entidade.automovelId, true);
                    continue;
                }

                if (entidade.dataDevolucao == null)
                {
                    if (tabelaDeFiltragem.ContainsKey(entidade.automovelId))
                        tabelaDeFiltragem[entidade.automovelId] = false;
                    else
                        tabelaDeFiltragem.Add(entidade.automovelId, false);

                    continue;
                }

                if (!tabelaDeFiltragem.ContainsKey(entidade.automovelId))
                    tabelaDeFiltragem.Add(entidade.automovelId, true);
            }

            return tabelaDeFiltragem
                .Where(e => e.Value == true)
                .Select(e => e.Key)
                .ToArray();
        }

        private EntidadeAutomovelDataDevolucao ConverterParaEntidade(IDataReader reader)
        {
            int automovelId = Convert.ToInt32(reader["id"]);

            int? locacaoId;
            if (reader["locacaoId"] == DBNull.Value)
                locacaoId = null;
            else
                locacaoId = Convert.ToInt32(reader["locacaoId"]);

            DateTime? dataDevolucao;
            if (reader["dataDevolucao"] == DBNull.Value)
                dataDevolucao = null;
            else
                dataDevolucao = Convert.ToDateTime(reader["dataDevolucao"]);

            return new EntidadeAutomovelDataDevolucao(automovelId, locacaoId, dataDevolucao);
        }
    }
}