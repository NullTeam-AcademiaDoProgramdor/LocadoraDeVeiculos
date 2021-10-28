using LocadoraDeVeiculos.WindowsApp.Features.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.Controladores.AutomovelModule;
using System.Drawing;
using LocadoraDeVeiculos.Servicos.EmailModule;
using System.Threading;
using LocadoraDeVeículos.Aplicacao.RequisicaoEmailModule;
using LocadoraDeVeículos.Infra.SQL.RequisicaoEmailModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeiculos.Infra.ORM.RequisicaoEmailModule;
using Microsoft.Extensions.Hosting;

namespace LocadoraDeVeiculos.WindowsApp
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Log.ConfigurarLog();

            try
            {
                throw new Exception("erro");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TelaLoginForm());
            }
            catch (Exception e)
            {
                Serilog.Log.Fatal(e, e.Message);
            }

        }
    }

}
