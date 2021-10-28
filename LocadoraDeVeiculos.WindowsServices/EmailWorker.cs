using LocadoraDeVeículos.Aplicacao.RequisicaoEmailModule;
using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;
using LocadoraDeVeiculos.Infra.Arquivos;
using LocadoraDeVeiculos.Infra.Internet;
using LocadoraDeVeiculos.Infra.Log;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsServices
{
    public class EmailWorker : BackgroundService
    {
        private readonly ILogger<EmailWorker> _logger;
        private readonly IEmailAppService controlador;

        public EmailWorker(ILogger<EmailWorker> logger, IEmailAppService controlador)
        {
            _logger = logger;
            this.controlador = controlador;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {

                    if (!StatusInternet.EstaConectada() || !controlador.ExisteAlgum())
                    {
                        Serilog.Log.Logger.Aqui().Debug("Esperando 10s para a proxima verificação de email");
                        Console.WriteLine("Esperando 10s para a proxima verificação de email");
                        await Task.Delay(10 * 1000);
                        continue;
                    }

                    ConcurrentBag<RequisicaoEmail> emails = controlador.SelecionarTodos();

                    Parallel.ForEach(emails, email =>
                    {
                        Console.WriteLine($"Enviando email para {email.EmailDestino}");
                        Enviar(email);

                        var Feature = new { Id = email.Id, Destino = email.EmailDestino };
                        Serilog.Log.Logger.Aqui().Information("Email {@Email} enviado, excluindo do sistema.", Feature);
                        controlador.Excluir(email.id);

                        foreach (var arquivo in email.Arquivos)
                        {
                            string caminho =
                                ArquivosUtils.GetEnderecoPastaArquivos(arquivo);
                            ArquivosUtils.ExcluirArquivo(caminho);
                        }
                    });
                }
            }catch(Exception e)
            {
                Serilog.Log.Logger.Aqui().Fatal(e.Message, e);
            }
        }

        private void Enviar(RequisicaoEmail email)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("locadoranull@gmail.com");

                mail.To.Add(new MailAddress(email.EmailDestino));

                mail.Subject = "Relatório de Locação";
                mail.Body = email.Mensagem;

                foreach (var pdf in email.Arquivos)
                {
                    mail.Attachments.Add(
                        new Attachment(ArquivosUtils.GetEnderecoPastaArquivos(pdf),
                        MediaTypeNames.Application.Pdf));
                }

                Serilog.Log.Logger.Aqui().Information($"Enviando email [{mail}] para o cliente");

                GerarClient(s => s.Send(mail));
            }
        }

        private static void GerarClient(Action<SmtpClient> action)
        {
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("locadoranull@gmail.com", "nullteam123");

                action(smtp);
            }
        }

    }
}
