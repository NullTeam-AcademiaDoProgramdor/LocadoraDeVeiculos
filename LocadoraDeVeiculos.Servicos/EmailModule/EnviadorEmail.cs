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

namespace LocadoraDeVeiculos.Servicos.EmailModule
{
    public static class EnviadorEmail
    {
        private class Email
        {
            public string mensagem;
            public string emailDestino;
            public string[] arquivos;

            public Email(string mensagem, string emailDestino, string[] arquivos)
            {
                this.mensagem = mensagem;
                this.emailDestino = emailDestino;
                this.arquivos = arquivos;
            }
        }

        private static Queue<Email> filaDeEmail;

        static EnviadorEmail()
        {
            filaDeEmail = new Queue<Email>();

            Thread thread = new Thread(IniciarFila);
            thread.Start();
        }

        public static void AdicionarEmail(string mensagem, string emailDestino,
            params string[] pdfs)
        {
            filaDeEmail.Enqueue(new Email(mensagem, emailDestino, pdfs));
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
            return @"..\..\..\Arquivos\" + arquivo;
        }

        private static void Enviar(Email email)
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
                        new Attachment(GetEnderecoReal(pdf), 
                        MediaTypeNames.Application.Pdf));
                }

                GerarClient(s => s.Send(mail));
            }
        }

        private static void IniciarFila()
        {

            while (true)
            {
                if (!IsConnectedToInternet())
                {
                    Thread.Sleep(10 * 1000);
                    continue;
                }

                if (filaDeEmail.Count > 0)
                { 
                    Email email = filaDeEmail.Dequeue();
                    EnviadorEmail.Enviar(email);
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

    }
}
