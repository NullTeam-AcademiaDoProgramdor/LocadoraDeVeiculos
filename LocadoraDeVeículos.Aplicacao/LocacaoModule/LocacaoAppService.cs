using LocadoraDeVeículos.Aplicacao.RequisicaoEmailModule;
using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.RelatorioModule;
using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.AutomovelModule;
using LocadoraDeVeiculos.Infra.ORM.CupomModule;
using LocadoraDeVeiculos.Infra.ORM.LocacaoModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
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
        LocacaoORMDao repositorioLocacao = null;
        //TaxasEServicosUsadosDao repositorioTaxas = null;
        CupomORMDao repositorioCupom = null;
        AutomovelORMDao repositorioAutomovel = null;
        GeradorPDF repositorioPDF = null;
        IEmailAppService emailAppService = null;
        DBLocadoraContext db = null;

        public LocacaoAppService(LocacaoORMDao repositorioLocacao,
                                 CupomORMDao repositorioCupom,
                                 AutomovelORMDao repositorioAutomovel,
                                 GeradorPDF repositorioPDF,
                                 IEmailAppService emailAppService,
                                 DBLocadoraContext db)
        {
            this.repositorioLocacao = repositorioLocacao;
            this.repositorioCupom = repositorioCupom;
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioPDF = repositorioPDF;
            this.emailAppService = emailAppService;
            this.db = db;
        }

        public string InserirNovo(Locacao registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando Locação [{registro.Id}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorioLocacao.InserirNovo(registro);

                //repositorioTaxas.Modificar(registro.TaxasEServicos, registro.id);

                db.SaveChanges();
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

                locacao.Automovel.KmRegistrada = (int)locacao.KmAutomovelFinal;

                repositorioLocacao.Devolver(id, locacao);
                repositorioAutomovel.EditarKmRegistrada(locacao.Automovel.Id, locacao.Automovel);

                string email = (locacao.Condutor.PessoaJuridica == null) ? locacao.Condutor.Email
                        : locacao.Condutor.PessoaJuridica.Email;

                string pdf = repositorioPDF.GerarPdf(new Relatorio(locacao));
                Serilog.Log.Logger.Aqui().Information($"Enviando locacao [{locacao}] para GeradorPDF");

                emailAppService
                    .AdicionarEmail("Aqui está o relatório de sua locação finalizada.",
                                    email,
                                    pdf);

                db.SaveChanges();
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

                //repositorioTaxas.Modificar(locacao.TaxasEServicos, locacao.id);

                db.SaveChanges();
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            bool resultado = repositorioLocacao.Excluir(id);
            db.SaveChanges();

            return resultado;
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
    }
}
