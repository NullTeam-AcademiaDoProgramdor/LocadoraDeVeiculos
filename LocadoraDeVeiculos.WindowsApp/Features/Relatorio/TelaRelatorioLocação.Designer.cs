
namespace LocadoraDeVeiculos.WindowsApp.Features.Relatorio
{
    partial class TelaRelatorioLocação
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
            this.labelPlano = new System.Windows.Forms.Label();
            this.labelTipoPlano = new System.Windows.Forms.Label();
            this.labelDiasAlugados = new System.Windows.Forms.Label();
            this.labelQuantDias = new System.Windows.Forms.Label();
            this.labelKmRodados = new System.Windows.Forms.Label();
            this.labelQuantKmRodados = new System.Windows.Forms.Label();
            this.labelTaxaDiaria = new System.Windows.Forms.Label();
            this.labelValorTaxaDiaria = new System.Windows.Forms.Label();
            this.labelTaxaKm = new System.Windows.Forms.Label();
            this.labelValorTaxaKm = new System.Windows.Forms.Label();
            this.labelSubTotal = new System.Windows.Forms.Label();
            this.labelValorSubTotal = new System.Windows.Forms.Label();
            this.groupBoxAdicionasPorDia = new System.Windows.Forms.GroupBox();
            this.labelSubTotalAdicionaisDia = new System.Windows.Forms.Label();
            this.labelValorSubTotalDia = new System.Windows.Forms.Label();
            this.groupBoxAdicionaisFixos = new System.Windows.Forms.GroupBox();
            this.labelSubTotalFixo = new System.Windows.Forms.Label();
            this.labelValorSubTotalFixo = new System.Windows.Forms.Label();
            this.labelTotalAPagar = new System.Windows.Forms.Label();
            this.labelValorTotalAPagar = new System.Windows.Forms.Label();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.listBoxAdicionaisPorDia = new System.Windows.Forms.ListBox();
            this.listBoxAdicionaisFixos = new System.Windows.Forms.ListBox();
            this.groupBoxAdicionasPorDia.SuspendLayout();
            this.groupBoxAdicionaisFixos.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPlano
            // 
            this.labelPlano.AutoSize = true;
            this.labelPlano.Location = new System.Drawing.Point(9, 9);
            this.labelPlano.Name = "labelPlano";
            this.labelPlano.Size = new System.Drawing.Size(37, 13);
            this.labelPlano.TabIndex = 0;
            this.labelPlano.Text = "Plano:";
            // 
            // labelTipoPlano
            // 
            this.labelTipoPlano.AutoSize = true;
            this.labelTipoPlano.Location = new System.Drawing.Point(255, 9);
            this.labelTipoPlano.Name = "labelTipoPlano";
            this.labelTipoPlano.Size = new System.Drawing.Size(73, 13);
            this.labelTipoPlano.TabIndex = 1;
            this.labelTipoPlano.Text = "Tipo de Plano";
            // 
            // labelDiasAlugados
            // 
            this.labelDiasAlugados.AutoSize = true;
            this.labelDiasAlugados.Location = new System.Drawing.Point(9, 31);
            this.labelDiasAlugados.Name = "labelDiasAlugados";
            this.labelDiasAlugados.Size = new System.Drawing.Size(77, 13);
            this.labelDiasAlugados.TabIndex = 2;
            this.labelDiasAlugados.Text = "Dias alugados:";
            // 
            // labelQuantDias
            // 
            this.labelQuantDias.AutoSize = true;
            this.labelQuantDias.Location = new System.Drawing.Point(183, 31);
            this.labelQuantDias.Name = "labelQuantDias";
            this.labelQuantDias.Size = new System.Drawing.Size(145, 13);
            this.labelQuantDias.TabIndex = 3;
            this.labelQuantDias.Text = "Quantidade de dias alugados";
            // 
            // labelKmRodados
            // 
            this.labelKmRodados.AutoSize = true;
            this.labelKmRodados.Location = new System.Drawing.Point(10, 58);
            this.labelKmRodados.Name = "labelKmRodados";
            this.labelKmRodados.Size = new System.Drawing.Size(66, 13);
            this.labelKmRodados.TabIndex = 4;
            this.labelKmRodados.Text = "Km rodados:";
            // 
            // labelQuantKmRodados
            // 
            this.labelQuantKmRodados.AutoSize = true;
            this.labelQuantKmRodados.Location = new System.Drawing.Point(160, 58);
            this.labelQuantKmRodados.Name = "labelQuantKmRodados";
            this.labelQuantKmRodados.Size = new System.Drawing.Size(168, 13);
            this.labelQuantKmRodados.TabIndex = 5;
            this.labelQuantKmRodados.Text = "Quantidade de kilometros rodados";
            // 
            // labelTaxaDiaria
            // 
            this.labelTaxaDiaria.AutoSize = true;
            this.labelTaxaDiaria.Location = new System.Drawing.Point(10, 83);
            this.labelTaxaDiaria.Name = "labelTaxaDiaria";
            this.labelTaxaDiaria.Size = new System.Drawing.Size(145, 13);
            this.labelTaxaDiaria.TabIndex = 6;
            this.labelTaxaDiaria.Text = "Taxa diária * Dias alugados =";
            // 
            // labelValorTaxaDiaria
            // 
            this.labelValorTaxaDiaria.AutoSize = true;
            this.labelValorTaxaDiaria.Location = new System.Drawing.Point(227, 83);
            this.labelValorTaxaDiaria.Name = "labelValorTaxaDiaria";
            this.labelValorTaxaDiaria.Size = new System.Drawing.Size(101, 13);
            this.labelValorTaxaDiaria.TabIndex = 7;
            this.labelValorTaxaDiaria.Text = "Valor da Taxa diária";
            // 
            // labelTaxaKm
            // 
            this.labelTaxaKm.AutoSize = true;
            this.labelTaxaKm.Location = new System.Drawing.Point(10, 107);
            this.labelTaxaKm.Name = "labelTaxaKm";
            this.labelTaxaKm.Size = new System.Drawing.Size(142, 13);
            this.labelTaxaKm.TabIndex = 8;
            this.labelTaxaKm.Text = "Taxa por Km * Km rodados =";
            // 
            // labelValorTaxaKm
            // 
            this.labelValorTaxaKm.AutoSize = true;
            this.labelValorTaxaKm.Location = new System.Drawing.Point(219, 107);
            this.labelValorTaxaKm.Name = "labelValorTaxaKm";
            this.labelValorTaxaKm.Size = new System.Drawing.Size(109, 13);
            this.labelValorTaxaKm.TabIndex = 9;
            this.labelValorTaxaKm.Text = "Valor da Taxa por Km";
            // 
            // labelSubTotal
            // 
            this.labelSubTotal.AutoSize = true;
            this.labelSubTotal.Location = new System.Drawing.Point(9, 136);
            this.labelSubTotal.Name = "labelSubTotal";
            this.labelSubTotal.Size = new System.Drawing.Size(65, 13);
            this.labelSubTotal.TabIndex = 10;
            this.labelSubTotal.Text = "Sub Total = ";
            // 
            // labelValorSubTotal
            // 
            this.labelValorSubTotal.AutoSize = true;
            this.labelValorSubTotal.Location = new System.Drawing.Point(248, 136);
            this.labelValorSubTotal.Name = "labelValorSubTotal";
            this.labelValorSubTotal.Size = new System.Drawing.Size(80, 13);
            this.labelValorSubTotal.TabIndex = 11;
            this.labelValorSubTotal.Text = "Valor Sub Total";
            // 
            // groupBoxAdicionasPorDia
            // 
            this.groupBoxAdicionasPorDia.Controls.Add(this.listBoxAdicionaisPorDia);
            this.groupBoxAdicionasPorDia.Location = new System.Drawing.Point(12, 185);
            this.groupBoxAdicionasPorDia.Name = "groupBoxAdicionasPorDia";
            this.groupBoxAdicionasPorDia.Size = new System.Drawing.Size(316, 99);
            this.groupBoxAdicionasPorDia.TabIndex = 12;
            this.groupBoxAdicionasPorDia.TabStop = false;
            this.groupBoxAdicionasPorDia.Text = "Adicionais por dia:";
            // 
            // labelSubTotalAdicionaisDia
            // 
            this.labelSubTotalAdicionaisDia.AutoSize = true;
            this.labelSubTotalAdicionaisDia.Location = new System.Drawing.Point(10, 287);
            this.labelSubTotalAdicionaisDia.Name = "labelSubTotalAdicionaisDia";
            this.labelSubTotalAdicionaisDia.Size = new System.Drawing.Size(65, 13);
            this.labelSubTotalAdicionaisDia.TabIndex = 13;
            this.labelSubTotalAdicionaisDia.Text = "Sub Total = ";
            // 
            // labelValorSubTotalDia
            // 
            this.labelValorSubTotalDia.AutoSize = true;
            this.labelValorSubTotalDia.Location = new System.Drawing.Point(142, 287);
            this.labelValorSubTotalDia.Name = "labelValorSubTotalDia";
            this.labelValorSubTotalDia.Size = new System.Drawing.Size(186, 13);
            this.labelValorSubTotalDia.TabIndex = 14;
            this.labelValorSubTotalDia.Text = "Valor Sub Total dos Adicionais Diários";
            // 
            // groupBoxAdicionaisFixos
            // 
            this.groupBoxAdicionaisFixos.Controls.Add(this.listBoxAdicionaisFixos);
            this.groupBoxAdicionaisFixos.Location = new System.Drawing.Point(12, 336);
            this.groupBoxAdicionaisFixos.Name = "groupBoxAdicionaisFixos";
            this.groupBoxAdicionaisFixos.Size = new System.Drawing.Size(316, 114);
            this.groupBoxAdicionaisFixos.TabIndex = 13;
            this.groupBoxAdicionaisFixos.TabStop = false;
            this.groupBoxAdicionaisFixos.Text = "Adicionais fixos:";
            // 
            // labelSubTotalFixo
            // 
            this.labelSubTotalFixo.AutoSize = true;
            this.labelSubTotalFixo.Location = new System.Drawing.Point(9, 453);
            this.labelSubTotalFixo.Name = "labelSubTotalFixo";
            this.labelSubTotalFixo.Size = new System.Drawing.Size(62, 13);
            this.labelSubTotalFixo.TabIndex = 15;
            this.labelSubTotalFixo.Text = "Sub Total =";
            // 
            // labelValorSubTotalFixo
            // 
            this.labelValorSubTotalFixo.AutoSize = true;
            this.labelValorSubTotalFixo.Location = new System.Drawing.Point(148, 453);
            this.labelValorSubTotalFixo.Name = "labelValorSubTotalFixo";
            this.labelValorSubTotalFixo.Size = new System.Drawing.Size(178, 13);
            this.labelValorSubTotalFixo.TabIndex = 16;
            this.labelValorSubTotalFixo.Text = "Valor Sub Total dos Adicionais Fixos";
            // 
            // labelTotalAPagar
            // 
            this.labelTotalAPagar.AutoSize = true;
            this.labelTotalAPagar.Location = new System.Drawing.Point(9, 497);
            this.labelTotalAPagar.Name = "labelTotalAPagar";
            this.labelTotalAPagar.Size = new System.Drawing.Size(79, 13);
            this.labelTotalAPagar.TabIndex = 17;
            this.labelTotalAPagar.Text = "Total a pagar =";
            // 
            // labelValorTotalAPagar
            // 
            this.labelValorTotalAPagar.AutoSize = true;
            this.labelValorTotalAPagar.Location = new System.Drawing.Point(219, 497);
            this.labelValorTotalAPagar.Name = "labelValorTotalAPagar";
            this.labelValorTotalAPagar.Size = new System.Drawing.Size(107, 13);
            this.labelValorTotalAPagar.TabIndex = 18;
            this.labelValorTotalAPagar.Text = "Valor total a ser pago";
            // 
            // btnConcluir
            // 
            this.btnConcluir.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnConcluir.Location = new System.Drawing.Point(224, 541);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(104, 23);
            this.btnConcluir.TabIndex = 19;
            this.btnConcluir.Text = "Concluir";
            this.btnConcluir.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancelar.Location = new System.Drawing.Point(114, 541);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // listBoxAdicionaisPorDia
            // 
            this.listBoxAdicionaisPorDia.FormattingEnabled = true;
            this.listBoxAdicionaisPorDia.Location = new System.Drawing.Point(6, 25);
            this.listBoxAdicionaisPorDia.Name = "listBoxAdicionaisPorDia";
            this.listBoxAdicionaisPorDia.Size = new System.Drawing.Size(304, 69);
            this.listBoxAdicionaisPorDia.TabIndex = 0;
            // 
            // listBoxAdicionaisFixos
            // 
            this.listBoxAdicionaisFixos.FormattingEnabled = true;
            this.listBoxAdicionaisFixos.Location = new System.Drawing.Point(6, 23);
            this.listBoxAdicionaisFixos.Name = "listBoxAdicionaisFixos";
            this.listBoxAdicionaisFixos.Size = new System.Drawing.Size(304, 82);
            this.listBoxAdicionaisFixos.TabIndex = 1;
            // 
            // TelaRelatorioLocação
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 576);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConcluir);
            this.Controls.Add(this.labelValorTotalAPagar);
            this.Controls.Add(this.labelTotalAPagar);
            this.Controls.Add(this.labelValorSubTotalFixo);
            this.Controls.Add(this.labelSubTotalFixo);
            this.Controls.Add(this.groupBoxAdicionaisFixos);
            this.Controls.Add(this.labelValorSubTotalDia);
            this.Controls.Add(this.labelSubTotalAdicionaisDia);
            this.Controls.Add(this.groupBoxAdicionasPorDia);
            this.Controls.Add(this.labelValorSubTotal);
            this.Controls.Add(this.labelSubTotal);
            this.Controls.Add(this.labelValorTaxaKm);
            this.Controls.Add(this.labelTaxaKm);
            this.Controls.Add(this.labelValorTaxaDiaria);
            this.Controls.Add(this.labelTaxaDiaria);
            this.Controls.Add(this.labelQuantKmRodados);
            this.Controls.Add(this.labelKmRodados);
            this.Controls.Add(this.labelQuantDias);
            this.Controls.Add(this.labelDiasAlugados);
            this.Controls.Add(this.labelTipoPlano);
            this.Controls.Add(this.labelPlano);
            this.Name = "TelaRelatorioLocação";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Locação";
            this.groupBoxAdicionasPorDia.ResumeLayout(false);
            this.groupBoxAdicionaisFixos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlano;
        private System.Windows.Forms.Label labelTipoPlano;
        private System.Windows.Forms.Label labelDiasAlugados;
        private System.Windows.Forms.Label labelQuantDias;
        private System.Windows.Forms.Label labelKmRodados;
        private System.Windows.Forms.Label labelQuantKmRodados;
        private System.Windows.Forms.Label labelTaxaDiaria;
        private System.Windows.Forms.Label labelValorTaxaDiaria;
        private System.Windows.Forms.Label labelTaxaKm;
        private System.Windows.Forms.Label labelValorTaxaKm;
        private System.Windows.Forms.Label labelSubTotal;
        private System.Windows.Forms.Label labelValorSubTotal;
        private System.Windows.Forms.GroupBox groupBoxAdicionasPorDia;
        private System.Windows.Forms.Label labelSubTotalAdicionaisDia;
        private System.Windows.Forms.Label labelValorSubTotalDia;
        private System.Windows.Forms.GroupBox groupBoxAdicionaisFixos;
        private System.Windows.Forms.Label labelSubTotalFixo;
        private System.Windows.Forms.Label labelValorSubTotalFixo;
        private System.Windows.Forms.Label labelTotalAPagar;
        private System.Windows.Forms.Label labelValorTotalAPagar;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ListBox listBoxAdicionaisPorDia;
        private System.Windows.Forms.ListBox listBoxAdicionaisFixos;
    }
}