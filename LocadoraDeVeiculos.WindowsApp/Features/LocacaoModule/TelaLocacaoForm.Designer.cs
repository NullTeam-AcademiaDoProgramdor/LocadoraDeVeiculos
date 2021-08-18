
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
            this.comboBoxCondutor = new System.Windows.Forms.ComboBox();
            this.labelAutomovel = new System.Windows.Forms.Label();
            this.comboBoxAutomovel = new System.Windows.Forms.ComboBox();
            this.labelDataSaida = new System.Windows.Forms.Label();
            this.dataSaida = new System.Windows.Forms.DateTimePicker();
            this.labelDataEsperada = new System.Windows.Forms.Label();
            this.dataDevolucaoEsperada = new System.Windows.Forms.DateTimePicker();
            this.labelSeguro = new System.Windows.Forms.Label();
            this.comboBoxSeguro = new System.Windows.Forms.ComboBox();
            this.labelCaucao = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelReais = new System.Windows.Forms.Label();
            this.labelPlano = new System.Windows.Forms.Label();
            this.comboBoxPlano = new System.Windows.Forms.ComboBox();
            this.labelId = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCondutor
            // 
            this.labelCondutor.AutoSize = true;
            this.labelCondutor.Location = new System.Drawing.Point(20, 38);
            this.labelCondutor.Name = "labelCondutor";
            this.labelCondutor.Size = new System.Drawing.Size(53, 13);
            this.labelCondutor.TabIndex = 0;
            this.labelCondutor.Text = "Condutor:";
            // 
            // comboBoxCondutor
            // 
            this.comboBoxCondutor.FormattingEnabled = true;
            this.comboBoxCondutor.Location = new System.Drawing.Point(79, 35);
            this.comboBoxCondutor.Name = "comboBoxCondutor";
            this.comboBoxCondutor.Size = new System.Drawing.Size(225, 21);
            this.comboBoxCondutor.TabIndex = 1;
            // 
            // labelAutomovel
            // 
            this.labelAutomovel.AutoSize = true;
            this.labelAutomovel.Location = new System.Drawing.Point(13, 65);
            this.labelAutomovel.Name = "labelAutomovel";
            this.labelAutomovel.Size = new System.Drawing.Size(60, 13);
            this.labelAutomovel.TabIndex = 2;
            this.labelAutomovel.Text = "Automóvel:";
            // 
            // comboBoxAutomovel
            // 
            this.comboBoxAutomovel.FormattingEnabled = true;
            this.comboBoxAutomovel.Location = new System.Drawing.Point(79, 62);
            this.comboBoxAutomovel.Name = "comboBoxAutomovel";
            this.comboBoxAutomovel.Size = new System.Drawing.Size(225, 21);
            this.comboBoxAutomovel.TabIndex = 3;
            // 
            // labelDataSaida
            // 
            this.labelDataSaida.AutoSize = true;
            this.labelDataSaida.Location = new System.Drawing.Point(9, 95);
            this.labelDataSaida.Name = "labelDataSaida";
            this.labelDataSaida.Size = new System.Drawing.Size(78, 13);
            this.labelDataSaida.TabIndex = 4;
            this.labelDataSaida.Text = "Data de saída:";
            // 
            // dataSaida
            // 
            this.dataSaida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataSaida.Location = new System.Drawing.Point(104, 90);
            this.dataSaida.Name = "dataSaida";
            this.dataSaida.Size = new System.Drawing.Size(200, 20);
            this.dataSaida.TabIndex = 5;
            // 
            // labelDataEsperada
            // 
            this.labelDataEsperada.AutoSize = true;
            this.labelDataEsperada.Location = new System.Drawing.Point(9, 120);
            this.labelDataEsperada.Name = "labelDataEsperada";
            this.labelDataEsperada.Size = new System.Drawing.Size(148, 13);
            this.labelDataEsperada.TabIndex = 6;
            this.labelDataEsperada.Text = "Data de devolução esperada:";
            // 
            // dataDevolucaoEsperada
            // 
            this.dataDevolucaoEsperada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataDevolucaoEsperada.Location = new System.Drawing.Point(174, 116);
            this.dataDevolucaoEsperada.Name = "dataDevolucaoEsperada";
            this.dataDevolucaoEsperada.Size = new System.Drawing.Size(130, 20);
            this.dataDevolucaoEsperada.TabIndex = 7;
            // 
            // labelSeguro
            // 
            this.labelSeguro.AutoSize = true;
            this.labelSeguro.Location = new System.Drawing.Point(29, 145);
            this.labelSeguro.Name = "labelSeguro";
            this.labelSeguro.Size = new System.Drawing.Size(44, 13);
            this.labelSeguro.TabIndex = 8;
            this.labelSeguro.Text = "Seguro:";
            // 
            // comboBoxSeguro
            // 
            this.comboBoxSeguro.FormattingEnabled = true;
            this.comboBoxSeguro.Location = new System.Drawing.Point(79, 142);
            this.comboBoxSeguro.Name = "comboBoxSeguro";
            this.comboBoxSeguro.Size = new System.Drawing.Size(225, 21);
            this.comboBoxSeguro.TabIndex = 9;
            // 
            // labelCaucao
            // 
            this.labelCaucao.AutoSize = true;
            this.labelCaucao.Location = new System.Drawing.Point(26, 172);
            this.labelCaucao.Name = "labelCaucao";
            this.labelCaucao.Size = new System.Drawing.Size(47, 13);
            this.labelCaucao.TabIndex = 10;
            this.labelCaucao.Text = "Caução:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 172);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 20);
            this.textBox1.TabIndex = 11;
            // 
            // labelReais
            // 
            this.labelReais.AutoSize = true;
            this.labelReais.Location = new System.Drawing.Point(307, 175);
            this.labelReais.Name = "labelReais";
            this.labelReais.Size = new System.Drawing.Size(21, 13);
            this.labelReais.TabIndex = 12;
            this.labelReais.Text = "R$";
            // 
            // labelPlano
            // 
            this.labelPlano.AutoSize = true;
            this.labelPlano.Location = new System.Drawing.Point(36, 203);
            this.labelPlano.Name = "labelPlano";
            this.labelPlano.Size = new System.Drawing.Size(37, 13);
            this.labelPlano.TabIndex = 13;
            this.labelPlano.Text = "Plano:";
            // 
            // comboBoxPlano
            // 
            this.comboBoxPlano.FormattingEnabled = true;
            this.comboBoxPlano.Location = new System.Drawing.Point(79, 200);
            this.comboBoxPlano.Name = "comboBoxPlano";
            this.comboBoxPlano.Size = new System.Drawing.Size(225, 21);
            this.comboBoxPlano.TabIndex = 14;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(52, 9);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(21, 13);
            this.labelId.TabIndex = 16;
            this.labelId.Text = "ID:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LightGreen;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(79, 7);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(225, 20);
            this.textBox2.TabIndex = 17;
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGravar.Location = new System.Drawing.Point(235, 305);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(93, 23);
            this.btnGravar.TabIndex = 18;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancelar.Location = new System.Drawing.Point(136, 305);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 23);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // seletorTaxasEServicosControl1
            // 
            this.seletorTaxasEServicosControl1.Location = new System.Drawing.Point(10, 241);
            this.seletorTaxasEServicosControl1.Name = "seletorTaxasEServicosControl1";
            this.seletorTaxasEServicosControl1.Size = new System.Drawing.Size(147, 48);
            this.seletorTaxasEServicosControl1.TabIndex = 20;
            // 
            // TelaLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 340);
            this.Controls.Add(this.seletorTaxasEServicosControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.comboBoxPlano);
            this.Controls.Add(this.labelPlano);
            this.Controls.Add(this.labelReais);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelCaucao);
            this.Controls.Add(this.comboBoxSeguro);
            this.Controls.Add(this.labelSeguro);
            this.Controls.Add(this.dataDevolucaoEsperada);
            this.Controls.Add(this.labelDataEsperada);
            this.Controls.Add(this.dataSaida);
            this.Controls.Add(this.labelDataSaida);
            this.Controls.Add(this.comboBoxAutomovel);
            this.Controls.Add(this.labelAutomovel);
            this.Controls.Add(this.comboBoxCondutor);
            this.Controls.Add(this.labelCondutor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TelaLocacaoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abertura de Locação";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCondutor;
        private System.Windows.Forms.ComboBox comboBoxCondutor;
        private System.Windows.Forms.Label labelAutomovel;
        private System.Windows.Forms.ComboBox comboBoxAutomovel;
        private System.Windows.Forms.Label labelDataSaida;
        private System.Windows.Forms.DateTimePicker dataSaida;
        private System.Windows.Forms.Label labelDataEsperada;
        private System.Windows.Forms.DateTimePicker dataDevolucaoEsperada;
        private System.Windows.Forms.Label labelSeguro;
        private System.Windows.Forms.ComboBox comboBoxSeguro;
        private System.Windows.Forms.Label labelCaucao;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelReais;
        private System.Windows.Forms.Label labelPlano;
        private System.Windows.Forms.ComboBox comboBoxPlano;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private TaxasEServicos.SeletorTaxasEServicosControl seletorTaxasEServicosControl1;
    }
}