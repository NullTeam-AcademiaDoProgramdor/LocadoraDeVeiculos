
namespace LocadoraDeVeiculos.WindowsApp.Features.Relatorios
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
            this.listBoxAdicionaisPorDia = new System.Windows.Forms.ListBox();
            this.labelSubTotalAdicionaisDia = new System.Windows.Forms.Label();
            this.labelValorSubTotalDia = new System.Windows.Forms.Label();
            this.groupBoxAdicionaisFixos = new System.Windows.Forms.GroupBox();
            this.listBoxAdicionaisFixos = new System.Windows.Forms.ListBox();
            this.labelSubTotalFixo = new System.Windows.Forms.Label();
            this.labelValorSubTotalFixo = new System.Windows.Forms.Label();
            this.labelTotalAPagar = new System.Windows.Forms.Label();
            this.labelValorTotalAPagar = new System.Windows.Forms.Label();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelTaxaKmExtrapolado = new System.Windows.Forms.Label();
            this.labelValorTaxaKmExtrapolado = new System.Windows.Forms.Label();
            this.labelTipoCombustivel = new System.Windows.Forms.Label();
            this.labelLitrosEncher = new System.Windows.Forms.Label();
            this.labelAbastecer = new System.Windows.Forms.Label();
            this.labelValorTipoCombustivel = new System.Windows.Forms.Label();
            this.labelValorLitrosEncher = new System.Windows.Forms.Label();
            this.labelValorAbastecer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelValorCupom = new System.Windows.Forms.Label();
            this.groupBoxAdicionasPorDia.SuspendLayout();
            this.groupBoxAdicionaisFixos.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPlano
            // 
            this.labelPlano.AutoSize = true;
            this.labelPlano.Location = new System.Drawing.Point(15, 14);
            this.labelPlano.Name = "labelPlano";
            this.labelPlano.Size = new System.Drawing.Size(37, 13);
            this.labelPlano.TabIndex = 0;
            this.labelPlano.Text = "Plano:";
            // 
            // labelTipoPlano
            // 
            this.labelTipoPlano.AutoSize = true;
            this.labelTipoPlano.Location = new System.Drawing.Point(221, 14);
            this.labelTipoPlano.Name = "labelTipoPlano";
            this.labelTipoPlano.Size = new System.Drawing.Size(13, 13);
            this.labelTipoPlano.TabIndex = 1;
            this.labelTipoPlano.Text = "0";
            // 
            // labelDiasAlugados
            // 
            this.labelDiasAlugados.AutoSize = true;
            this.labelDiasAlugados.Location = new System.Drawing.Point(15, 36);
            this.labelDiasAlugados.Name = "labelDiasAlugados";
            this.labelDiasAlugados.Size = new System.Drawing.Size(77, 13);
            this.labelDiasAlugados.TabIndex = 2;
            this.labelDiasAlugados.Text = "Dias alugados:";
            // 
            // labelQuantDias
            // 
            this.labelQuantDias.AutoSize = true;
            this.labelQuantDias.Location = new System.Drawing.Point(221, 36);
            this.labelQuantDias.Name = "labelQuantDias";
            this.labelQuantDias.Size = new System.Drawing.Size(13, 13);
            this.labelQuantDias.TabIndex = 3;
            this.labelQuantDias.Text = "0";
            // 
            // labelKmRodados
            // 
            this.labelKmRodados.AutoSize = true;
            this.labelKmRodados.Location = new System.Drawing.Point(15, 58);
            this.labelKmRodados.Name = "labelKmRodados";
            this.labelKmRodados.Size = new System.Drawing.Size(66, 13);
            this.labelKmRodados.TabIndex = 4;
            this.labelKmRodados.Text = "Km rodados:";
            // 
            // labelQuantKmRodados
            // 
            this.labelQuantKmRodados.AutoSize = true;
            this.labelQuantKmRodados.Location = new System.Drawing.Point(221, 58);
            this.labelQuantKmRodados.Name = "labelQuantKmRodados";
            this.labelQuantKmRodados.Size = new System.Drawing.Size(13, 13);
            this.labelQuantKmRodados.TabIndex = 5;
            this.labelQuantKmRodados.Text = "0";
            // 
            // labelTaxaDiaria
            // 
            this.labelTaxaDiaria.AutoSize = true;
            this.labelTaxaDiaria.Location = new System.Drawing.Point(15, 80);
            this.labelTaxaDiaria.Name = "labelTaxaDiaria";
            this.labelTaxaDiaria.Size = new System.Drawing.Size(145, 13);
            this.labelTaxaDiaria.TabIndex = 6;
            this.labelTaxaDiaria.Text = "Taxa diária * Dias alugados =";
            // 
            // labelValorTaxaDiaria
            // 
            this.labelValorTaxaDiaria.AutoSize = true;
            this.labelValorTaxaDiaria.Location = new System.Drawing.Point(221, 80);
            this.labelValorTaxaDiaria.Name = "labelValorTaxaDiaria";
            this.labelValorTaxaDiaria.Size = new System.Drawing.Size(13, 13);
            this.labelValorTaxaDiaria.TabIndex = 7;
            this.labelValorTaxaDiaria.Text = "0";
            // 
            // labelTaxaKm
            // 
            this.labelTaxaKm.AutoSize = true;
            this.labelTaxaKm.Location = new System.Drawing.Point(15, 102);
            this.labelTaxaKm.Name = "labelTaxaKm";
            this.labelTaxaKm.Size = new System.Drawing.Size(142, 13);
            this.labelTaxaKm.TabIndex = 8;
            this.labelTaxaKm.Text = "Taxa por Km * Km rodados =";
            // 
            // labelValorTaxaKm
            // 
            this.labelValorTaxaKm.AutoSize = true;
            this.labelValorTaxaKm.Location = new System.Drawing.Point(221, 102);
            this.labelValorTaxaKm.Name = "labelValorTaxaKm";
            this.labelValorTaxaKm.Size = new System.Drawing.Size(13, 13);
            this.labelValorTaxaKm.TabIndex = 9;
            this.labelValorTaxaKm.Text = "0";
            // 
            // labelSubTotal
            // 
            this.labelSubTotal.AutoSize = true;
            this.labelSubTotal.Location = new System.Drawing.Point(15, 159);
            this.labelSubTotal.Name = "labelSubTotal";
            this.labelSubTotal.Size = new System.Drawing.Size(65, 13);
            this.labelSubTotal.TabIndex = 10;
            this.labelSubTotal.Text = "Sub Total = ";
            // 
            // labelValorSubTotal
            // 
            this.labelValorSubTotal.AutoSize = true;
            this.labelValorSubTotal.Location = new System.Drawing.Point(221, 159);
            this.labelValorSubTotal.Name = "labelValorSubTotal";
            this.labelValorSubTotal.Size = new System.Drawing.Size(13, 13);
            this.labelValorSubTotal.TabIndex = 11;
            this.labelValorSubTotal.Text = "0";
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
            // listBoxAdicionaisPorDia
            // 
            this.listBoxAdicionaisPorDia.Enabled = false;
            this.listBoxAdicionaisPorDia.FormattingEnabled = true;
            this.listBoxAdicionaisPorDia.Location = new System.Drawing.Point(6, 25);
            this.listBoxAdicionaisPorDia.Name = "listBoxAdicionaisPorDia";
            this.listBoxAdicionaisPorDia.Size = new System.Drawing.Size(304, 69);
            this.listBoxAdicionaisPorDia.TabIndex = 0;
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
            this.labelValorSubTotalDia.Location = new System.Drawing.Point(221, 287);
            this.labelValorSubTotalDia.Name = "labelValorSubTotalDia";
            this.labelValorSubTotalDia.Size = new System.Drawing.Size(13, 13);
            this.labelValorSubTotalDia.TabIndex = 14;
            this.labelValorSubTotalDia.Text = "0";
            // 
            // groupBoxAdicionaisFixos
            // 
            this.groupBoxAdicionaisFixos.Controls.Add(this.listBoxAdicionaisFixos);
            this.groupBoxAdicionaisFixos.Location = new System.Drawing.Point(12, 310);
            this.groupBoxAdicionaisFixos.Name = "groupBoxAdicionaisFixos";
            this.groupBoxAdicionaisFixos.Size = new System.Drawing.Size(316, 114);
            this.groupBoxAdicionaisFixos.TabIndex = 13;
            this.groupBoxAdicionaisFixos.TabStop = false;
            this.groupBoxAdicionaisFixos.Text = "Adicionais fixos:";
            // 
            // listBoxAdicionaisFixos
            // 
            this.listBoxAdicionaisFixos.Enabled = false;
            this.listBoxAdicionaisFixos.FormattingEnabled = true;
            this.listBoxAdicionaisFixos.Location = new System.Drawing.Point(6, 23);
            this.listBoxAdicionaisFixos.Name = "listBoxAdicionaisFixos";
            this.listBoxAdicionaisFixos.Size = new System.Drawing.Size(304, 82);
            this.listBoxAdicionaisFixos.TabIndex = 1;
            // 
            // labelSubTotalFixo
            // 
            this.labelSubTotalFixo.AutoSize = true;
            this.labelSubTotalFixo.Location = new System.Drawing.Point(9, 427);
            this.labelSubTotalFixo.Name = "labelSubTotalFixo";
            this.labelSubTotalFixo.Size = new System.Drawing.Size(62, 13);
            this.labelSubTotalFixo.TabIndex = 15;
            this.labelSubTotalFixo.Text = "Sub Total =";
            // 
            // labelValorSubTotalFixo
            // 
            this.labelValorSubTotalFixo.AutoSize = true;
            this.labelValorSubTotalFixo.Location = new System.Drawing.Point(221, 427);
            this.labelValorSubTotalFixo.Name = "labelValorSubTotalFixo";
            this.labelValorSubTotalFixo.Size = new System.Drawing.Size(13, 13);
            this.labelValorSubTotalFixo.TabIndex = 16;
            this.labelValorSubTotalFixo.Text = "0";
            // 
            // labelTotalAPagar
            // 
            this.labelTotalAPagar.AutoSize = true;
            this.labelTotalAPagar.Location = new System.Drawing.Point(10, 556);
            this.labelTotalAPagar.Name = "labelTotalAPagar";
            this.labelTotalAPagar.Size = new System.Drawing.Size(79, 13);
            this.labelTotalAPagar.TabIndex = 17;
            this.labelTotalAPagar.Text = "Total a pagar =";
            // 
            // labelValorTotalAPagar
            // 
            this.labelValorTotalAPagar.AutoSize = true;
            this.labelValorTotalAPagar.Location = new System.Drawing.Point(221, 556);
            this.labelValorTotalAPagar.Name = "labelValorTotalAPagar";
            this.labelValorTotalAPagar.Size = new System.Drawing.Size(13, 13);
            this.labelValorTotalAPagar.TabIndex = 18;
            this.labelValorTotalAPagar.Text = "0";
            // 
            // btnConcluir
            // 
            this.btnConcluir.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnConcluir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConcluir.Location = new System.Drawing.Point(224, 575);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(104, 23);
            this.btnConcluir.TabIndex = 19;
            this.btnConcluir.Text = "Concluir";
            this.btnConcluir.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(114, 575);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // labelTaxaKmExtrapolado
            // 
            this.labelTaxaKmExtrapolado.Location = new System.Drawing.Point(15, 124);
            this.labelTaxaKmExtrapolado.Name = "labelTaxaKmExtrapolado";
            this.labelTaxaKmExtrapolado.Size = new System.Drawing.Size(156, 35);
            this.labelTaxaKmExtrapolado.TabIndex = 21;
            this.labelTaxaKmExtrapolado.Text = "Taxa por Km extrapolado * Km Extrapolados =";
            // 
            // labelValorTaxaKmExtrapolado
            // 
            this.labelValorTaxaKmExtrapolado.AutoSize = true;
            this.labelValorTaxaKmExtrapolado.Location = new System.Drawing.Point(221, 137);
            this.labelValorTaxaKmExtrapolado.Name = "labelValorTaxaKmExtrapolado";
            this.labelValorTaxaKmExtrapolado.Size = new System.Drawing.Size(13, 13);
            this.labelValorTaxaKmExtrapolado.TabIndex = 22;
            this.labelValorTaxaKmExtrapolado.Text = "0";
            // 
            // labelTipoCombustivel
            // 
            this.labelTipoCombustivel.AutoSize = true;
            this.labelTipoCombustivel.Location = new System.Drawing.Point(10, 452);
            this.labelTipoCombustivel.Name = "labelTipoCombustivel";
            this.labelTipoCombustivel.Size = new System.Drawing.Size(91, 13);
            this.labelTipoCombustivel.TabIndex = 23;
            this.labelTipoCombustivel.Text = "Tipo Combustivel:";
            // 
            // labelLitrosEncher
            // 
            this.labelLitrosEncher.AutoSize = true;
            this.labelLitrosEncher.Location = new System.Drawing.Point(10, 478);
            this.labelLitrosEncher.Name = "labelLitrosEncher";
            this.labelLitrosEncher.Size = new System.Drawing.Size(98, 13);
            this.labelLitrosEncher.TabIndex = 24;
            this.labelLitrosEncher.Text = "Litros para encher: ";
            // 
            // labelAbastecer
            // 
            this.labelAbastecer.AutoSize = true;
            this.labelAbastecer.Location = new System.Drawing.Point(10, 504);
            this.labelAbastecer.Name = "labelAbastecer";
            this.labelAbastecer.Size = new System.Drawing.Size(108, 13);
            this.labelAbastecer.TabIndex = 25;
            this.labelAbastecer.Text = "Valor para abastecer:";
            // 
            // labelValorTipoCombustivel
            // 
            this.labelValorTipoCombustivel.AutoSize = true;
            this.labelValorTipoCombustivel.Location = new System.Drawing.Point(221, 452);
            this.labelValorTipoCombustivel.Name = "labelValorTipoCombustivel";
            this.labelValorTipoCombustivel.Size = new System.Drawing.Size(13, 13);
            this.labelValorTipoCombustivel.TabIndex = 26;
            this.labelValorTipoCombustivel.Text = "0";
            // 
            // labelValorLitrosEncher
            // 
            this.labelValorLitrosEncher.AutoSize = true;
            this.labelValorLitrosEncher.Location = new System.Drawing.Point(221, 478);
            this.labelValorLitrosEncher.Name = "labelValorLitrosEncher";
            this.labelValorLitrosEncher.Size = new System.Drawing.Size(13, 13);
            this.labelValorLitrosEncher.TabIndex = 27;
            this.labelValorLitrosEncher.Text = "0";
            // 
            // labelValorAbastecer
            // 
            this.labelValorAbastecer.AutoSize = true;
            this.labelValorAbastecer.Location = new System.Drawing.Point(221, 504);
            this.labelValorAbastecer.Name = "labelValorAbastecer";
            this.labelValorAbastecer.Size = new System.Drawing.Size(13, 13);
            this.labelValorAbastecer.TabIndex = 28;
            this.labelValorAbastecer.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Desconto do cupom:";
            // 
            // labelValorCupom
            // 
            this.labelValorCupom.AutoSize = true;
            this.labelValorCupom.Location = new System.Drawing.Point(221, 530);
            this.labelValorCupom.Name = "labelValorCupom";
            this.labelValorCupom.Size = new System.Drawing.Size(13, 13);
            this.labelValorCupom.TabIndex = 30;
            this.labelValorCupom.Text = "0";
            // 
            // TelaRelatorioLocação
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 610);
            this.Controls.Add(this.labelValorCupom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelValorAbastecer);
            this.Controls.Add(this.labelValorLitrosEncher);
            this.Controls.Add(this.labelValorTipoCombustivel);
            this.Controls.Add(this.labelAbastecer);
            this.Controls.Add(this.labelLitrosEncher);
            this.Controls.Add(this.labelTipoCombustivel);
            this.Controls.Add(this.labelValorTaxaKmExtrapolado);
            this.Controls.Add(this.labelTaxaKmExtrapolado);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.Label labelTaxaKmExtrapolado;
        private System.Windows.Forms.Label labelValorTaxaKmExtrapolado;
        private System.Windows.Forms.Label labelTipoCombustivel;
        private System.Windows.Forms.Label labelLitrosEncher;
        private System.Windows.Forms.Label labelAbastecer;
        private System.Windows.Forms.Label labelValorTipoCombustivel;
        private System.Windows.Forms.Label labelValorLitrosEncher;
        private System.Windows.Forms.Label labelValorAbastecer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelValorCupom;
    }
}