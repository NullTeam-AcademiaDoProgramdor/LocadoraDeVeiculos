using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ICadastravel operacoes;

        public static TelaPrincipalForm Instancia;

        //Operacoes

        public TelaPrincipalForm()
        {
            InitializeComponent();

            DesativarBotoesToolBoxAcoes();

            //intancia das operacoes

            Instancia = this;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            operacoes.InserirNovoRegistro();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            operacoes.EditarRegistro();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            operacoes.ExcluirRegistro();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            operacoes.FiltrarRegistros();
        }

        private void btnAgrupar_Click(object sender, EventArgs e)
        {
            operacoes.AgruparRegistros();
        }

        private void btnDesagrupar_Click(object sender, EventArgs e)
        {
            operacoes.DesagruparRegistros();
        }

        private void ConfigurarTooltips(ConfiguracoesTooltip configuracoes)
        {
            labelTipoCadastro.Text = configuracoes.TipoCadastro;

            btnAdicionar.ToolTipText = configuracoes.ToolTipAdicionar;
            btnEditar.ToolTipText = configuracoes.ToolTipEditar;
            btnExcluir.ToolTipText = configuracoes.ToolTipExcluir;

            btnFiltrar.ToolTipText = configuracoes.ToolTipFiltrar;

            btnAgrupar.ToolTipText = configuracoes.ToolTipAgrupar;
            btnDesagrupar.ToolTipText = configuracoes.ToolTípDesagrupar;
        }

        private void ConfigurarBotoes(ConfiguracoesBotoes configuracoes)
        {
            btnAdicionar.Enabled = configuracoes.BtnAdicionar;
            btnEditar.Enabled = configuracoes.BtnEditar;
            btnExcluir.Enabled = configuracoes.BtnExcluir;

            btnFiltrar.Enabled = configuracoes.BtnFiltrar;

            btnAgrupar.Enabled = btnDesagrupar.Enabled = configuracoes.BtnAgrupar;
        }

        private void DesativarBotoesToolBoxAcoes()
        {
            foreach (var item in toolboxAcoes.Items)
            {
                if (item is ToolStripButton)
                    (item as ToolStripButton).Enabled = false;
            }
        }
    }
}