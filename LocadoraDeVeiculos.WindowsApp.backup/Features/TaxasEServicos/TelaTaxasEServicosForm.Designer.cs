
namespace LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos
{
    partial class TelaTaxasEServicosForm
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
            this.labelId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.labelPreco = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.labelTipoDeTaxa = new System.Windows.Forms.Label();
            this.rdbTaxaFixa = new System.Windows.Forms.RadioButton();
            this.rdbTaxaPorDia = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.groupBoxTipoDeTaxa = new System.Windows.Forms.GroupBox();
            this.labelRS = new System.Windows.Forms.Label();
            this.groupBoxTipoDeTaxa.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(30, 12);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(22, 13);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Id: ";
            // 
            // txtId
            // 
            this.txtId.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtId.BackColor = System.Drawing.Color.LightGreen;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(58, 9);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(108, 20);
            this.txtId.TabIndex = 0;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(11, 38);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(41, 13);
            this.labelNome.TabIndex = 2;
            this.labelNome.Text = "Nome: ";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(58, 35);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(108, 20);
            this.txtNome.TabIndex = 1;
            // 
            // labelPreco
            // 
            this.labelPreco.AutoSize = true;
            this.labelPreco.Location = new System.Drawing.Point(11, 61);
            this.labelPreco.Name = "labelPreco";
            this.labelPreco.Size = new System.Drawing.Size(41, 13);
            this.labelPreco.TabIndex = 5;
            this.labelPreco.Text = "Preço: ";
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(58, 61);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(108, 20);
            this.txtPreco.TabIndex = 2;
            // 
            // labelTipoDeTaxa
            // 
            this.labelTipoDeTaxa.AutoSize = true;
            this.labelTipoDeTaxa.Location = new System.Drawing.Point(11, 94);
            this.labelTipoDeTaxa.Name = "labelTipoDeTaxa";
            this.labelTipoDeTaxa.Size = new System.Drawing.Size(0, 13);
            this.labelTipoDeTaxa.TabIndex = 7;
            // 
            // rdbTaxaFixa
            // 
            this.rdbTaxaFixa.AutoSize = true;
            this.rdbTaxaFixa.Location = new System.Drawing.Point(6, 16);
            this.rdbTaxaFixa.Name = "rdbTaxaFixa";
            this.rdbTaxaFixa.Size = new System.Drawing.Size(107, 17);
            this.rdbTaxaFixa.TabIndex = 3;
            this.rdbTaxaFixa.TabStop = true;
            this.rdbTaxaFixa.Text = "Cobrado taxa fixa";
            this.rdbTaxaFixa.UseVisualStyleBackColor = true;
            // 
            // rdbTaxaPorDia
            // 
            this.rdbTaxaPorDia.AutoSize = true;
            this.rdbTaxaPorDia.Location = new System.Drawing.Point(6, 39);
            this.rdbTaxaPorDia.Name = "rdbTaxaPorDia";
            this.rdbTaxaPorDia.Size = new System.Drawing.Size(123, 17);
            this.rdbTaxaPorDia.TabIndex = 4;
            this.rdbTaxaPorDia.TabStop = true;
            this.rdbTaxaPorDia.Text = "Cobrado taxa por dia";
            this.rdbTaxaPorDia.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(175, 223);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(253, 223);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 8;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // groupBoxTipoDeTaxa
            // 
            this.groupBoxTipoDeTaxa.Controls.Add(this.rdbTaxaPorDia);
            this.groupBoxTipoDeTaxa.Controls.Add(this.rdbTaxaFixa);
            this.groupBoxTipoDeTaxa.Location = new System.Drawing.Point(12, 94);
            this.groupBoxTipoDeTaxa.Name = "groupBoxTipoDeTaxa";
            this.groupBoxTipoDeTaxa.Size = new System.Drawing.Size(149, 68);
            this.groupBoxTipoDeTaxa.TabIndex = 12;
            this.groupBoxTipoDeTaxa.TabStop = false;
            this.groupBoxTipoDeTaxa.Text = "Tipo de cobrança da taxa";
            // 
            // labelRS
            // 
            this.labelRS.AutoSize = true;
            this.labelRS.Location = new System.Drawing.Point(172, 68);
            this.labelRS.Name = "labelRS";
            this.labelRS.Size = new System.Drawing.Size(21, 13);
            this.labelRS.TabIndex = 13;
            this.labelRS.Text = "R$";
            // 
            // TelaTaxasEServicosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 258);
            this.Controls.Add(this.labelRS);
            this.Controls.Add(this.groupBoxTipoDeTaxa);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.labelTipoDeTaxa);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.labelPreco);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.labelId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaTaxasEServicosForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Taxas e Serviços";
            this.groupBoxTipoDeTaxa.ResumeLayout(false);
            this.groupBoxTipoDeTaxa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label labelPreco;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label labelTipoDeTaxa;
        private System.Windows.Forms.RadioButton rdbTaxaFixa;
        private System.Windows.Forms.RadioButton rdbTaxaPorDia;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.GroupBox groupBoxTipoDeTaxa;
        private System.Windows.Forms.Label labelRS;
    }
}