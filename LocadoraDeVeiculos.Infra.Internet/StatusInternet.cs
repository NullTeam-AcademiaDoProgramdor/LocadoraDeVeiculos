using System;
using System.Net.NetworkInformation;

namespace LocadoraDeVeiculos.Infra.Internet
{
    public static class StatusInternet
    {
        public static bool EstaConectada()
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
