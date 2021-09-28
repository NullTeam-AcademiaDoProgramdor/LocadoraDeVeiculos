using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.Infra.Configuracoes;
using LocadoraDeVeiculos.Infra.Log;

namespace LocadoraDeVeiculos.WindowsApp.Features.Configuracoes
{
    public partial class ConfiguracoesControl : UserControl
    {
        public ConfiguracoesControl()
        {
            InitializeComponent();
        }

        public void CarregarConfiguracoes()
        {
            txtGasolina.Text = Configuracao.PrecoGasolina.ToString();
            txtGas.Text = Configuracao.PrecoGas.ToString();
            txtAlcool.Text = Configuracao.PrecoAlcool.ToString();
            txtDiesel.Text = Configuracao.PrecoDiesel.ToString();

            dateHoraAbertura.Value = ConverterTimeSpanParaDateTime(Configuracao.HoraAbertura);
            dateHoraFechamento.Value = ConverterTimeSpanParaDateTime(Configuracao.HoraFechamento);

            checkBSabados.Checked = Configuracao.AbreNoSabado;
            checkBDomingos.Checked = Configuracao.AbreNoDomingo;

            checkBLogDetalhado.Checked = Configuracao.LogDetalhado;
        }

        private DateTime ConverterTimeSpanParaDateTime(TimeSpan hora)
        {
            var dataTemp = DateTime.Now.Date;
            dataTemp += hora;

            return dataTemp;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja cancelar a edição?", 
                "Configurações do Sistema",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CarregarConfiguracoes();

                TelaPrincipalForm.Instancia.AtualizarRodape("Configurações não foram salvadas");
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            double? precoGasolina = PegarDoubleComVerificacao(txtGasolina);
            if (precoGasolina == null)
                return;

            double? precoGas = PegarDoubleComVerificacao(txtGas);
            if (precoGas == null)
                return;

            double? precoDiesel = PegarDoubleComVerificacao(txtDiesel);
            if (precoDiesel == null)
                return;

            double? precoAlcool = PegarDoubleComVerificacao(txtAlcool);
            if (precoAlcool == null)
                return;


            if (MessageBox.Show("Tem certeza que deseja gravar as configurações atuais?",
                "Configurações do Sistema",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Configuracao.PrecoGasolina =(double) precoGasolina;
                Configuracao.PrecoGas = (double) precoGas;
                Configuracao.PrecoDiesel = (double) precoDiesel;
                Configuracao.PrecoAlcool = (double) precoAlcool;

                Configuracao.HoraAbertura = dateHoraAbertura.Value.TimeOfDay;
                Configuracao.HoraFechamento = dateHoraFechamento.Value.TimeOfDay;

                Configuracao.AbreNoSabado = checkBSabados.Checked;
                Configuracao.AbreNoDomingo = checkBDomingos.Checked;

                Configuracao.LogDetalhado = checkBLogDetalhado.Checked;
                Log.SetDetalharLog(checkBLogDetalhado.Checked);

                TelaPrincipalForm.Instancia.AtualizarRodape("Configurações salvadas com sucesso!");
            }
        }

        private double? PegarDoubleComVerificacao(TextBox textBox)
        {
            try
            {
                return Convert.ToDouble(textBox.Text);
            }
            catch (Exception)
            {
                TelaPrincipalForm.Instancia
                    .AtualizarRodape($"Digite um numero no campo {textBox.AccessibleName}");
            }

            return null;
        }
    }
}
