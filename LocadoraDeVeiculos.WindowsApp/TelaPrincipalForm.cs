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
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos;

using LocadoraDeVeiculos.WindowsApp.Features.Configuracoes;
using LocadoraDeVeiculos.WindowsApp.Features.PessoasFisicas;

using LocadoraDeVeiculos.WindowsApp.Features.Automoveis;
using LocadoraDeVeiculos.Controladores.AutomovelModule;
using LocadoraDeVeiculos.WindowsApp.Features.LocacaoModule;
using LocadoraDeVeiculos.Controladores.LocacaoModule;
using LocadoraDeVeiculos.WindowsApp.Features.Parceiros;

using LocadoraDeVeiculos.WindowsApp.Features.Cupons;
using LocadoraDeVeiculos.Controladores.CupomModule;
using LocadoraDeVeículos.Aplicacao.ParceiroModule;
using LocadoraDeVeículos.Infra.SQL.ParceiroModule;
using LocadoraDeVeículos.Aplicacao.TaxaEServicoModule;
using LocadoraDeVeículos.Infra.SQL.TaxasEServicosModule;
using LocadoraDeVeículos.Aplicacao.GrupoAutomovelModule;
using LocadoraDeVeículos.Infra.SQL.GrupoAutomovelModule;
using LocadoraDeVeículos.Aplicacao.PessoaJuridicaModule;
using LocadoraDeVeículos.Infra.SQL.PessoaJuridicaModule;
using LocadoraDeVeículos.Aplicacao.PessoaFisicaModule;
using LocadoraDeVeículos.Infra.SQL.PessoaFisicaModule;
using LocadoraDeVeículos.Aplicacao.AutomovelModule;
using LocadoraDeVeículos.Infra.SQL.AutomovelModule;
using LocadoraDeVeículos.Aplicacao.CupomModule;
using LocadoraDeVeículos.Infra.SQL.CupomModule;
using LocadoraDeVeículos.Aplicacao.FuncionarioModule;
using LocadoraDeVeículos.Infra.SQL.FuncionarioModule;
using LocadoraDeVeículos.Aplicacao.LocacaoModule;
using LocadoraDeVeículos.Infra.SQL.LocacaoModule;
using LocadoraDeVeículos.Infra.PDF.PDFModule;
using LocadoraDeVeículos.Aplicacao.RequisicaoEmailModule;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.CupomModule;
using LocadoraDeVeiculos.Infra.ORM.PessoaJuridicaModule;
using LocadoraDeVeiculos.Infra.ORM.GrupoAutomovelModule;

