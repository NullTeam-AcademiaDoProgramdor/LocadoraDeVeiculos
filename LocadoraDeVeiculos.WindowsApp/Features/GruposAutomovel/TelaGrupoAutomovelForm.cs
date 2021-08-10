using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.GruposAutomovel
{
    public partial class TelaGrupoAutomovelForm : Form
    {
        private GrupoAutomovel grupoAutomovel;

        public TelaGrupoAutomovelForm()
        {
            InitializeComponent();
        }

        public GrupoAutomovel GrupoAutomovel
        {
            get { return grupoAutomovel; }
            set
            {
                grupoAutomovel = value;

                txtId.Text = grupoAutomovel.Id.ToString();

                txtNome.Text = grupoAutomovel.Nome;

                txtPlanoDiarioPrecoDia.Text = grupoAutomovel.PlanoDiario.PrecoDia.ToString();
                txtPlanoDiarioPrecoKm.Text = grupoAutomovel.PlanoDiario.PrecoKm.ToString();

                txtPlanoControladoKmDisponiveis.Text = grupoAutomovel.PlanoKmControlado.KmDisponiveis.ToString();
                txtPlanoControladoPrecoDia.Text = grupoAutomovel.PlanoKmControlado.PrecoDia.ToString();
                txtPlanoControladoPrecoKmExtrapolado.Text = grupoAutomovel.PlanoKmControlado.PrecoKmExtrapolado.ToString();

                txtPlanoLivrePrecoDia.Text = grupoAutomovel.PlanoKmLivre.PrecoDia.ToString();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            double? planoDiario_PrecoDia, planoDiario_PrecoKm;
            double? planoControlado_PrecoDia, planoControlado_PrecoKmExtrapolado, planoControlado_KmDisponiveis;
            double? planoLivre_PrecoDia;

            planoDiario_PrecoDia = PegarDoubleComVerificacao(txtPlanoDiarioPrecoDia);
            if (planoDiario_PrecoDia == null)
                return;

            planoDiario_PrecoKm = PegarDoubleComVerificacao(txtPlanoDiarioPrecoKm);
            if (planoDiario_PrecoKm == null)
                return;

            planoControlado_PrecoDia = PegarDoubleComVerificacao(txtPlanoControladoPrecoDia);
            if (planoControlado_PrecoDia == null)
                return;

            planoControlado_PrecoKmExtrapolado = PegarDoubleComVerificacao(txtPlanoControladoPrecoKmExtrapolado);
            if (planoControlado_PrecoKmExtrapolado == null)
                return;

            planoControlado_KmDisponiveis = PegarDoubleComVerificacao(txtPlanoControladoKmDisponiveis);
            if (planoControlado_KmDisponiveis == null)
                return;

            planoLivre_PrecoDia = PegarDoubleComVerificacao(txtPlanoLivrePrecoDia);
            if (planoLivre_PrecoDia == null)
                return;

            PlanoDiarioStruct planoDiario = new PlanoDiarioStruct(
                (double)planoDiario_PrecoDia, 
                (double)planoDiario_PrecoKm
            );

            PlanoKmControladoStruct planoKmControlado = new PlanoKmControladoStruct(
                (double)planoControlado_PrecoDia,
                (double)planoControlado_PrecoKmExtrapolado,
                (double)planoControlado_KmDisponiveis
            );

            PlanoKmLivreStruct planoKmLivre = new PlanoKmLivreStruct(
                (double)planoLivre_PrecoDia    
            );

            grupoAutomovel = new GrupoAutomovel(nome, planoDiario, planoKmControlado, planoKmLivre);

            string resultadoValidacao = grupoAutomovel.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private double? PegarDoubleComVerificacao(TextBox textBox)
        {
            try
            {
                return Convert.ToDouble(textBox.Text);
            } catch (Exception)
            {
                TelaPrincipalForm.Instancia
                    .AtualizarRodape($"Digite um numero no campo {textBox.AccessibleName}");
                DialogResult = DialogResult.None;
            }

            return null;
        }

        private void TelaGrupoAutomovelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
