
namespace LocadoraDeVeiculos.WindowsApp.Features.Cupons
{
    partial class TelaCupomForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtValorMinimo = new System.Windows.Forms.TextBox();
            this.cmbParceiro = new System.Windows.Forms.ComboBox();
            this.dtpDataVencimento = new System.Windows.Forms.DateTimePicker();
            this.btnGravar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtQtdUsos = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parceiro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Valor mínimo\r\n da Locação";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "     Data de\r\nVencimento";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(86, 54);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(242, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Porcentagem",
            "Reais"});
            this.cmbTipo.Location = new System.Drawing.Point(86, 87);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(242, 21);
            this.cmbTipo.TabIndex = 1;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(86, 121);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(242, 20);
            this.txtValor.TabIndex = 2;
            // 
            // txtValorMinimo
            // 
            this.txtValorMinimo.Location = new System.Drawing.Point(86, 154);
            this.txtValorMinimo.Name = "txtValorMinimo";
            this.txtValorMinimo.Size = new System.Drawing.Size(242, 20);
            this.txtValorMinimo.TabIndex = 3;
            // 
            // cmbParceiro
            // 
            this.cmbParceiro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParceiro.FormattingEnabled = true;
            this.cmbParceiro.Location = new System.Drawing.Point(86, 187);
            this.cmbParceiro.Name = "cmbParceiro";
            this.cmbParceiro.Size = new System.Drawing.Size(242, 21);
            this.cmbParceiro.TabIndex = 4;
            // 
            // dtpDataVencimento
            // 
            this.dtpDataVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataVencimento.Location = new System.Drawing.Point(86, 221);
            this.dtpDataVencimento.Name = "dtpDataVencimento";
            this.dtpDataVencimento.Size = new System.Drawing.Size(242, 20);
            this.dtpDataVencimento.TabIndex = 5;
            this.dtpDataVencimento.Value = new System.DateTime(2021, 8, 29, 19, 19, 57, 0);
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(253, 354);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 8;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(172, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.LightGreen;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(86, 21);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(242, 20);
            this.txtId.TabIndex = 11;
            // 
            // txtQtdUsos
            // 
            this.txtQtdUsos.BackColor = System.Drawing.Color.LightGreen;
            this.txtQtdUsos.Enabled = false;
            this.txtQtdUsos.Location = new System.Drawing.Point(86, 250);
            this.txtQtdUsos.Name = "txtQtdUsos";
            this.txtQtdUsos.Size = new System.Drawing.Size(242, 20);
            this.txtQtdUsos.TabIndex = 12;
            this.txtQtdUsos.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 26);
            this.label8.TabIndex = 13;
            this.label8.Text = "Quantidade \r\n     de usos";
            // 
            // TelaCupomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 389);
            this.Controls.Add(this.txtQtdUsos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpDataVencimento);
            this.Controls.Add(this.cmbParceiro);
            this.Controls.Add(this.txtValorMinimo);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCupomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Cupons";
            this.Load += new System.EventHandler(this.TelaCupomForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtValorMinimo;
        private System.Windows.Forms.ComboBox cmbParceiro;
        private System.Windows.Forms.DateTimePicker dtpDataVencimento;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtQtdUsos;
        private System.Windows.Forms.Label label8;
    }
}