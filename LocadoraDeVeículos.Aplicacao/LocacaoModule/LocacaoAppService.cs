using LocadoraDeVeículos.Aplicacao.RequisicaoEmailModule;
using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.RelatorioModule;
using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeículos.Infra.PDF.PDFModule;
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
        GeradorPDF repositorioPDF = null;
        IEmailAppService emailAppService = null;

        public LocacaoAppService(LocacaoDao repositorioLocacao,
                                 TaxasEServicosUsadosDao repositorioTaxas,
                                 CupomDao repositorioCupom,
                                 GeradorPDF repositorioPDF,
                                 IEmailAppService emailAppService)
        {
            this.repositorioLocacao = repositorioLocacao;
            this.repositorioTaxas = repositorioTaxas;
            this.repositorioCupom = repositorioCupom;
            this.repositorioPDF = repositorioPDF;
            this.emailAppService = emailAppService;
        }

        public string InserirNovo(Locacao registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando Locação [{registro.Id}], Resultado: {resultadoValidacao}");

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
            Serilog.Log.Logger.Aqui().Information($"Validando Devolução da Locação [{id}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                if (locacao.Cupom != null && cupomFoiUsado)
                    repositorioCupom.EditarQtdUsos(locacao.Cupom);

                repositorioLocacao.Devolver(id, locacao);

                string email = (locacao.Condutor.PessoaJuridica == null) ? locacao.Condutor.Email
                        : locacao.Condutor.PessoaJuridica.Email;

                string pdf = repositorioPDF.GerarPdf(new Relatorio(locacao));
                Serilog.Log.Logger.Aqui().Information($"Enviando locacao [{locacao}] para GeradorPDF");

                emailAppService
                    .AdicionarEmail("Aqui está o relatório de sua locação finalizada.",
                                    email,
                                    pdf);
            }

            return resultadoValidacao;
        }

        public string Editar(int id, Locacao locacao)
        {
            string resultadoValidacao = locacao.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando Locação [{locacao.Id}], Resultado: {resultadoValidacao}");

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
            Serilog.Log.Logger.Aqui().Information($"Validando Locação [{locacao.Id}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorioLocacao.EditarKmRegistrada(locacao);
            }

            return resultadoValidacao;
        }

    }
}
