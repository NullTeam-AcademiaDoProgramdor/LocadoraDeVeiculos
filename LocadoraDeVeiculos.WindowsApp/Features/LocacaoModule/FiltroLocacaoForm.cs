using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.LocacaoModule
{
    public partial class FiltroLocacaoForm : Form
    {
        public FiltroLocacaoForm()
        {
            InitializeComponent();
        }

        public FiltroLocacaoEnum TipoFiltro
        {
            get
            {
                if (rdbLocacaoDevolvida.Checked)
                    return FiltroLocacaoEnum.LocacoesDevolvidas;

                else if (rdbLocacaoNaoDevolvida.Checked)
                    return FiltroLocacaoEnum.LocacoesNaoDevolvidas;
                
                else
                    return FiltroLocacaoEnum.TodasLocacoes;
            }
        }
    }
}
