
namespace LocadoraDeVeiculos.WindowsApp.Features.LocacaoModule
{
    partial class FiltroLocacaoForm
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
            this.rdbLocacaoDevolvida = new System.Windows.Forms.RadioButton();
            this.rdbLocacaoNaoDevolvida = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.rdbTodasLocacoes = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdbLocacaoDevolvida
            // 
            this.rdbLocacaoDevolvida.AutoSize = true;
            this.rdbLocacaoDevolvida.Checked = true;
            this.rdbLocacaoDevolvida.Location = new System.Drawing.Point(12, 12);
            this.rdbLocacaoDevolvida.Name = "rdbLocacaoDevolvida";
            this.rdbLocacaoDevolvida.Size = new System.Drawing.Size(176, 17);
            this.rdbLocacaoDevolvida.TabIndex = 24;
            this.rdbLocacaoDevolvida.TabStop = true;
            this.rdbLocacaoDevolvida.Text = "Visualizar Locações Concluídas";
            this.rdbLocacaoDevolvida.UseVisualStyleBackColor = true;
            // 
            // rdbLocacaoNaoDevolvida
            // 
            this.rdbLocacaoNaoDevolvida.AutoSize = true;
            this.rdbLocacaoNaoDevolvida.Location = new System.Drawing.Point(12, 49);
            this.rdbLocacaoNaoDevolvida.Name = "rdbLocacaoNaoDevolvida";
            this.rdbLocacaoNaoDevolvida.Size = new System.Drawing.Size(173, 17);
            this.rdbLocacaoNaoDevolvida.TabIndex = 23;
            this.rdbLocacaoNaoDevolvida.Text = "Visualizar Locações Pendentes";
            this.rdbLocacaoNaoDevolvida.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(172, 119);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(253, 119);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 21;
            this.btnGravar.Text = "Selecionar";
            this.btnGravar.UseVisualStyleBackColor = false;
            // 
            // rdbTodasLocacoes
            // 
            this.rdbTodasLocacoes.AutoSize = true;
            this.rdbTodasLocacoes.Location = new System.Drawing.Point(12, 86);
            this.rdbTodasLocacoes.Name = "rdbTodasLocacoes";
            this.rdbTodasLocacoes.Size = new System.Drawing.Size(162, 17);
            this.rdbTodasLocacoes.TabIndex = 25;
            this.rdbTodasLocacoes.Text = "Visualizar todas as Locações";
            this.rdbTodasLocacoes.UseVisualStyleBackColor = true;
            // 
            // FiltroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 154);
            this.Controls.Add(this.rdbTodasLocacoes);
            this.Controls.Add(this.rdbLocacaoDevolvida);
            this.Controls.Add(this.rdbLocacaoNaoDevolvida);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FiltroLocacaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro de Locações";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbLocacaoDevolvida;
        private System.Windows.Forms.RadioButton rdbLocacaoNaoDevolvida;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.RadioButton rdbTodasLocacoes;
    }
}