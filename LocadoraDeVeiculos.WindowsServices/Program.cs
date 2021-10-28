using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.RequisicaoEmailModule;
using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;
using LocadoraDeVeículos.Aplicacao.RequisicaoEmailModule;
using LocadoraDeVeiculos.Infra.Log;

namespace LocadoraDeVeiculos.WindowsServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.ConfigurarLog();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<EmailWorker>();
                }).ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterType<DBLocadoraContext>().InstancePerLifetimeScope();

                    builder.RegisterType<RequisicaoEmailORMDao>().As<IRepositorRequisicaoEmail>().InstancePerDependency();

                    builder.RegisterType<EmailAppService>().As<IEmailAppService>().InstancePerDependency();
                });
    }
}
