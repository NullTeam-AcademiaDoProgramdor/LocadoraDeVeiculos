using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeículos.Infra.SQL.CupomModule;
using LocadoraDeVeículos.Infra.SQL.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.LocacaoModule
{
    public class LocacaoAppService : ICadastravel<Locacao>
    {
        LocacaoDao repositorioLocacao = null;
        TaxasEServicosUsadosDao repositorioTaxas = null;
        CupomDao repositorioCupom = null;

        public LocacaoAppService(LocacaoDao locacaoDao)
        {
            repositorioLocacao = locacaoDao;
            repositorioTaxas = new();
            repositorioCupom = new();
        }

        public string InserirNovo(Locacao registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorioLocacao.InserirNovo(registro);

                repositorioTaxas.Modificar(registro.TaxasEServicos, registro.id);
            }

            return resultadoValidacao;
        }

        public string Devolver(int id, Locacao locacao, bool cupomFoiUsado)
        {
            string resultadoValidacao = locacao.ValidarDevolucao();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                if (locacao.Cupom != null && cupomFoiUsado)
                    repositorioCupom.EditarQtdUsos(locacao.Cupom);

                repositorioLocacao.Devolver(id, locacao);
            }

            return resultadoValidacao;
        }

        public string Editar(int id, Locacao locacao)
        {
            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorioLocacao.Editar(id, locacao);

                repositorioTaxas.Modificar(locacao.TaxasEServicos, locacao.id);
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            return repositorioLocacao.Excluir(id);
        }

        public bool Existe(int id)
        {
            return repositorioLocacao.Existe(id);
        }

        public Locacao SelecionarPorId(int id)
        {
            return repositorioLocacao.SelecionarPorId(id);
        }

        public List<Locacao> SelecionarTodos()
        {
            return repositorioLocacao.SelecionarTodos();
        }

        public string EditarKmRegistrada(Locacao locacao)
        {
            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorioLocacao.EditarKmRegistrada(locacao);
            }

            return resultadoValidacao;
        }

    }
}
