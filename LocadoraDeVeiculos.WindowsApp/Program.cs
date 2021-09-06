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

namespace LocadoraDeVeiculos.WindowsApp
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            EnviadorEmail.Iniciar();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaLoginForm());

            EnviadorEmail.Parar();
        }
    }

}