namespace LocadoraDeVeiculos.WindowsApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ICadastravel operacoes;
        private IConfiguracaoToolBox configuracoes;

        public static TelaPrincipalForm Instancia;

        public string nomeAdmin = "Rech";

        public Funcionario funcionarioConectado;
        
        //Operacoes
        private OperacoesPessoaJuridica operacoesPessoaJuridica;        
        private OperacoesFuncionario operacoesFuncionario;
        private OperacoesTaxasESevicos operacoesTaxasEServicos;
        private OperacoesConfiguracoes operacoesConfiguracoes;
        private OperacoesPessoaFisica operacoesPessoaFisica;
        private OperacoesLocacao operacoesLocacao;

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
            pessoaFisicaToolStripMenuItem.Visible = pessoaFisicaToolStripMenuItem.Enabled = false;
            locaçõesToolStripMenuItem.Visible = locaçõesToolStripMenuItem.Enabled = false;
            PessoasToolStripMenuItem.Visible = false;
            AutomoveisToolStripMenuItem.Visible = false;
            funcionáriosToolStripMenuItem.ShortcutKeys = Keys.F1;
        }

        private void ConfiguraçõesParaFuncionario()
        {
            funcionáriosToolStripMenuItem.Enabled = funcionáriosToolStripMenuItem.Visible = false;
        }

        private void ConfiguracaoDeEntradaNaTelaPrincipal()
        {
            operacoesGrupoAutomovel = new OperacoesGrupoAutomovel(new GrupoAutomovelAppService(new GrupoAutomovelDao()));
            operacoesPessoaJuridica = new OperacoesPessoaJuridica(new PessoaJuridicaAppService(new PessoaJuridicaDao()));
            operacoesFuncionario = new OperacoesFuncionario(new FuncionarioAppService(new FuncionarioDao()));
            operacoesTaxasEServicos = new OperacoesTaxasESevicos(new TaxaEServicoAppService(new TaxasEServicosDao()));
            operacoesPessoaFisica = new OperacoesPessoaFisica(new PessoaFisicaAppService(new PessoaFisicaDao()));
            operacoesConfiguracoes = new OperacoesConfiguracoes();

            operacoesLocacao = new OperacoesLocacao(
                new LocacaoAppService(
                    new LocacaoDao(), 
                    new TaxasEServicosUsadosDao(), 
                    new CupomDao(), 
                    new GeradorPDF(),
                    EmailAppService.GetInstance()));

            //operacoesAutomovel = new OperacoesAutomovel(
            //    new AutomovelAppService(new AutomovelDao(), new FotosAutomovelDao()), 
            //    new GrupoAutomovelAppService(new GrupoAutomovelDao()));

            Instancia = this;
        }

        private void pessoaJuridicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoes = new ConfiguracaoPessoaJuridicaToolBox();

            ConfigurarTooltips(configuracoes.Tooltip);
            ConfigurarBotoes(configuracoes.Botoes);

            AtualizarRodape(configuracoes.Tooltip.TipoCadastro);
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            DBLocadoraContext db = new();

            operacoes = new OperacoesPessoaJuridica(
                new PessoaJuridicaAppService(
                    new PessoaJuridicaORMDao(db), db));

            ConfigurarPainelRegistros();
        }

        public void AtualizarFuncionarioConectado(string nomeFuncionario)
        {
            if(nomeFuncionario == "Rech")
                labelFuncionarioConectado.Text = $"{nomeFuncionario} : Admin";
            else
                labelFuncionarioConectado.Text = $"{nomeFuncionario} : Funcionário";
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

        private void btnExibirInformacoes_Click(object sender, EventArgs e)
        {
            operacoes.ExibirInformacoesDetalhadas();
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
            configuracoes = new ConfiguracaoGrupoAutomovelToolBox();

            ConfigurarTooltips(configuracoes.Tooltip);
            ConfigurarBotoes(configuracoes.Botoes);

            AtualizarRodape(configuracoes.Tooltip.TipoCadastro);
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            DBLocadoraContext context = new();

            GrupoAutomovelAppService controlador = new(
                new GrupoAutomovelORMDao(context), 
                context);

            operacoes = new OperacoesGrupoAutomovel(controlador);

            ConfigurarPainelRegistros();
        }

        private void menuItemTaxasEServicos_Click(object sender, EventArgs e)
        {
            configuracoes = new ConfiguracaoTaxasEServicoToolBox();

            ConfigurarTooltips(configuracoes.Tooltip);
            ConfigurarBotoes(configuracoes.Botoes);

            AtualizarRodape(configuracoes.Tooltip.TipoCadastro);
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            operacoes = operacoesTaxasEServicos;

            ConfigurarPainelRegistros();
        }
        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoes = new ConfiguracaoConfiguracoesToolBox();

            ConfigurarTooltips(configuracoes.Tooltip);
            ConfigurarBotoes(configuracoes.Botoes);

            AtualizarRodape(configuracoes.Tooltip.TipoCadastro);
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            operacoes = operacoesConfiguracoes;

            ConfigurarPainelRegistros();
        }

        private void automovelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoes = new ConfiguracaoAutomovelTooBox();

            ConfigurarTooltips(configuracoes.Tooltip);
            ConfigurarBotoes(configuracoes.Botoes);

            AtualizarRodape(configuracoes.Tooltip.TipoCadastro);

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

        private void pessoasFísicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoes = new ConfiguracaoPessoaFisicaToolBox();

            ConfigurarTooltips(configuracoes.Tooltip);
            ConfigurarBotoes(configuracoes.Botoes);

            AtualizarRodape(configuracoes.Tooltip.TipoCadastro);

            operacoes = operacoesPessoaFisica;

            ConfigurarPainelRegistros();
        }        

        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoes = new ConfiguracaoTaxasEServicoToolBox();

            ConfigurarTooltips(configuracoes.Tooltip);
            ConfigurarBotoes(configuracoes.Botoes);

            AtualizarRodape(configuracoes.Tooltip.TipoCadastro);
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            operacoes = operacoesTaxasEServicos;

            ConfigurarPainelRegistros();
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoes = new ConfiguacaoFuncionarioToolBox();

            ConfigurarTooltips(configuracoes.Tooltip);
            ConfigurarBotoes(configuracoes.Botoes);

            AtualizarRodape(configuracoes.Tooltip.TipoCadastro);
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            operacoes = operacoesFuncionario;

            ConfigurarPainelRegistros();
        }
        private void locaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoes = new ConfiguracaoLocacaoToolBox();

            ConfigurarTooltips(configuracoes.Tooltip);
            ConfigurarBotoes(configuracoes.Botoes);

            AtualizarRodape(configuracoes.Tooltip.TipoCadastro);
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            operacoes = operacoesLocacao;

            ConfigurarPainelRegistros();
        }

        private void parceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoes = new ConfiguracaoParceiroToolBox();

            ConfigurarTooltips(configuracoes.Tooltip);
            ConfigurarBotoes(configuracoes.Botoes);

            AtualizarRodape(configuracoes.Tooltip.TipoCadastro);
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            DBLocadoraContext context = new();

            ParceiroAppService controlador = new ParceiroAppService(
                    new ParceiroORMDao(context), 
                    context
                );

            operacoes = new OperacoesParceiro(controlador);

            ConfigurarPainelRegistros();
        }

        private void cuponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoes = new ConfiguracaoCupomToolBox();

            ConfigurarTooltips(configuracoes.Tooltip);
            ConfigurarBotoes(configuracoes.Botoes);

            AtualizarRodape(configuracoes.Tooltip.TipoCadastro);
            AtualizarFuncionarioConectado(funcionarioConectado.Nome);

            DBLocadoraContext context = new();

            CupomAppService controlador = new(
                new CupomORMDao(context),
                context
            );

            ParceiroAppService controladorParceiro = new ParceiroAppService(
                new ParceiroORMDao(context),
                context
            );

            operacoes = new OperacoesCupons(controlador, controladorParceiro);

            ConfigurarPainelRegistros();
        }

        public void panelRegistros_Click(object sender, EventArgs e)
        {
            if (panelRegistros.Controls.Count == 0)
                return;

            if (panelRegistros.Controls[0] is TabelaLocacaoControl)
            {
                bool estaDevolvido = operacoesLocacao.RegistroSelecionadoEstaDevolvido();

                if (estaDevolvido)
                {
                    btnExcluir.Visible = true;
                    btnEditar.Enabled = false;
                    btnDevolverAutomovel.Visible = false;
                } 
                else
                {
                    btnExcluir.Visible = false;
                    btnEditar.Enabled = true;
                    btnDevolverAutomovel.Visible =  btnDevolverAutomovel.Enabled = true;
                }
            } 
            else
            {
                btnExcluir.Visible = true;
                btnDevolverAutomovel.Visible = false;

                if (configuracoes != null)
                    ConfigurarBotoes(configuracoes.Botoes);
            }
        }

        

        private void btnDevolverAutomovel_Click(object sender, EventArgs e)
        {
            (operacoes as OperacoesLocacao).DevolverRegistro();
        }

        private void panelRegistros_ControlAdded(object sender, ControlEventArgs e)
        {
            panelRegistros_Click(sender, e);
        }

        
    }
}
