using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasJuridicas
{
    public partial class AgrupamentoPessoaFisicaForm : Form
    {
        public AgrupamentoPessoaFisicaForm()
        {
            InitializeComponent();
        }

        public FiltroPessoaFisicaEnum TipoOrdem
        {
            get
            {
                if (rdbPessoasPorEmpresa.Checked)
                    return FiltroPessoaFisicaEnum.PessoaPorEmpresa;

                else
                    return FiltroPessoaFisicaEnum.PessoaSemOrdem;
            }
        }
    }
}
