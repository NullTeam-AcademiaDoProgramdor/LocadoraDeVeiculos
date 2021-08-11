using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.Configuracoes;

namespace LocadoraDeVeiculos.WindowsApp.Features.ConfiguracoesModule
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
            if (MessageBox.Show("Tem certeza que deseja gravar as configurações atuais?",
                "Configurações do Sistema",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Configuracao.PrecoGasolina = Convert.ToDouble(txtGasolina.Text);
                Configuracao.PrecoGas = Convert.ToDouble(txtGas.Text);
                Configuracao.PrecoDiesel = Convert.ToDouble(txtDiesel.Text);
                Configuracao.PrecoAlcool = Convert.ToDouble(txtAlcool.Text);

                Configuracao.HoraAbertura = dateHoraAbertura.Value.TimeOfDay;
                Configuracao.HoraFechamento = dateHoraFechamento.Value.TimeOfDay;

                Configuracao.AbreNoSabado = checkBSabados.Checked;
                Configuracao.AbreNoDomingo = checkBDomingos.Checked;

                TelaPrincipalForm.Instancia.AtualizarRodape("Configurações salvadas com sucesso!");
            }
        }
    }
}
