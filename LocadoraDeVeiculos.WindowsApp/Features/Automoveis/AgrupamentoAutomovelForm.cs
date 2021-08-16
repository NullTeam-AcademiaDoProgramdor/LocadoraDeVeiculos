using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.Automoveis
{
    public partial class AgrupamentoAutomovelForm : Form
    {
        public AgrupamentoAutomovelForm()
        {
            InitializeComponent();
        }

        public FiltroAutomovelEnum TipoOrdem
        {
            get
            {
                if (rdbAutomovelPorGrupo.Checked)
                    return FiltroAutomovelEnum.AutomoveisPorGrupo;

                else
                    return FiltroAutomovelEnum.AutomoveisSemOrdem;
            }
        }
    }
}
