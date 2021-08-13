using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasFisicas
{
    public partial class TabelaPessoaFisicaControl : UserControl
    {
        Subro.Controls.DataGridViewGrouper gridPessoasFisicasAgrupadas = new Subro.Controls.DataGridViewGrouper();
        ControladorPessoaFisica controlador = new ControladorPessoaFisica();
        public TabelaPessoaFisicaControl()
        {
            InitializeComponent();

        }
    }
}
