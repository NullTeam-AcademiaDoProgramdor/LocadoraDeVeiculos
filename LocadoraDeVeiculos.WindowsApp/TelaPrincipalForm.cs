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
using LocadoraDeVeiculos.Controladores.TaxasEServicosModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos;

using LocadoraDeVeiculos.WindowsApp.Features.Configuracoes;
using LocadoraDeVeiculos.WindowsApp.Features.Automoveis;
using LocadoraDeVeiculos.Controladores.AutomovelModule;

namespace LocadoraDeVeiculos.WindowsApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ICadastravel operacoes;

        public static TelaPrincipalForm Instancia;

        public string nomeAdmin = "Rech";

        Funcionario funcionarioConectado;
        
        //Operacoes
        private OperacoesGrupoAutomovel operacoesGrupoAutomovel;
        private OperacoesPessoaJuridica operacoesPessoaJuridica;        
        private OperacoesFuncionario operacoesFuncionario;
        private OperacoesTaxasESevicos operacoesTaxasEServicos;
        private OperacoesConfiguracoes operacoesConfiguracoes;

        private OperacoesAutomovel operacoesAutomovel;

        public TelaPrincipalForm(Funcionario funcionarioConectado)
        {
            InitializeComponent();
            DesativarBotoesToolBoxAcoes();
            this.funcionarioConectado = funcionarioConectado;

            ConfiguracaoDeEntradaNaTelaPrincipal();

            operacoesConfiguracoes = new OperacoesConfiguracoes();

            ConfiguraçõesParaFuncionario();

            AtualizarFuncionarioConectado(this.funcionarioConectado.Nome);

            Instancia = this;
        }                

        public TelaPrincipalForm()
        {            
            InitializeComponent();
            DesativarBotoesToolBoxAcoes();

            //intancia das operacoes
            ConfiguracaoDeEntradaNaTelaPrincipal();

            operacoesConfiguracoes = new OperacoesConfiguracoes();

            ConfiguraçõesParaAdmin();

            funcionarioConectado = new Funcionario("Rech", new DateTime(), 0, "admin");
            AtualizarFuncionarioConectado("Rech");            

            Instancia = this;
        }

        private void ConfiguraçõesParaAdmin()
        {
            menuItemGrupoAutomovel.Visible = menuItemGrupoAutomovel.Enabled = false;
            menuItemTaxasEServicos.Visible = menuItemTaxasEServicos.Enabled = false;
            pessoaJuridicaToolStripMenuItem.Visible = pessoaJuridicaToolStripMenuItem.Enabled = false;
            automovelToolStripMenuItem.Visible = automovelToolStripMenuItem.Enabled = false;

            funcionáriosToolStripMenuItem.ShortcutKeys = Keys.F1;
        }

        private void ConfiguraçõesParaFuncionario()
        {
            funcionáriosToolStripMenuItem.Enabled = funcionáriosToolStripMenuItem.Visible = false;
        }

        private void ConfiguracaoDeEntradaNaTelaPrincipal()
        {
            operacoesPessoaJuridica = new OperacoesPessoaJuridica(new ControladorPessoaJuridica());
            operacoesGrupoAutomovel = new OperacoesGrupoAutomovel(new ControladorGrupoAutomovel());
            operacoesFuncionario = new OperacoesFuncionario(new ControladorFuncionario());
            operacoesTaxasEServicos = new OperacoesTaxasESevicos(new ControladorTaxasEServicos());

            operacoesConfiguracoes = new OperacoesConfiguracoes();

            operacoesAutomovel = new OperacoesAutomovel(new ControladorAutomovel(), new ControladorGrupoAutomovel());

            Instancia = this;
        }

        private void pessoaJuridicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoPessoaJuridicaToolBox configuracao = new ConfiguracaoPessoaJuridicaToolBox();

            ConfigurarTooltips(configuracao.Tooltip);
            ConfigurarBotoes(configuracao.Botoes);

            AtualizarRodape(configuracao.Tooltip.TipoCadastro);
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            operacoes = operacoesPessoaJuridica;

            ConfigurarPainelRegistros();
        }

        public void AtualizarFuncionarioConectado(string nomeFuncionario)
        {
            if(nomeFuncionario == "Rech")
                labelFuncionarioConectado.Text = $"{nomeFuncionario} : Admin";
            else
                labelFuncionarioConectado.Text = $"{nomeFuncionario} : Funcionario";
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
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            operacoes = operacoesFuncionario;

            ConfigurarPainelRegistros();
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

            btnExibirInformacoes.ToolTipText = configuracoes.ToolTipExibirInformacoes;
        }

        private void ConfigurarBotoes(ConfiguracoesBotoes configuracoes)
        {
            btnAdicionar.Enabled = configuracoes.BtnAdicionar;
            btnEditar.Enabled = configuracoes.BtnEditar;
            btnExcluir.Enabled = configuracoes.BtnExcluir;

            btnFiltrar.Enabled = configuracoes.BtnFiltrar;

            btnAgrupar.Enabled = btnDesagrupar.Enabled = configuracoes.BtnAgrupar;

            btnExibirInformacoes.Enabled = configuracoes.btnExibirInformações;
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
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            operacoes = operacoesGrupoAutomovel;

            ConfigurarPainelRegistros();
        }

        private void menuItemTaxasEServicos_Click(object sender, EventArgs e)
        {
            ConfiguracaoTaxasEServicoToolBox configuracao =
                new ConfiguracaoTaxasEServicoToolBox();

            ConfigurarTooltips(configuracao.Tooltip);
            ConfigurarBotoes(configuracao.Botoes);

            AtualizarRodape(configuracao.Tooltip.TipoCadastro);
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            operacoes = operacoesTaxasEServicos;

            ConfigurarPainelRegistros();
        }
        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoConfiguracoesToolBox configuracoesToolBox = 
                new ConfiguracaoConfiguracoesToolBox();

            ConfigurarTooltips(configuracoesToolBox.Tooltip);
            ConfigurarBotoes(configuracoesToolBox.Botoes);

            AtualizarRodape(configuracoesToolBox.Tooltip.TipoCadastro);
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            operacoes = operacoesConfiguracoes;

            ConfigurarPainelRegistros();
        }

        private void automovelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoAutomovelTooBox configuracaoToolBox =
                new ConfiguracaoAutomovelTooBox();

            ConfigurarTooltips(configuracaoToolBox.Tooltip);
            ConfigurarBotoes(configuracaoToolBox.Botoes);

            AtualizarRodape(configuracaoToolBox.Tooltip.TipoCadastro);

            operacoes = operacoesAutomovel;

            ConfigurarPainelRegistros();
        }

        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();

            tabela.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);
        }

       

        private void btnExibirInformacoes_Click(object sender, EventArgs e)
        {
            operacoes.ExibirInformacoesDetalhadas();
        }
    }
}
