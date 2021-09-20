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

namespace LocadoraDeVeículos.Aplicacao.RequisicaoEmailModule
{
    public class EmailAppService : IEmailAppService
    {

        private IRepositorRequisicaoEmail repositorio;
        private Thread thread;

        private bool EstaRodando = true;

        private static EmailAppService _instancia;


        private EmailAppService(IRepositorRequisicaoEmail repositorio)
        {
            // verifica se o repositorio é null
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            thread = new Thread(IniciarFila);
        }

        public static EmailAppService GetInstance(
            IRepositorRequisicaoEmail repositorio = null)
        {

            if (_instancia == null)
            {
                _instancia = new EmailAppService(repositorio);
            }

            return _instancia;
        }

        public void Iniciar()
        {
            thread.Start();
        }

        public void Parar()
        {
            EstaRodando = false;
        }

        public void AdicionarEmail(string mensagem, string emailDestino,
            params string[] pdfs)
        {
            repositorio.InserirNovo(
                new RequisicaoEmail(mensagem, emailDestino, pdfs));
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

        private void Enviar(RequisicaoEmail email)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("locadoranull@gmail.com");

                mail.To.Add(new MailAddress(email.emailDestino));

                mail.Subject = "Relatório de Locação";
                mail.Body = email.mensagem;

                foreach (var pdf in email.arquivos)
                {
                    mail.Attachments.Add(
                        new Attachment(ArquivosUtils.GetEnderecoPastaArquivos(pdf),
                        MediaTypeNames.Application.Pdf));
                }

                GerarClient(s => s.Send(mail));
            }
        }

        private void IniciarFila()
        {
            while (EstaRodando)
            {
                if (!StatusInternet.EstaConectada() || !repositorio.ExisteAlgum())
                {
                    Console.WriteLine("Esperando 10s para a proxima verificação de email");
                    Thread.Sleep(10 * 1000);
                    continue;
                }

                List<RequisicaoEmail> emails = repositorio.SelecionarTodos();

                foreach (var email in emails)
                {
                    Console.WriteLine($"Enviando email para {email.emailDestino}");
                    Enviar(email);
                    repositorio.Excluir(email.id);

                    foreach (var arquivo in email.arquivos)
                    {
                        string caminho = 
                            ArquivosUtils.GetEnderecoPastaArquivos(arquivo);
                        ArquivosUtils.ExcluirArquivo(caminho);
                    }

                }

            }
        }
    }
}
