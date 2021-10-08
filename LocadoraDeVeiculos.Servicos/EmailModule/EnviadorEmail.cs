using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Controladores.RequisicaoEmailModule;
using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;
using System.IO;

namespace LocadoraDeVeiculos.Servicos.EmailModule
{
    public static class EnviadorEmail
    {
        private static ControladorRequisicaoEmail controlador;
        private static Thread thread;

        private static bool EstaRodando = true;

        static EnviadorEmail()
        {
            controlador = new ControladorRequisicaoEmail();

            thread = new Thread(IniciarFila);
        }

        public static void Iniciar()
        {
            thread.Start();
        }

        public static void Parar()
        {
            EstaRodando = false;
        }

        public static void AdicionarEmail(string mensagem, string emailDestino,
            params string[] pdfs)
        {
            controlador.InserirNovo(
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

        private static string GetEnderecoReal(string arquivo)
        {
            return @"..\..\..\..\Arquivos\" + arquivo;
        }

        private static void Enviar(RequisicaoEmail email)
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
                        new Attachment(GetEnderecoReal(pdf),
                        MediaTypeNames.Application.Pdf));
                }

                GerarClient(s => s.Send(mail));
            }
        }

        private static void IniciarFila()
        {
            while (EstaRodando)
            {
                if (!IsConnectedToInternet() || !controlador.ExisteAlgum())
                {
                    Console.WriteLine("Esperando 10s para a proxima verificação de email");
                    Thread.Sleep(10 * 1000);
                    continue;
                }

                List<RequisicaoEmail> emails = controlador.SelecionarTodos();

                foreach (var email in emails)
                {
                    Console.WriteLine($"Enviando email para {email.EmailDestino}");
                    Enviar(email);
                    controlador.Excluir(email.id);
                    ExcluirArquivos(email.Arquivos);
                }

            }
        }

        private static bool IsConnectedToInternet()
        {
            string host = "www.google.com.br";

            bool result = false;
            Ping p = new Ping();

            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }

            return result;
        }

        private static void ExcluirArquivos(string[] arquivos)
        {
            foreach (var arquivo in arquivos)
            {
                string caminho = GetEnderecoReal(arquivo);
                File.Delete(caminho);
            }
        }
    }
}