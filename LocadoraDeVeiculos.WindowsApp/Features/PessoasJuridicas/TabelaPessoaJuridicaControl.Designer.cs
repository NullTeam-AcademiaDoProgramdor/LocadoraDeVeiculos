
namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasJuridicas
{
    partial class TabelaPessoaJuridicaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridPessoasJuridicas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoasJuridicas)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPessoasJuridicas
            // 
            this.gridPessoasJuridicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPessoasJuridicas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPessoasJuridicas.Location = new System.Drawing.Point(0, 0);
            this.gridPessoasJuridicas.Name = "gridPessoasJuridicas";
            this.gridPessoasJuridicas.Size = new System.Drawing.Size(319, 321);
            this.gridPessoasJuridicas.TabIndex = 0;
            // 
            // TabelaPessoaJuridicaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridPessoasJuridicas);
            this.Name = "TabelaPessoaJuridicaControl";
            this.Size = new System.Drawing.Size(319, 321);
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoasJuridicas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPessoasJuridicas;
    }
}
