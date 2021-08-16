
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgrupamentoAutomovelForm));
            this.rdbAutomovelPorGrupo = new System.Windows.Forms.RadioButton();
            this.rdbAutomovelDesagrupado = new System.Windows.Forms.RadioButton();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbAutomovelPorGrupo
            // 
            resources.ApplyResources(this.rdbAutomovelPorGrupo, "rdbAutomovelPorGrupo");
            this.rdbAutomovelPorGrupo.Name = "rdbAutomovelPorGrupo";
            this.rdbAutomovelPorGrupo.TabStop = true;
            this.rdbAutomovelPorGrupo.UseVisualStyleBackColor = true;
            // 
            // rdbAutomovelDesagrupado
            // 
            resources.ApplyResources(this.rdbAutomovelDesagrupado, "rdbAutomovelDesagrupado");
            this.rdbAutomovelDesagrupado.Name = "rdbAutomovelDesagrupado";
            this.rdbAutomovelDesagrupado.TabStop = true;
            this.rdbAutomovelDesagrupado.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnGravar, "btnGravar");
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // AgrupamentoAutomovelForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.rdbAutomovelDesagrupado);
            this.Controls.Add(this.rdbAutomovelPorGrupo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgrupamentoAutomovelForm";
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