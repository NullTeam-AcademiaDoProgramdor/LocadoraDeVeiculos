using Autofac;
using LocadoraDeVeículos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeiculos.Infra.ORM.CupomModule;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Infra.ORM.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Infra.ORM.AutomovelModule;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Infra.ORM.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.ORM.PessoaJuridicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeiculos.Infra.ORM.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Infra.ORM.TaxaEServicoModule;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.Infra.ORM.RequisicaoEmailModule;
using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;
using LocadoraDeVeiculos.Infra.ORM.LocacaoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeículos.Aplicacao.CupomModule;
using LocadoraDeVeículos.Aplicacao.GrupoAutomovelModule;
using LocadoraDeVeículos.Aplicacao.AutomovelModule;
using LocadoraDeVeículos.Aplicacao.FuncionarioModule;
using LocadoraDeVeículos.Aplicacao.PessoaJuridicaModule;
using LocadoraDeVeículos.Aplicacao.PessoaFisicaModule;
using LocadoraDeVeículos.Aplicacao.TaxaEServicoModule;
using LocadoraDeVeículos.Aplicacao.LocacaoModule;
using LocadoraDeVeículos.Aplicacao.RequisicaoEmailModule;
using LocadoraDeVeículos.Infra.PDF.PDFModule;
using LocadoraDeVeiculos.WindowsApp.Shared;
using LocadoraDeVeiculos.WindowsApp.Features.Parceiros;
using LocadoraDeVeiculos.WindowsApp.Features.Cupons;
using LocadoraDeVeiculos.WindowsApp.Features.GruposAutomovel;
using LocadoraDeVeiculos.WindowsApp.Features.FuncionarioModule;
using LocadoraDeVeiculos.WindowsApp.Features.Automoveis;
using LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos;
using LocadoraDeVeiculos.WindowsApp.Features.PessoasJuridicas;
using LocadoraDeVeiculos.WindowsApp.Features.PessoasFisicas;
using LocadoraDeVeiculos.WindowsApp.Features.LocacaoModule;

namespace LocadoraDeVeiculos.WindowsApp
{
    public static class AutoFacBuilder
    {
        public static IContainer Container { get; private set; }

        static AutoFacBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DBLocadoraContext>().InstancePerLifetimeScope();
            
            RegistrarORM(builder);
            RegistrarAppService(builder);
            RegistrarOperacoes(builder);

            Container = builder.Build();
        }


        private static void RegistrarORM(ContainerBuilder builder)
        {
            builder.RegisterType<ParceiroORMDao>().As<IRepositorBase<Parceiro>>().InstancePerDependency();

            builder.RegisterType<CupomORMDao>().As<IRepositorCupomBase>().InstancePerDependency();

            builder.RegisterType<GrupoAutomovelORMDao>().As<IRepositorBase<GrupoAutomovel>>().InstancePerDependency();

            builder.RegisterType<AutomovelORMDao>().As<IRepositorAutomovelBase>().InstancePerDependency();

            builder.RegisterType<FuncionarioORMDao>().As<IRepositorFuncionarioBase>().InstancePerDependency();

            builder.RegisterType<PessoaJuridicaORMDao>().As<IRepositorBase<PessoaJuridica>>().InstancePerDependency();

            builder.RegisterType<PessoaFisicaORMDao>().As<IRepositorBase<PessoaFisica>>().InstancePerDependency();

            builder.RegisterType<TaxaEServicoORMDao>().As<IRepositorTaxaEServicoBase>().InstancePerDependency();   
            
            builder.RegisterType<RequisicaoEmailORMDao>().As<IRepositorRequisicaoEmail>().InstancePerDependency();            

            builder.RegisterType<GeradorPDF>().InstancePerDependency();

            builder.RegisterType<LocacaoORMDao>().As<IRepositorLocacaoBase>().InstancePerDependency();
            
        }
        private static void RegistrarAppService(ContainerBuilder builder)
        {
            builder.RegisterType<ParceiroAppService>().InstancePerDependency();

            builder.RegisterType<CupomAppService>().InstancePerDependency();

            builder.RegisterType<GrupoAutomovelAppService>().InstancePerDependency();

            builder.RegisterType<AutomovelAppService>().InstancePerDependency();

            builder.RegisterType<FuncionarioAppService>().InstancePerDependency();

            builder.RegisterType<PessoaJuridicaAppService>().InstancePerDependency();

            builder.RegisterType<PessoaFisicaAppService>().InstancePerDependency();

            builder.RegisterType<TaxaEServicoAppService>().InstancePerDependency();

            builder.RegisterType<EmailAppService>().As<IEmailAppService>().InstancePerDependency();

            builder.RegisterType<LocacaoAppService>().InstancePerDependency();
        }
        private static void RegistrarOperacoes(ContainerBuilder builder)
        {
            builder.RegisterType<OperacoesParceiro>().InstancePerDependency();

            builder.RegisterType<OperacoesCupons>().InstancePerDependency();

            builder.RegisterType<OperacoesGrupoAutomovel>().InstancePerDependency();

            builder.RegisterType<OperacoesAutomovel>().InstancePerDependency();

            builder.RegisterType<OperacoesFuncionario>().InstancePerDependency();

            builder.RegisterType<OperacoesPessoaJuridica>().InstancePerDependency();

            builder.RegisterType<OperacoesPessoaFisica>().InstancePerDependency();

            builder.RegisterType<OperacoesTaxasESevicos>().InstancePerDependency();

            builder.RegisterType<OperacoesLocacao>().InstancePerDependency();
        }
    }
}
