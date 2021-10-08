
using System.Linq;

namespace LocadoraDeVeiculos.WindowsApp.Features.LocacaoModule
{
    partial class TelaDevolucaoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCaucao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKmInicial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rdb100 = new System.Windows.Forms.RadioButton();
            this.rdb75 = new System.Windows.Forms.RadioButton();
            this.rdb50 = new System.Windows.Forms.RadioButton();
            this.rdb25 = new System.Windows.Forms.RadioButton();
            this.rdb0 = new System.Windows.Forms.RadioButton();
            this.rdb92 = new System.Windows.Forms.RadioButton();
            this.rdb83 = new System.Windows.Forms.RadioButton();
            this.rdb67 = new System.Windows.Forms.RadioButton();
            this.rdb58 = new System.Windows.Forms.RadioButton();
            this.rdb42 = new System.Windows.Forms.RadioButton();
            this.rdb33 = new System.Windows.Forms.RadioButton();
            this.rdb17 = new System.Windows.Forms.RadioButton();
            this.rdb8 = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.seletorTaxasEServicosControl1 = new LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos.SeletorTaxasEServicosControl();
            this.txtKmAtual = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPlano = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtDataDevEsperada = new System.Windows.Forms.TextBox();
            this.txtDataSaida = new System.Windows.Forms.TextBox();
            this.txtAutomovel = new System.Windows.Forms.TextBox();
            this.txtCondutor = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCupom = new System.Windows.Forms.Button();
            this.labelCupom = new System.Windows.Forms.Label();
            this.txtCupom = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Condutor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Automovel:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data de saída:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data dev.\r\nesperada:";
            // 
            // txtCaucao
            // 
            this.txtCaucao.BackColor = System.Drawing.Color.LightGreen;
            this.txtCaucao.Enabled = false;
            this.txtCaucao.Location = new System.Drawing.Point(90, 14);
            this.txtCaucao.Name = "txtCaucao";
            this.txtCaucao.Size = new System.Drawing.Size(213, 20);
            this.txtCaucao.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Caução:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Plano:";
            // 
            // txtKmInicial
            // 
            this.txtKmInicial.BackColor = System.Drawing.Color.LightGreen;
            this.txtKmInicial.Enabled = false;
            this.txtKmInicial.Location = new System.Drawing.Point(90, 73);
            this.txtKmInicial.Name = "txtKmInicial";
            this.txtKmInicial.Size = new System.Drawing.Size(213, 20);
            this.txtKmInicial.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 26);
            this.label9.TabIndex = 16;
            this.label9.Text = "Quilometragem\r\ninicial:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 26);
            this.label10.TabIndex = 17;
            this.label10.Text = "Nível de\r\ngasolina:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LocadoraDeVeiculos.WindowsApp.Properties.Resources.pngwing_com_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(74, 259);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(244, 218);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // rdb100
            // 
            this.rdb100.AccessibleDescription = "100";
            this.rdb100.AutoSize = true;
            this.rdb100.Checked = true;
            this.rdb100.Location = new System.Drawing.Point(199, 259);
            this.rdb100.Name = "rdb100";
            this.rdb100.Size = new System.Drawing.Size(14, 13);
            this.rdb100.TabIndex = 4;
            this.rdb100.TabStop = true;
            this.rdb100.UseVisualStyleBackColor = true;
            // 
            // rdb75
            // 
            this.rdb75.AccessibleDescription = "75";
            this.rdb75.AutoSize = true;
            this.rdb75.Location = new System.Drawing.Point(246, 299);
            this.rdb75.Name = "rdb75";
            this.rdb75.Size = new System.Drawing.Size(14, 13);
            this.rdb75.TabIndex = 7;
            this.rdb75.UseVisualStyleBackColor = true;
            // 
            // rdb50
            // 
            this.rdb50.AccessibleDescription = "50";
            this.rdb50.AutoSize = true;
            this.rdb50.Location = new System.Drawing.Point(265, 361);
            this.rdb50.Name = "rdb50";
            this.rdb50.Size = new System.Drawing.Size(14, 13);
            this.rdb50.TabIndex = 10;
            this.rdb50.UseVisualStyleBackColor = true;
            // 
            // rdb25
            // 
            this.rdb25.AccessibleDescription = "25";
            this.rdb25.AutoSize = true;
            this.rdb25.Location = new System.Drawing.Point(248, 424);
            this.rdb25.Name = "rdb25";
            this.rdb25.Size = new System.Drawing.Size(14, 13);
            this.rdb25.TabIndex = 13;
            this.rdb25.UseVisualStyleBackColor = true;
            // 
            // rdb0
            // 
            this.rdb0.AccessibleDescription = "0";
            this.rdb0.AutoSize = true;
            this.rdb0.Location = new System.Drawing.Point(199, 464);
            this.rdb0.Name = "rdb0";
            this.rdb0.Size = new System.Drawing.Size(14, 13);
            this.rdb0.TabIndex = 16;
            this.rdb0.UseVisualStyleBackColor = true;
            // 
            // rdb92
            // 
            this.rdb92.AccessibleDescription = "92";
            this.rdb92.AutoSize = true;
            this.rdb92.Location = new System.Drawing.Point(218, 269);
            this.rdb92.Name = "rdb92";
            this.rdb92.Size = new System.Drawing.Size(14, 13);
            this.rdb92.TabIndex = 5;
            this.rdb92.UseVisualStyleBackColor = true;
            // 
            // rdb83
            // 
            this.rdb83.AccessibleDescription = "83";
            this.rdb83.AutoSize = true;
            this.rdb83.Location = new System.Drawing.Point(232, 284);
            this.rdb83.Name = "rdb83";
            this.rdb83.Size = new System.Drawing.Size(14, 13);
            this.rdb83.TabIndex = 6;
            this.rdb83.UseVisualStyleBackColor = true;
            // 
            // rdb67
            // 
            this.rdb67.AccessibleDescription = "67";
            this.rdb67.AutoSize = true;
            this.rdb67.Location = new System.Drawing.Point(257, 318);
            this.rdb67.Name = "rdb67";
            this.rdb67.Size = new System.Drawing.Size(14, 13);
            this.rdb67.TabIndex = 8;
            this.rdb67.UseVisualStyleBackColor = true;
            // 
            // rdb58
            // 
            this.rdb58.AccessibleDescription = "58";
            this.rdb58.AutoSize = true;
            this.rdb58.Location = new System.Drawing.Point(263, 339);
            this.rdb58.Name = "rdb58";
            this.rdb58.Size = new System.Drawing.Size(14, 13);
            this.rdb58.TabIndex = 9;
            this.rdb58.UseVisualStyleBackColor = true;
            // 
            // rdb42
            // 
            this.rdb42.AccessibleDescription = "42";
            this.rdb42.AutoSize = true;
            this.rdb42.Location = new System.Drawing.Point(263, 383);
            this.rdb42.Name = "rdb42";
            this.rdb42.Size = new System.Drawing.Size(14, 13);
            this.rdb42.TabIndex = 11;
            this.rdb42.UseVisualStyleBackColor = true;
            // 
            // rdb33
            // 
            this.rdb33.AccessibleDescription = "33";
            this.rdb33.AutoSize = true;
            this.rdb33.Location = new System.Drawing.Point(258, 404);
            this.rdb33.Name = "rdb33";
            this.rdb33.Size = new System.Drawing.Size(14, 13);
            this.rdb33.TabIndex = 12;
            this.rdb33.UseVisualStyleBackColor = true;
            // 
            // rdb17
            // 
            this.rdb17.AccessibleDescription = "17";
            this.rdb17.AutoSize = true;
            this.rdb17.Location = new System.Drawing.Point(233, 441);
            this.rdb17.Name = "rdb17";
            this.rdb17.Size = new System.Drawing.Size(14, 13);
            this.rdb17.TabIndex = 14;
            this.rdb17.UseVisualStyleBackColor = true;
            // 
            // rdb8
            // 
            this.rdb8.AccessibleDescription = "8";
            this.rdb8.AutoSize = true;
            this.rdb8.Location = new System.Drawing.Point(218, 455);
            this.rdb8.Name = "rdb8";
            this.rdb8.Size = new System.Drawing.Size(14, 13);
            this.rdb8.TabIndex = 15;
            this.rdb8.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(172, 491);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGravar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(253, 491);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 33;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 241);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fechamento de Locação";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(317, 216);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.seletorTaxasEServicosControl1);
            this.tabPage2.Controls.Add(this.txtKmAtual);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtPlano);
            this.tabPage2.Controls.Add(this.txtCaucao);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtKmInicial);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(309, 190);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inf. Adicionais";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // seletorTaxasEServicosControl1
            // 
            this.seletorTaxasEServicosControl1.Location = new System.Drawing.Point(10, 131);
            this.seletorTaxasEServicosControl1.Name = "seletorTaxasEServicosControl1";
            this.seletorTaxasEServicosControl1.Size = new System.Drawing.Size(293, 48);
            this.seletorTaxasEServicosControl1.TabIndex = 3;
            this.seletorTaxasEServicosControl1.TaxasEServicos = null;
            this.seletorTaxasEServicosControl1.TaxasEServicosSelecionados = new LocadoraDeVeiculos.Dominio.TaxasEServicosModule.TaxaEServico[0].ToList();
            // 
            // txtKmAtual
            // 
            this.txtKmAtual.BackColor = System.Drawing.SystemColors.Window;
            this.txtKmAtual.Location = new System.Drawing.Point(90, 105);
            this.txtKmAtual.Name = "txtKmAtual";
            this.txtKmAtual.Size = new System.Drawing.Size(213, 20);
            this.txtKmAtual.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 26);
            this.label6.TabIndex = 36;
            this.label6.Text = "Quilometragem\r\natual:";
            // 
            // txtPlano
            // 
            this.txtPlano.BackColor = System.Drawing.Color.LightGreen;
            this.txtPlano.Enabled = false;
            this.txtPlano.Location = new System.Drawing.Point(90, 40);
            this.txtPlano.Name = "txtPlano";
            this.txtPlano.Size = new System.Drawing.Size(213, 20);
            this.txtPlano.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtDataDevEsperada);
            this.tabPage1.Controls.Add(this.txtDataSaida);
            this.tabPage1.Controls.Add(this.txtAutomovel);
            this.tabPage1.Controls.Add(this.txtCondutor);
            this.tabPage1.Controls.Add(this.txtId);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(309, 190);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inf. Básicas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtDataDevEsperada
            // 
            this.txtDataDevEsperada.BackColor = System.Drawing.Color.LightGreen;
            this.txtDataDevEsperada.Enabled = false;
            this.txtDataDevEsperada.Location = new System.Drawing.Point(96, 129);
            this.txtDataDevEsperada.Name = "txtDataDevEsperada";
            this.txtDataDevEsperada.Size = new System.Drawing.Size(207, 20);
            this.txtDataDevEsperada.TabIndex = 21;
            // 
            // txtDataSaida
            // 
            this.txtDataSaida.BackColor = System.Drawing.Color.LightGreen;
            this.txtDataSaida.Enabled = false;
            this.txtDataSaida.Location = new System.Drawing.Point(96, 98);
            this.txtDataSaida.Name = "txtDataSaida";
            this.txtDataSaida.Size = new System.Drawing.Size(207, 20);
            this.txtDataSaida.TabIndex = 20;
            // 
            // txtAutomovel
            // 
            this.txtAutomovel.BackColor = System.Drawing.Color.LightGreen;
            this.txtAutomovel.Enabled = false;
            this.txtAutomovel.Location = new System.Drawing.Point(96, 70);
            this.txtAutomovel.Name = "txtAutomovel";
            this.txtAutomovel.Size = new System.Drawing.Size(207, 20);
            this.txtAutomovel.TabIndex = 19;
            // 
            // txtCondutor
            // 
            this.txtCondutor.BackColor = System.Drawing.Color.LightGreen;
            this.txtCondutor.Enabled = false;
            this.txtCondutor.Location = new System.Drawing.Point(96, 43);
            this.txtCondutor.Name = "txtCondutor";
            this.txtCondutor.Size = new System.Drawing.Size(207, 20);
            this.txtCondutor.TabIndex = 18;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.LightGreen;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(96, 17);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(207, 20);
            this.txtId.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(71, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Id:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCupom);
            this.tabPage3.Controls.Add(this.labelCupom);
            this.tabPage3.Controls.Add(this.txtCupom);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(309, 190);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Cupom";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCupom
            // 
            this.btnCupom.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCupom.Location = new System.Drawing.Point(205, 41);
            this.btnCupom.Name = "btnCupom";
            this.btnCupom.Size = new System.Drawing.Size(100, 28);
            this.btnCupom.TabIndex = 38;
            this.btnCupom.Text = "Validar Cupom";
            this.btnCupom.UseVisualStyleBackColor = false;
            this.btnCupom.Click += new System.EventHandler(this.btnCupom_Click);
            // 
            // labelCupom
            // 
            this.labelCupom.Location = new System.Drawing.Point(16, 12);
            this.labelCupom.Name = "labelCupom";
            this.labelCupom.Size = new System.Drawing.Size(43, 17);
            this.labelCupom.TabIndex = 37;
            this.labelCupom.Text = "Cupom:";
            // 
            // txtCupom
            // 
            this.txtCupom.Location = new System.Drawing.Point(65, 15);
            this.txtCupom.Name = "txtCupom";
            this.txtCupom.Size = new System.Drawing.Size(240, 20);
            this.txtCupom.TabIndex = 36;
            // 
            // TelaDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 526);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.rdb8);
            this.Controls.Add(this.rdb17);
            this.Controls.Add(this.rdb33);
            this.Controls.Add(this.rdb42);
            this.Controls.Add(this.rdb58);
            this.Controls.Add(this.rdb67);
            this.Controls.Add(this.rdb83);
            this.Controls.Add(this.rdb92);
            this.Controls.Add(this.rdb0);
            this.Controls.Add(this.rdb25);
            this.Controls.Add(this.rdb50);
            this.Controls.Add(this.rdb75);
            this.Controls.Add(this.rdb100);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaDevolucaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução de Automóvel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCaucao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKmInicial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rdb100;
        private System.Windows.Forms.RadioButton rdb75;
        private System.Windows.Forms.RadioButton rdb50;
        private System.Windows.Forms.RadioButton rdb25;
        private System.Windows.Forms.RadioButton rdb0;
        private System.Windows.Forms.RadioButton rdb92;
        private System.Windows.Forms.RadioButton rdb83;
        private System.Windows.Forms.RadioButton rdb67;
        private System.Windows.Forms.RadioButton rdb58;
        private System.Windows.Forms.RadioButton rdb42;
        private System.Windows.Forms.RadioButton rdb33;
        private System.Windows.Forms.RadioButton rdb17;
        private System.Windows.Forms.RadioButton rdb8;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtDataDevEsperada;
        private System.Windows.Forms.TextBox txtDataSaida;
        private System.Windows.Forms.TextBox txtAutomovel;
        private System.Windows.Forms.TextBox txtCondutor;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPlano;
        private TaxasEServicos.SeletorTaxasEServicosControl seletorTaxasEServicosControl1;
        private System.Windows.Forms.TextBox txtKmAtual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnCupom;
        private System.Windows.Forms.Label labelCupom;
        private System.Windows.Forms.TextBox txtCupom;
    }
}