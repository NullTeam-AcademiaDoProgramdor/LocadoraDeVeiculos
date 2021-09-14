using LocadoraDeVeículos.Aplicacao.AutomovelModule;
using LocadoraDeVeículos.Aplicacao.CupomModule;
using LocadoraDeVeículos.Aplicacao.FuncionarioModule;
using LocadoraDeVeículos.Aplicacao.PessoaFisicaModule;
using LocadoraDeVeículos.Aplicacao.TaxaEServicoModule;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Infra.SQL.LocacaoModule
{
    public class LocacaoDao : RepositorLocacaoBase
    {
        PessoaFisicaAppService controladorPessoaFisica = null;
        AutomovelAppService controladorAutomovel = null;
        FuncionarioAppService controladorFuncionario = null;
        CupomAppService controladorCupom = null;
        TaxaEServicoAppService controladorTaxas = null;

        public LocacaoDao()
        {

        }

        public override bool InserirNovo(Locacao registro)
        {
            throw new NotImplementedException();
        }

        public override bool Devolver(int id, Locacao locacao, bool cupomFoiUsado)
        {
            throw new NotImplementedException();
        }

        public override bool Editar(int id, Locacao registro)
        {
            throw new NotImplementedException();
        }

        public override bool EditarKmRegistrada(Locacao locacao)
        {
            throw new NotImplementedException();
        }

        public override bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public override Locacao SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Locacao> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        private Locacao ConverterEmLocacao(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var condutor = controladorPessoaFisica.SelecionarPorId((int)reader["CONDUTOR"]);
            var automovel = controladorAutomovel.SelecionarPorId((int)reader["AUTOMOVEL"]);
            var funcionario = controladorFuncionario.SelecionarPorId((int)reader["FUNCIONARIO"]);
            var dataSaida = Convert.ToDateTime(reader["DATASAIDA"]);
            var dataDevolucaoEsperada = Convert.ToDateTime(reader["DATADEVOLUCAOESPERADA"]);
            var caucao = Convert.ToInt32(reader["CAUCAO"]);
            var planoSelecionado = Convert.ToInt32(reader["PLANOSELECIONADO"]);
            var kmInicial = Convert.ToInt32(reader["KMREGISTRADA"]);

            Locacao locacao;
            if (reader["DATADEVOLUCAO"] == DBNull.Value)
                locacao = new Locacao(condutor, automovel, funcionario, dataSaida, dataDevolucaoEsperada, caucao, planoSelecionado);

            else
            {
                var dataDevolucao = Convert.ToDateTime(reader["DATADEVOLUCAO"]);
                var kmFinal = Convert.ToInt32(reader["KMAUTOMOVELFINAL"]);
                var combustivelFinal = Convert.ToInt32(reader["PORCENTAGEMFINALCOMBUSTIVEL"]);

                locacao = new Locacao(condutor, automovel, funcionario
                , dataSaida, dataDevolucaoEsperada, caucao, kmInicial, planoSelecionado, kmFinal, combustivelFinal, dataDevolucao);
            }

            Cupom cupom;
            if (reader["CUPOM"] == DBNull.Value)
                cupom = null;
            else
                cupom = controladorCupom.SelecionarPorId(
                    Convert.ToInt32(reader["CUPOM"])
                );

            locacao.Id = id;
            locacao.Cupom = cupom;
            //locacao.TaxasEServicos = controladorTaxas.Buscar(locacao.id).ToArray();

            return locacao;
        }

        private Dictionary<string, object> ObtemParametrosLocacao(Locacao locacao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", locacao.Id);
            parametros.Add("CONDUTOR", locacao.Condutor.id);
            parametros.Add("AUTOMOVEL", locacao.Automovel.id);
            parametros.Add("DATASAIDA", locacao.DataSaida);
            parametros.Add("DATADEVOLUCAOESPERADA", locacao.DataDevolucaoEsperada);
            parametros.Add("DATADEVOLUCAO", locacao.DataDevolucao);
            parametros.Add("CAUCAO", locacao.Caucao);
            parametros.Add("PLANOSELECIONADO", locacao.PlanoSelecionado);
            parametros.Add("FUNCIONARIO", locacao.Funcionario.id);
            parametros.Add("KMREGISTRADA", locacao.KmAutomovelIncial);
            parametros.Add("KMAUTOMOVELFINAL", locacao.KmAutomovelFinal);
            parametros.Add("PORCENTAGEMFINALCOMBUSTIVEL", locacao.PorcentagemFinalCombustivel);

            if (locacao.Cupom == null)
                parametros.Add("CUPOM", null);
            else
                parametros.Add("CUPOM", locacao.Cupom.id);


            return parametros;
        }
    }
}
