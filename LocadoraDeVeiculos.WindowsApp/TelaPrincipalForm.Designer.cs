
namespace LocadoraDeVeiculos.WindowsApp
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.locaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PessoasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pessoaJuridicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pessoaFisicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutomoveisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGrupoAutomovel = new System.Windows.Forms.ToolStripMenuItem();
            this.automovelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTaxasEServicos = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cupomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parceirosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuponsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolboxAcoes = new System.Windows.Forms.ToolStrip();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.btnDevolverAutomovel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgrupar = new System.Windows.Forms.ToolStripButton();
            this.btnDesagrupar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExibirInformacoes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.labelFuncionarioConectado = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.toolboxAcoes.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locaçõesToolStripMenuItem,
            this.funcionáriosToolStripMenuItem,
            this.PessoasToolStripMenuItem,
            this.AutomoveisToolStripMenuItem,
            this.menuItemTaxasEServicos,
            this.cupomToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(682, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // locaçõesToolStripMenuItem
            // 
            this.locaçõesToolStripMenuItem.Name = "locaçõesToolStripMenuItem";
            this.locaçõesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.locaçõesToolStripMenuItem.Text = "Locações";
            this.locaçõesToolStripMenuItem.Click += new System.EventHandler(this.locaçõesToolStripMenuItem_Click);
            // 
            // funcionáriosToolStripMenuItem
            // 
            this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.funcionáriosToolStripMenuItem.Text = "Funcionários";
            this.funcionáriosToolStripMenuItem.ToolTipText = "Cadastre funcionario (F1)";
            this.funcionáriosToolStripMenuItem.Click += new System.EventHandler(this.funcionarioToolStripMenuItem_Click);
            // 
            // PessoasToolStripMenuItem
            // 
            this.PessoasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pessoaJuridicaToolStripMenuItem,
            this.pessoaFisicaToolStripMenuItem});
            this.PessoasToolStripMenuItem.Name = "PessoasToolStripMenuItem";
            this.PessoasToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.PessoasToolStripMenuItem.Text = "Pessoas";
            this.PessoasToolStripMenuItem.ToolTipText = "Cadastre pessoas Fisicias e Juridicas";
            // 
            // pessoaJuridicaToolStripMenuItem
            // 
            this.pessoaJuridicaToolStripMenuItem.Name = "pessoaJuridicaToolStripMenuItem";
            this.pessoaJuridicaToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.pessoaJuridicaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.pessoaJuridicaToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.pessoaJuridicaToolStripMenuItem.Text = "Pessoa Juridica";
            this.pessoaJuridicaToolStripMenuItem.Click += new System.EventHandler(this.pessoaJuridicaToolStripMenuItem_Click);
            // 
            // pessoaFisicaToolStripMenuItem
            // 
            this.pessoaFisicaToolStripMenuItem.Name = "pessoaFisicaToolStripMenuItem";
            this.pessoaFisicaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.pessoaFisicaToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.pessoaFisicaToolStripMenuItem.Text = "Pessoa Física";
            this.pessoaFisicaToolStripMenuItem.Click += new System.EventHandler(this.pessoasFísicasToolStripMenuItem_Click);
            // 
            // AutomoveisToolStripMenuItem
            // 
            this.AutomoveisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemGrupoAutomovel,
            this.automovelToolStripMenuItem});
            this.AutomoveisToolStripMenuItem.Name = "AutomoveisToolStripMenuItem";
            this.AutomoveisToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.AutomoveisToolStripMenuItem.Text = "Automóveis";
            this.AutomoveisToolStripMenuItem.ToolTipText = "Cadastre Grupos de Automóveis e Automóveis";
            // 
            // menuItemGrupoAutomovel
            // 
            this.menuItemGrupoAutomovel.Name = "menuItemGrupoAutomovel";
            this.menuItemGrupoAutomovel.ShortcutKeyDisplayString = "";
            this.menuItemGrupoAutomovel.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menuItemGrupoAutomovel.Size = new System.Drawing.Size(204, 22);
            this.menuItemGrupoAutomovel.Text = "Grupo de Automovel";
            this.menuItemGrupoAutomovel.Click += new System.EventHandler(this.menuItemGrupoAutomovel_Click);
            // 
            // automovelToolStripMenuItem
            // 
            this.automovelToolStripMenuItem.Name = "automovelToolStripMenuItem";
            this.automovelToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.automovelToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.automovelToolStripMenuItem.Text = "Automóvel";
            this.automovelToolStripMenuItem.Click += new System.EventHandler(this.automovelToolStripMenuItem_Click);
            // 
            // menuItemTaxasEServicos
            // 
            this.menuItemTaxasEServicos.Name = "menuItemTaxasEServicos";
            this.menuItemTaxasEServicos.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuItemTaxasEServicos.Size = new System.Drawing.Size(102, 20);
            this.menuItemTaxasEServicos.Text = "Taxas e Serviços";
            this.menuItemTaxasEServicos.ToolTipText = "Cadastre Taxas e Serviços (F5)";
            this.menuItemTaxasEServicos.Click += new System.EventHandler(this.taxasEServiçosToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            this.configuraçõesToolStripMenuItem.ToolTipText = "Acesse as configurações do sistema (CTRL-C)";
            this.configuraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
            // 
            // cupomToolStripMenuItem
            // 
            this.cupomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parceirosToolStripMenuItem,
            this.cuponsToolStripMenuItem});
            this.cupomToolStripMenuItem.Name = "cupomToolStripMenuItem";
            this.cupomToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.cupomToolStripMenuItem.Text = "Cupons";
            // 
            // parceirosToolStripMenuItem
            // 
            this.parceirosToolStripMenuItem.Name = "parceirosToolStripMenuItem";
            this.parceirosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.parceirosToolStripMenuItem.Text = "Parceiro";
            this.parceirosToolStripMenuItem.Click += new System.EventHandler(this.parceirosToolStripMenuItem_Click);
            // 
            // cuponsToolStripMenuItem
            // 
            this.cuponsToolStripMenuItem.Name = "cuponsToolStripMenuItem";
            this.cuponsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cuponsToolStripMenuItem.Text = "Cupom";
            this.cuponsToolStripMenuItem.Click += new System.EventHandler(this.cuponsToolStripMenuItem_Click);
            // 
            // toolboxAcoes
            // 
            this.toolboxAcoes.AutoSize = false;
            this.toolboxAcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionar,
            this.btnEditar,
            this.btnExcluir,
            this.btnDevolverAutomovel,
            this.toolStripSeparator1,
            this.btnFiltrar,
            this.toolStripSeparator2,
            this.btnAgrupar,
            this.btnDesagrupar,
            this.toolStripSeparator4,
            this.btnExibirInformacoes,
            this.toolStripSeparator3,
            this.labelTipoCadastro});
            this.toolboxAcoes.Location = new System.Drawing.Point(0, 24);
            this.toolboxAcoes.Name = "toolboxAcoes";
            this.toolboxAcoes.Size = new System.Drawing.Size(682, 41);
            this.toolboxAcoes.TabIndex = 3;
            this.toolboxAcoes.Text = "toolStrip1";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.AccessibleName = "btnAdicionar";
            this.btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdicionar.Image = global::LocadoraDeVeiculos.WindowsApp.Properties.Resources.outline_add_circle_outline_black_24dp;
            this.btnAdicionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Padding = new System.Windows.Forms.Padding(5);
            this.btnAdicionar.Size = new System.Drawing.Size(38, 38);
            this.btnAdicionar.Text = "toolStripButton1";
            this.btnAdicionar.ToolTipText = "Selecione um cadastro!";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = global::LocadoraDeVeiculos.WindowsApp.Properties.Resources.outline_mode_edit_black_24dp;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(5);
            this.btnEditar.Size = new System.Drawing.Size(38, 38);
            this.btnEditar.Text = "toolStripButton1";
            this.btnEditar.ToolTipText = " Selecione um cadastro!";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcluir.Image = global::LocadoraDeVeiculos.WindowsApp.Properties.Resources.outline_delete_black_24dp;
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Padding = new System.Windows.Forms.Padding(5);
            this.btnExcluir.Size = new System.Drawing.Size(38, 38);
            this.btnExcluir.Text = "toolStripButton1";
            this.btnExcluir.ToolTipText = " Selecione um cadastro!";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnDevolverAutomovel
            // 
            this.btnDevolverAutomovel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDevolverAutomovel.Image = global::LocadoraDeVeiculos.WindowsApp.Properties.Resources.car_arrow_left;
            this.btnDevolverAutomovel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDevolverAutomovel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevolverAutomovel.Name = "btnDevolverAutomovel";
            this.btnDevolverAutomovel.Padding = new System.Windows.Forms.Padding(5);
            this.btnDevolverAutomovel.Size = new System.Drawing.Size(38, 38);
            this.btnDevolverAutomovel.Text = "toolStripButton1";
            this.btnDevolverAutomovel.ToolTipText = " Selecione um cadastro!";
            this.btnDevolverAutomovel.Visible = false;
            this.btnDevolverAutomovel.Click += new System.EventHandler(this.btnDevolverAutomovel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFiltrar.Image = global::LocadoraDeVeiculos.WindowsApp.Properties.Resources.outline_filter_alt_black_24dp;
            this.btnFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Padding = new System.Windows.Forms.Padding(5);
            this.btnFiltrar.Size = new System.Drawing.Size(38, 38);
            this.btnFiltrar.Text = "toolStripButton1";
            this.btnFiltrar.ToolTipText = "Selecione um cadastro!";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // btnAgrupar
            // 
            this.btnAgrupar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgrupar.Image = global::LocadoraDeVeiculos.WindowsApp.Properties.Resources.outline_compress_black_24dp;
            this.btnAgrupar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAgrupar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgrupar.Name = "btnAgrupar";
            this.btnAgrupar.Padding = new System.Windows.Forms.Padding(5);
            this.btnAgrupar.Size = new System.Drawing.Size(38, 38);
            this.btnAgrupar.Text = "toolStripButton1";
            this.btnAgrupar.ToolTipText = "Selecione um cadastro!";
            this.btnAgrupar.Click += new System.EventHandler(this.btnAgrupar_Click);
            // 
            // btnDesagrupar
            // 
            this.btnDesagrupar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDesagrupar.Image = global::LocadoraDeVeiculos.WindowsApp.Properties.Resources.outline_expand_black_24dp;
            this.btnDesagrupar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDesagrupar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDesagrupar.Name = "btnDesagrupar";
            this.btnDesagrupar.Padding = new System.Windows.Forms.Padding(5);
            this.btnDesagrupar.Size = new System.Drawing.Size(38, 38);
            this.btnDesagrupar.Text = "toolStripButton1";
            this.btnDesagrupar.ToolTipText = "Selecione um cadastro!";
            this.btnDesagrupar.Click += new System.EventHandler(this.btnDesagrupar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
            // 
            // btnExibirInformacoes
            // 
            this.btnExibirInformacoes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExibirInformacoes.Image = global::LocadoraDeVeiculos.WindowsApp.Properties.Resources.outline_info_black_24dp;
            this.btnExibirInformacoes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExibirInformacoes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExibirInformacoes.Name = "btnExibirInformacoes";
            this.btnExibirInformacoes.Padding = new System.Windows.Forms.Padding(5);
            this.btnExibirInformacoes.Size = new System.Drawing.Size(38, 38);
            this.btnExibirInformacoes.ToolTipText = "Selecione um cadastro!";
            this.btnExibirInformacoes.Click += new System.EventHandler(this.btnExibirInformacoes_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(174, 38);
            this.labelTipoCadastro.Text = "Cadastro Selecionado: Nenhum";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodape});
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(682, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(67, 17);
            this.labelRodape.Text = "Tudo Ok ;-)";
            // 
            // panelRegistros
            // 
            this.panelRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRegistros.Location = new System.Drawing.Point(12, 90);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(658, 356);
            this.panelRegistros.TabIndex = 5;
            this.panelRegistros.Click += new System.EventHandler(this.panelRegistros_Click);
            this.panelRegistros.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panelRegistros_ControlAdded);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelFuncionarioConectado});
            this.statusStrip2.Location = new System.Drawing.Point(0, 65);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(682, 22);
            this.statusStrip2.TabIndex = 6;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // labelFuncionarioConectado
            // 
            this.labelFuncionarioConectado.Name = "labelFuncionarioConectado";
            this.labelFuncionarioConectado.Size = new System.Drawing.Size(108, 17);
            this.labelFuncionarioConectado.Text = "Usuário Conectado";
            // 
            // TelaPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 471);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolboxAcoes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TelaPrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locadora De Veiculos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolboxAcoes.ResumeLayout(false);
            this.toolboxAcoes.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AutomoveisToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolboxAcoes;
        private System.Windows.Forms.ToolStripButton btnAdicionar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnDesagrupar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripButton btnFiltrar;
        private System.Windows.Forms.ToolStripButton btnAgrupar;
        private System.Windows.Forms.ToolStripMenuItem menuItemGrupoAutomovel;
        private System.Windows.Forms.ToolStripMenuItem pessoaJuridicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel labelFuncionarioConectado;
        private System.Windows.Forms.ToolStripButton btnExibirInformacoes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem automovelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pessoaFisicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PessoasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemTaxasEServicos;
        private System.Windows.Forms.ToolStripMenuItem funcionáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnDevolverAutomovel;
        private System.Windows.Forms.ToolStripMenuItem locaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cupomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parceirosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuponsToolStripMenuItem;
    }
}

