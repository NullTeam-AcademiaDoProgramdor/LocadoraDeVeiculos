using LocadoraDeVeiculos.Controladores.GrupoAutomovelModule;
using LocadoraDeVeiculos.WindowsApp.Features.GruposAutomovel;
using LocadoraDeVeiculos.Controladores.PessoaJuridicaModule;
using LocadoraDeVeiculos.WindowsApp.Features.PessoasJuridicas;
using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.WindowsApp.Features.FuncionarioModule;
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

        private OperacoesGrupoAutomovel operacoesGrupoAutomovel;
        private OperacoesPessoaJuridica operacoesPessoaJuridica;
        //Operacoes
        OperacoesFuncionario operacoesFuncionario;

        public TelaPrincipalForm()
        {
            InitializeComponent();
            DesativarBotoesToolBoxAcoes();

            //intancia das operacoes
            operacoesPessoaJuridica = new OperacoesPessoaJuridica(new ControladorPessoaJuridica());
            operacoesGrupoAutomovel = new OperacoesGrupoAutomovel(new ControladorGrupoAutomovel());            
            operacoesFuncionario = new OperacoesFuncionario(new ControladorFuncionario());

            Instancia = this;
        }

        private void pessoaJuridicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoPessoaJuridicaToolBox configuracao = new ConfiguracaoPessoaJuridicaToolBox();

            ConfigurarTooltips(configuracao.Tooltip);
            ConfigurarBotoes(configuracao.Botoes);

            AtualizarRodape(configuracao.Tooltip.TipoCadastro);

            operacoes = operacoesPessoaJuridica;

            ConfigurarPainelRegistros();
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguacaoFuncionarioToolBox configuracao = new ConfiguacaoFuncionarioToolBox();
            
            ConfigurarTooltips(configuracao.Tooltip);
            ConfigurarBotoes(configuracao.Botoes);

            AtualizarRodape(configuracao.Tooltip.TipoCadastro);

            operacoes = operacoesFuncionario;

            ConfigurarPainelRegistros();
        }

        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();

            tabela.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);
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

        private void menuItemGrupoAutomovel_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoAutomovelToolBox configuracao = 
                new ConfiguracaoGrupoAutomovelToolBox();

            ConfigurarTooltips(configuracao.Tooltip);
            ConfigurarBotoes(configuracao.Botoes);

            AtualizarRodape(configuracao.Tooltip.TipoCadastro);

            operacoes = operacoesGrupoAutomovel;

            ConfigurarPainelRegistros();
        }

        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();

            tabela.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);
        } 
    }
}
