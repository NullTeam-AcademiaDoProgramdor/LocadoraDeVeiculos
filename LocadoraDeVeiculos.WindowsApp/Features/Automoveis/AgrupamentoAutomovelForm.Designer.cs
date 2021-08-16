
namespace LocadoraDeVeiculos.WindowsApp.Features.Automoveis
{
    partial class AgrupamentoAutomovelForm
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
            this.rdbAutomovelPorGrupo = new System.Windows.Forms.RadioButton();
            this.rdbAutomovelDesagrupado = new System.Windows.Forms.RadioButton();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbAutomovelPorGrupo
            // 
            this.rdbAutomovelPorGrupo.AutoSize = true;
            this.rdbAutomovelPorGrupo.Location = new System.Drawing.Point(12, 29);
            this.rdbAutomovelPorGrupo.Name = "rdbAutomovelPorGrupo";
            this.rdbAutomovelPorGrupo.Size = new System.Drawing.Size(174, 17);
            this.rdbAutomovelPorGrupo.TabIndex = 17;
            this.rdbAutomovelPorGrupo.TabStop = true;
            this.rdbAutomovelPorGrupo.Text = "Visualizar automóveis por grupo";
            this.rdbAutomovelPorGrupo.UseVisualStyleBackColor = true;
            // 
            // rdbAutomovelDesagrupado
            // 
            this.rdbAutomovelDesagrupado.AutoSize = true;
            this.rdbAutomovelDesagrupado.Location = new System.Drawing.Point(12, 63);
            this.rdbAutomovelDesagrupado.Name = "rdbAutomovelDesagrupado";
            this.rdbAutomovelDesagrupado.Size = new System.Drawing.Size(196, 17);
            this.rdbAutomovelDesagrupado.TabIndex = 18;
            this.rdbAutomovelDesagrupado.TabStop = true;
            this.rdbAutomovelDesagrupado.Text = "Visualizar automóveis desagrupados";
            this.rdbAutomovelDesagrupado.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(253, 101);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 19;
            this.btnGravar.Text = "Selecionar";
            this.btnGravar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(172, 101);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // AgrupamentoAutomovelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 136);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.rdbAutomovelDesagrupado);
            this.Controls.Add(this.rdbAutomovelPorGrupo);
            this.Name = "AgrupamentoAutomovelForm";
            this.Text = "AgrupamentoAutomovelForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rdbAutomovelPorGrupo;
        private System.Windows.Forms.RadioButton rdbAutomovelDesagrupado;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
    }
}