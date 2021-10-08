
using System.Linq;

namespace LocadoraDeVeiculos.WindowsApp.Features.LocacaoModule
{
    partial class TelaLocacaoForm
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
            this.labelCondutor = new System.Windows.Forms.Label();
            this.cmbCondutor = new System.Windows.Forms.ComboBox();
            this.labelAutomovel = new System.Windows.Forms.Label();
            this.cmbAutomovel = new System.Windows.Forms.ComboBox();
            this.labelDataSaida = new System.Windows.Forms.Label();
            this.dtpdataSaida = new System.Windows.Forms.DateTimePicker();
            this.labelDataEsperada = new System.Windows.Forms.Label();
            this.dtpdataDevolucaoEsperada = new System.Windows.Forms.DateTimePicker();
            this.labelCaucao = new System.Windows.Forms.Label();
            this.txtCaucao = new System.Windows.Forms.TextBox();
            this.labelReais = new System.Windows.Forms.Label();
            this.labelPlano = new System.Windows.Forms.Label();
            this.cmbPlano = new System.Windows.Forms.ComboBox();
            this.labelId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCupom = new System.Windows.Forms.TextBox();
            this.labelCupom = new System.Windows.Forms.Label();
            this.seletorTaxasEServicosControl1 = new LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos.SeletorTaxasEServicosControl();
            this.btnCupom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCondutor
            // 
            this.labelCondutor.Location = new System.Drawing.Point(61, 40);
            this.labelCondutor.Name = "labelCondutor";
            this.labelCondutor.Size = new System.Drawing.Size(53, 13);
            this.labelCondutor.TabIndex = 0;
            this.labelCondutor.Text = "Condutor:";
            // 
            // cmbCondutor
            // 
            this.cmbCondutor.FormattingEnabled = true;
            this.cmbCondutor.Location = new System.Drawing.Point(120, 35);
            this.cmbCondutor.Name = "cmbCondutor";
            this.cmbCondutor.Size = new System.Drawing.Size(184, 21);
            this.cmbCondutor.TabIndex = 1;
            // 
            // labelAutomovel
            // 
            this.labelAutomovel.Location = new System.Drawing.Point(54, 67);
            this.labelAutomovel.Name = "labelAutomovel";
            this.labelAutomovel.Size = new System.Drawing.Size(60, 13);
            this.labelAutomovel.TabIndex = 2;
            this.labelAutomovel.Text = "Automóvel:";
            // 
            // cmbAutomovel
            // 
            this.cmbAutomovel.FormattingEnabled = true;
            this.cmbAutomovel.Location = new System.Drawing.Point(120, 62);
            this.cmbAutomovel.Name = "cmbAutomovel";
            this.cmbAutomovel.Size = new System.Drawing.Size(184, 21);
            this.cmbAutomovel.TabIndex = 2;
            // 
            // labelDataSaida
            // 
            this.labelDataSaida.Location = new System.Drawing.Point(36, 97);
            this.labelDataSaida.Name = "labelDataSaida";
            this.labelDataSaida.Size = new System.Drawing.Size(78, 13);
            this.labelDataSaida.TabIndex = 4;
            this.labelDataSaida.Text = "Data de saída:";
            // 
            // dtpdataSaida
            // 
            this.dtpdataSaida.Enabled = false;
            this.dtpdataSaida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdataSaida.Location = new System.Drawing.Point(120, 90);
            this.dtpdataSaida.Name = "dtpdataSaida";
            this.dtpdataSaida.Size = new System.Drawing.Size(184, 20);
            this.dtpdataSaida.TabIndex = 3;
            this.dtpdataSaida.Value = new System.DateTime(2021, 8, 23, 0, 0, 0, 0);
            // 
            // labelDataEsperada
            // 
            this.labelDataEsperada.AutoSize = true;
            this.labelDataEsperada.Location = new System.Drawing.Point(34, 122);
            this.labelDataEsperada.Name = "labelDataEsperada";
            this.labelDataEsperada.Size = new System.Drawing.Size(80, 13);
            this.labelDataEsperada.TabIndex = 6;
            this.labelDataEsperada.Text = "Data esperada:";
            // 
            // dtpdataDevolucaoEsperada
            // 
            this.dtpdataDevolucaoEsperada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdataDevolucaoEsperada.Location = new System.Drawing.Point(120, 116);
            this.dtpdataDevolucaoEsperada.Name = "dtpdataDevolucaoEsperada";
            this.dtpdataDevolucaoEsperada.Size = new System.Drawing.Size(184, 20);
            this.dtpdataDevolucaoEsperada.TabIndex = 4;
            this.dtpdataDevolucaoEsperada.Value = new System.DateTime(2021, 8, 19, 0, 0, 0, 0);
            // 
            // labelCaucao
            // 
            this.labelCaucao.Location = new System.Drawing.Point(67, 147);
            this.labelCaucao.Name = "labelCaucao";
            this.labelCaucao.Size = new System.Drawing.Size(47, 13);
            this.labelCaucao.TabIndex = 10;
            this.labelCaucao.Text = "Caução:";
            // 
            // txtCaucao
            // 
            this.txtCaucao.Location = new System.Drawing.Point(120, 142);
            this.txtCaucao.Name = "txtCaucao";
            this.txtCaucao.Size = new System.Drawing.Size(184, 20);
            this.txtCaucao.TabIndex = 5;
            // 
            // labelReais
            // 
            this.labelReais.AutoSize = true;
            this.labelReais.Location = new System.Drawing.Point(307, 145);
            this.labelReais.Name = "labelReais";
            this.labelReais.Size = new System.Drawing.Size(21, 13);
            this.labelReais.TabIndex = 12;
            this.labelReais.Text = "R$";
            // 
            // labelPlano
            // 
            this.labelPlano.Location = new System.Drawing.Point(77, 175);
            this.labelPlano.Name = "labelPlano";
            this.labelPlano.Size = new System.Drawing.Size(37, 13);
            this.labelPlano.TabIndex = 13;
            this.labelPlano.Text = "Plano:";
            // 
            // cmbPlano
            // 
            this.cmbPlano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlano.FormattingEnabled = true;
            this.cmbPlano.Items.AddRange(new object[] {
            "Plano diário",
            "Plano Km controlado",
            "Plano Km livre"});
            this.cmbPlano.Location = new System.Drawing.Point(120, 170);
            this.cmbPlano.Name = "cmbPlano";
            this.cmbPlano.Size = new System.Drawing.Size(184, 21);
            this.cmbPlano.TabIndex = 6;
            // 
            // labelId
            // 
            this.labelId.Location = new System.Drawing.Point(93, 11);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(21, 13);
            this.labelId.TabIndex = 16;
            this.labelId.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.LightGreen;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(120, 7);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(184, 20);
            this.txtId.TabIndex = 0;
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(235, 285);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(93, 23);
            this.btnGravar.TabIndex = 9;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(136, 285);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // txtCupom
            // 
            this.txtCupom.Location = new System.Drawing.Point(120, 197);
            this.txtCupom.Name = "txtCupom";
            this.txtCupom.Size = new System.Drawing.Size(184, 20);
            this.txtCupom.TabIndex = 21;
            // 
            // labelCupom
            // 
            this.labelCupom.Location = new System.Drawing.Point(71, 200);
            this.labelCupom.Name = "labelCupom";
            this.labelCupom.Size = new System.Drawing.Size(43, 17);
            this.labelCupom.TabIndex = 22;
            this.labelCupom.Text = "Cupom:";
            // 
            // seletorTaxasEServicosControl1
            // 
            this.seletorTaxasEServicosControl1.Location = new System.Drawing.Point(16, 223);
            this.seletorTaxasEServicosControl1.Name = "seletorTaxasEServicosControl1";
            this.seletorTaxasEServicosControl1.Size = new System.Drawing.Size(288, 48);
            this.seletorTaxasEServicosControl1.TabIndex = 8;
            this.seletorTaxasEServicosControl1.TaxasEServicos = null;
            this.seletorTaxasEServicosControl1.TaxasEServicosSelecionados = new LocadoraDeVeiculos.Dominio.TaxasEServicosModule.TaxaEServico[0].ToList();
            // 
            // btnCupom
            // 
            this.btnCupom.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCupom.Location = new System.Drawing.Point(204, 223);
            this.btnCupom.Name = "btnCupom";
            this.btnCupom.Size = new System.Drawing.Size(100, 28);
            this.btnCupom.TabIndex = 39;
            this.btnCupom.Text = "Validar Cupom";
            this.btnCupom.UseVisualStyleBackColor = false;
            this.btnCupom.Click += new System.EventHandler(this.btnCupom_Click);
            // 
            // TelaLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 320);
            this.Controls.Add(this.btnCupom);
            this.Controls.Add(this.labelCupom);
            this.Controls.Add(this.txtCupom);
            this.Controls.Add(this.seletorTaxasEServicosControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.cmbPlano);
            this.Controls.Add(this.labelPlano);
            this.Controls.Add(this.labelReais);
            this.Controls.Add(this.txtCaucao);
            this.Controls.Add(this.labelCaucao);
            this.Controls.Add(this.dtpdataDevolucaoEsperada);
            this.Controls.Add(this.labelDataEsperada);
            this.Controls.Add(this.dtpdataSaida);
            this.Controls.Add(this.labelDataSaida);
            this.Controls.Add(this.cmbAutomovel);
            this.Controls.Add(this.labelAutomovel);
            this.Controls.Add(this.cmbCondutor);
            this.Controls.Add(this.labelCondutor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaLocacaoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abertura de Locação";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCondutor;
        private System.Windows.Forms.ComboBox cmbCondutor;
        private System.Windows.Forms.Label labelAutomovel;
        private System.Windows.Forms.ComboBox cmbAutomovel;
        private System.Windows.Forms.Label labelDataSaida;
        private System.Windows.Forms.DateTimePicker dtpdataSaida;
        private System.Windows.Forms.Label labelDataEsperada;
        private System.Windows.Forms.DateTimePicker dtpdataDevolucaoEsperada;
        private System.Windows.Forms.Label labelCaucao;
        private System.Windows.Forms.TextBox txtCaucao;
        private System.Windows.Forms.Label labelReais;
        private System.Windows.Forms.Label labelPlano;
        private System.Windows.Forms.ComboBox cmbPlano;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private TaxasEServicos.SeletorTaxasEServicosControl seletorTaxasEServicosControl1;
        private System.Windows.Forms.TextBox txtCupom;
        private System.Windows.Forms.Label labelCupom;
        private System.Windows.Forms.Button btnCupom;
    }
}