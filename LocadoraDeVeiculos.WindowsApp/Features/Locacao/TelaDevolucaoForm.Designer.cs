
namespace LocadoraDeVeiculos.WindowsApp.Features.Locacao
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
            this.cmbCondutor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAutomovel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTPSaida = new System.Windows.Forms.DateTimePicker();
            this.dateTPDevolucaoEsperada = new System.Windows.Forms.DateTimePicker();
            this.dateTPDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSeguro = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCaucao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPlano = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKmPercorrida = new System.Windows.Forms.TextBox();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Condutor:";
            // 
            // cmbCondutor
            // 
            this.cmbCondutor.BackColor = System.Drawing.SystemColors.Window;
            this.cmbCondutor.Enabled = false;
            this.cmbCondutor.Location = new System.Drawing.Point(96, 15);
            this.cmbCondutor.Name = "cmbCondutor";
            this.cmbCondutor.Size = new System.Drawing.Size(207, 21);
            this.cmbCondutor.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Automovel:";
            // 
            // cmbAutomovel
            // 
            this.cmbAutomovel.BackColor = System.Drawing.SystemColors.Window;
            this.cmbAutomovel.Enabled = false;
            this.cmbAutomovel.Location = new System.Drawing.Point(96, 42);
            this.cmbAutomovel.Name = "cmbAutomovel";
            this.cmbAutomovel.Size = new System.Drawing.Size(207, 21);
            this.cmbAutomovel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data de saída:";
            // 
            // dateTPSaida
            // 
            this.dateTPSaida.CalendarTitleForeColor = System.Drawing.Color.LightGreen;
            this.dateTPSaida.Enabled = false;
            this.dateTPSaida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPSaida.Location = new System.Drawing.Point(96, 69);
            this.dateTPSaida.Name = "dateTPSaida";
            this.dateTPSaida.Size = new System.Drawing.Size(207, 20);
            this.dateTPSaida.TabIndex = 4;
            this.dateTPSaida.Value = new System.DateTime(2021, 8, 17, 0, 0, 0, 0);
            // 
            // dateTPDevolucaoEsperada
            // 
            this.dateTPDevolucaoEsperada.Checked = false;
            this.dateTPDevolucaoEsperada.Enabled = false;
            this.dateTPDevolucaoEsperada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPDevolucaoEsperada.Location = new System.Drawing.Point(96, 99);
            this.dateTPDevolucaoEsperada.Name = "dateTPDevolucaoEsperada";
            this.dateTPDevolucaoEsperada.Size = new System.Drawing.Size(207, 20);
            this.dateTPDevolucaoEsperada.TabIndex = 5;
            this.dateTPDevolucaoEsperada.Value = new System.DateTime(2021, 8, 17, 0, 0, 0, 0);
            // 
            // dateTPDevolucao
            // 
            this.dateTPDevolucao.Checked = false;
            this.dateTPDevolucao.Enabled = false;
            this.dateTPDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPDevolucao.Location = new System.Drawing.Point(96, 134);
            this.dateTPDevolucao.Name = "dateTPDevolucao";
            this.dateTPDevolucao.Size = new System.Drawing.Size(207, 20);
            this.dateTPDevolucao.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data dev.\r\nesperada:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "Data da\r\ndevolução:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cmbSeguro
            // 
            this.cmbSeguro.Location = new System.Drawing.Point(90, 16);
            this.cmbSeguro.Name = "cmbSeguro";
            this.cmbSeguro.Size = new System.Drawing.Size(213, 21);
            this.cmbSeguro.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Seguro:";
            // 
            // txtCaucao
            // 
            this.txtCaucao.Location = new System.Drawing.Point(90, 43);
            this.txtCaucao.Name = "txtCaucao";
            this.txtCaucao.Size = new System.Drawing.Size(213, 20);
            this.txtCaucao.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Caução:";
            // 
            // cmbPlano
            // 
            this.cmbPlano.Location = new System.Drawing.Point(90, 69);
            this.cmbPlano.Name = "cmbPlano";
            this.cmbPlano.Size = new System.Drawing.Size(213, 21);
            this.cmbPlano.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Plano:";
            // 
            // txtKmPercorrida
            // 
            this.txtKmPercorrida.Location = new System.Drawing.Point(90, 105);
            this.txtKmPercorrida.Name = "txtKmPercorrida";
            this.txtKmPercorrida.Size = new System.Drawing.Size(213, 20);
            this.txtKmPercorrida.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 26);
            this.label9.TabIndex = 16;
            this.label9.Text = "Quilometragem\r\npercorrida:";
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
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // rdb100
            // 
            this.rdb100.AutoSize = true;
            this.rdb100.Location = new System.Drawing.Point(199, 259);
            this.rdb100.Name = "rdb100";
            this.rdb100.Size = new System.Drawing.Size(14, 13);
            this.rdb100.TabIndex = 19;
            this.rdb100.TabStop = true;
            this.rdb100.UseVisualStyleBackColor = true;
            // 
            // rdb75
            // 
            this.rdb75.AutoSize = true;
            this.rdb75.Location = new System.Drawing.Point(246, 300);
            this.rdb75.Name = "rdb75";
            this.rdb75.Size = new System.Drawing.Size(14, 13);
            this.rdb75.TabIndex = 20;
            this.rdb75.TabStop = true;
            this.rdb75.UseVisualStyleBackColor = true;
            // 
            // rdb50
            // 
            this.rdb50.AutoSize = true;
            this.rdb50.Location = new System.Drawing.Point(265, 361);
            this.rdb50.Name = "rdb50";
            this.rdb50.Size = new System.Drawing.Size(14, 13);
            this.rdb50.TabIndex = 21;
            this.rdb50.UseVisualStyleBackColor = true;
            // 
            // rdb25
            // 
            this.rdb25.AutoSize = true;
            this.rdb25.Location = new System.Drawing.Point(248, 424);
            this.rdb25.Name = "rdb25";
            this.rdb25.Size = new System.Drawing.Size(14, 13);
            this.rdb25.TabIndex = 22;
            this.rdb25.UseVisualStyleBackColor = true;
            // 
            // rdb0
            // 
            this.rdb0.AutoSize = true;
            this.rdb0.Location = new System.Drawing.Point(199, 464);
            this.rdb0.Name = "rdb0";
            this.rdb0.Size = new System.Drawing.Size(14, 13);
            this.rdb0.TabIndex = 23;
            this.rdb0.TabStop = true;
            this.rdb0.UseVisualStyleBackColor = true;
            this.rdb0.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // rdb92
            // 
            this.rdb92.AutoSize = true;
            this.rdb92.Location = new System.Drawing.Point(218, 269);
            this.rdb92.Name = "rdb92";
            this.rdb92.Size = new System.Drawing.Size(14, 13);
            this.rdb92.TabIndex = 24;
            this.rdb92.TabStop = true;
            this.rdb92.UseVisualStyleBackColor = true;
            // 
            // rdb83
            // 
            this.rdb83.AutoSize = true;
            this.rdb83.Location = new System.Drawing.Point(232, 284);
            this.rdb83.Name = "rdb83";
            this.rdb83.Size = new System.Drawing.Size(14, 13);
            this.rdb83.TabIndex = 25;
            this.rdb83.TabStop = true;
            this.rdb83.UseVisualStyleBackColor = true;
            // 
            // rdb67
            // 
            this.rdb67.AutoSize = true;
            this.rdb67.Location = new System.Drawing.Point(257, 318);
            this.rdb67.Name = "rdb67";
            this.rdb67.Size = new System.Drawing.Size(14, 13);
            this.rdb67.TabIndex = 26;
            this.rdb67.UseVisualStyleBackColor = true;
            // 
            // rdb58
            // 
            this.rdb58.AutoSize = true;
            this.rdb58.Location = new System.Drawing.Point(263, 339);
            this.rdb58.Name = "rdb58";
            this.rdb58.Size = new System.Drawing.Size(14, 13);
            this.rdb58.TabIndex = 27;
            this.rdb58.UseVisualStyleBackColor = true;
            // 
            // rdb42
            // 
            this.rdb42.AutoSize = true;
            this.rdb42.Location = new System.Drawing.Point(263, 383);
            this.rdb42.Name = "rdb42";
            this.rdb42.Size = new System.Drawing.Size(14, 13);
            this.rdb42.TabIndex = 28;
            this.rdb42.UseVisualStyleBackColor = true;
            // 
            // rdb33
            // 
            this.rdb33.AutoSize = true;
            this.rdb33.Location = new System.Drawing.Point(258, 404);
            this.rdb33.Name = "rdb33";
            this.rdb33.Size = new System.Drawing.Size(14, 13);
            this.rdb33.TabIndex = 29;
            this.rdb33.UseVisualStyleBackColor = true;
            // 
            // rdb17
            // 
            this.rdb17.AutoSize = true;
            this.rdb17.Location = new System.Drawing.Point(233, 441);
            this.rdb17.Name = "rdb17";
            this.rdb17.Size = new System.Drawing.Size(14, 13);
            this.rdb17.TabIndex = 30;
            this.rdb17.TabStop = true;
            this.rdb17.UseVisualStyleBackColor = true;
            // 
            // rdb8
            // 
            this.rdb8.AutoSize = true;
            this.rdb8.Location = new System.Drawing.Point(218, 455);
            this.rdb8.Name = "rdb8";
            this.rdb8.Size = new System.Drawing.Size(14, 13);
            this.rdb8.TabIndex = 31;
            this.rdb8.TabStop = true;
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(317, 204);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbCondutor);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbAutomovel);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dateTPSaida);
            this.tabPage1.Controls.Add(this.dateTPDevolucaoEsperada);
            this.tabPage1.Controls.Add(this.dateTPDevolucao);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(309, 178);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inf. Básicas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmbSeguro);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtCaucao);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cmbPlano);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtKmPercorrida);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(309, 178);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inf. Adicionais";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.Text = "Devolução de Automóvel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCondutor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAutomovel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTPSaida;
        private System.Windows.Forms.DateTimePicker dateTPDevolucaoEsperada;
        private System.Windows.Forms.DateTimePicker dateTPDevolucao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSeguro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCaucao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPlano;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKmPercorrida;
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
    }
}