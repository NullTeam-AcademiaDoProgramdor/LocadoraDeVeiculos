using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.GruposAutomovel
{
    public partial class TelaInformacoesDetalhadasForm : Form
    {
        private GrupoAutomovel grupo;
        public TelaInformacoesDetalhadasForm(GrupoAutomovel grupo)
        {
            InitializeComponent();

            this.grupo = grupo;
            NomearCamposDosPlanos();
        }

        private void NomearCamposDosPlanos()
        {
            lblPlanoControl_PrecoDia.Text = grupo.PlanoKmControlado.PrecoDia.ToString();
            lblPlanoControl_KmDisponivel.Text = grupo.PlanoKmControlado.KmDisponiveis.ToString();
            lblPlanoControl_PrecoKmExtra.Text = grupo.PlanoKmControlado.PrecoKmExtrapolado.ToString();

            lblPlanoDiario_PrecoDia.Text = grupo.PlanoDiario.PrecoDia.ToString();
            lblPlanoDiario_PrecoKm.Text = grupo.PlanoDiario.PrecoKm.ToString();

            lblPlanoLivre_PrecoDia.Text = grupo.PlanoKmLivre.PrecoDia.ToString();
        }

    }
}
