using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Servicos.EmailModule
{
    public class EnviadorEmail
    {

        private void GerarClient(Action<SmtpClient> action)
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

        private string GetEnderecoReal(string arquivo)
        {
            return @"..\..\..\Arquivos\" + arquivo;
        }

        public void Enviar(string mensagem, string emailDestino, 
            params string[] pdfs)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("locadoranull@gmail.com");

                mail.To.Add(new MailAddress(emailDestino));

                mail.Subject = "Relatório de Locação";
                mail.Body = mensagem;

                foreach (var pdf in pdfs)
                {
                    mail.Attachments.Add(
                        new Attachment(GetEnderecoReal(pdf), 
                        MediaTypeNames.Application.Pdf));
                }

                GerarClient(s => s.Send(mail));
            }
        }
    }
}
