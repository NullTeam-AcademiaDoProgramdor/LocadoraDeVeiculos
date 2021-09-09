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
            this.Text = "Informações Detalhadas: " + grupo.Nome;

            lblId.Text = grupo.Id.ToString();
            lblNome.Text = grupo.Nome.ToString();
            lblPlanoControl_PrecoDia.Text = "R$" + grupo.PlanoKmControlado.PrecoDia.ToString();
            lblPlanoControl_KmDisponivel.Text = grupo.PlanoKmControlado.KmDisponiveis.ToString() + " Km's";
            lblPlanoControl_PrecoKmExtra.Text = "R$" + grupo.PlanoKmControlado.PrecoKmExtrapolado.ToString();

            lblPlanoDiario_PrecoDia.Text = "R$" + grupo.PlanoDiario.PrecoDia.ToString();
            lblPlanoDiario_PrecoKm.Text = "R$" + grupo.PlanoDiario.PrecoKm.ToString();

            lblPlanoLivre_PrecoDia.Text = "R$" + grupo.PlanoKmLivre.PrecoDia.ToString();
        }
    }
}
