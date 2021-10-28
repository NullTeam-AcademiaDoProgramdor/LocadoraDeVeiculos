using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;
using LocadoraDeVeiculos.Infra.Arquivos;
using LocadoraDeVeiculos.Infra.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Infra.Log;
using System.Collections.Concurrent;
using LocadoraDeVeiculos.Infra.ORM.Models;

namespace LocadoraDeVeículos.Aplicacao.RequisicaoEmailModule
{
    public class EmailAppService : IEmailAppService
    {

        private IRepositorRequisicaoEmail repositorio;
        private DBLocadoraContext db;

        public EmailAppService(IRepositorRequisicaoEmail repositor , DBLocadoraContext db)
        {
            repositorio = repositor;
            this.db = db;
        }

        public void AdicionarEmail(string mensagem, string emailDestino,
            params string[] pdfs)
        {
            Serilog.Log.Logger.Aqui().Information($"Inserindo email para enviar");
            repositorio.InserirNovo(
                new RequisicaoEmail(mensagem, emailDestino, pdfs));

            db.SaveChanges();
        }


        //private static void GerarClient(Action<SmtpClient> action)
        //{
        //    using (SmtpClient smtp = new SmtpClient())
        //    {
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.Port = 587;
        //        smtp.EnableSsl = true;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.Credentials = new NetworkCredential("locadoranull@gmail.com", "nullteam123");

        //        action(smtp);
        //    }
        //}

        //private void Enviar(RequisicaoEmail email)
        //{
        //    using (MailMessage mail = new MailMessage())
        //    {
        //        mail.From = new MailAddress("locadoranull@gmail.com");

        //        mail.To.Add(new MailAddress(email.EmailDestino));

        //        mail.Subject = "Relatório de Locação";
        //        mail.Body = email.Mensagem;

        //        foreach (var pdf in email.Arquivos)
        //        {
        //            mail.Attachments.Add(
        //                new Attachment(ArquivosUtils.GetEnderecoPastaArquivos(pdf),
        //                MediaTypeNames.Application.Pdf));
        //        }

        //        Serilog.Log.Logger.Aqui().Information($"Enviando email [{mail}] para o cliente");

        //        GerarClient(s => s.Send(mail));
        //    }
        //}

        //private void IniciarFila()
        //{
        //    while (EstaRodando)
        //    {
        //        if (!StatusInternet.EstaConectada() || !repositorio.ExisteAlgum())
        //        {
        //            Console.WriteLine("Esperando 10s para a proxima verificação de email");
        //            Thread.Sleep(10 * 1000);
        //            continue;
        //        }

        //        List<RequisicaoEmail> emails = repositorio.SelecionarTodos();

        //        foreach (var email in emails)
        //        {
        //            Console.WriteLine($"Enviando email para {email.EmailDestino}");
        //            Enviar(email);
        //            Serilog.Log.Logger.Aqui().Information($"Email {email} enviado, excluindo do sistema.");
        //            repositorio.Excluir(email.id);

        //            foreach (var arquivo in email.Arquivos)
        //            {
        //                string caminho = 
        //                    ArquivosUtils.GetEnderecoPastaArquivos(arquivo);
        //                ArquivosUtils.ExcluirArquivo(caminho);
        //            }

        //        }

        //    }
        //}

        public bool Excluir(int id)
        {
            var resultado = repositorio.Excluir(id);
            db.SaveChanges();

            return resultado;
        }

        public bool ExisteAlgum()
        {
            return repositorio.ExisteAlgum();
        }

        public ConcurrentBag<RequisicaoEmail> SelecionarTodos()
        {
            return new ConcurrentBag<RequisicaoEmail>(repositorio.SelecionarTodos());
        }
    }
}
