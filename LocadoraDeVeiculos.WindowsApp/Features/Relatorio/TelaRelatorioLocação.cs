using LocadoraDeVeiculos.Dominio.LocacaoModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.Relatorio
{
    public partial class TelaRelatorioLocação : Form
    {
        public TelaRelatorioLocação()
        {
            InitializeComponent();
        }

        public TelaRelatorioLocação(Locacao locacao)
        {
            InitializeComponent();
        }
    }
}
