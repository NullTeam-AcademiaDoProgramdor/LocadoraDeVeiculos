
namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasJuridicas
{
    partial class AgrupamentoPessoaFisicaForm
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
            this.rdbPessoasPorEmpresa = new System.Windows.Forms.RadioButton();
            this.rdbPessoasSemOrdem = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbPessoasPorEmpresa
            // 
            this.rdbPessoasPorEmpresa.AutoSize = true;
            this.rdbPessoasPorEmpresa.Checked = true;
            this.rdbPessoasPorEmpresa.Location = new System.Drawing.Point(12, 12);
            this.rdbPessoasPorEmpresa.Name = "rdbPessoasPorEmpresa";
            this.rdbPessoasPorEmpresa.Size = new System.Drawing.Size(259, 17);
            this.rdbPessoasPorEmpresa.TabIndex = 20;
            this.rdbPessoasPorEmpresa.TabStop = true;
            this.rdbPessoasPorEmpresa.Text = "Visualizar pessoas físicas agrupadas por empresa";
            this.rdbPessoasPorEmpresa.UseVisualStyleBackColor = true;
            // 
            // rdbPessoasSemOrdem
            // 
            this.rdbPessoasSemOrdem.AutoSize = true;
            this.rdbPessoasSemOrdem.Location = new System.Drawing.Point(12, 45);
            this.rdbPessoasSemOrdem.Name = "rdbPessoasSemOrdem";
            this.rdbPessoasSemOrdem.Size = new System.Drawing.Size(215, 17);
            this.rdbPessoasSemOrdem.TabIndex = 19;
            this.rdbPessoasSemOrdem.Text = "Visualizar pessoas físicas desagrupadas";
            this.rdbPessoasSemOrdem.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(172, 86);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(253, 86);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 17;
            this.btnGravar.Text = "Selecionar";
            this.btnGravar.UseVisualStyleBackColor = false;
            // 
            // AgrupamentoPessoaFisicaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 121);
            this.Controls.Add(this.rdbPessoasPorEmpresa);
            this.Controls.Add(this.rdbPessoasSemOrdem);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgrupamentoPessoaFisicaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgrupamentoPessoaFisicaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbPessoasPorEmpresa;
        private System.Windows.Forms.RadioButton rdbPessoasSemOrdem;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
    }
}