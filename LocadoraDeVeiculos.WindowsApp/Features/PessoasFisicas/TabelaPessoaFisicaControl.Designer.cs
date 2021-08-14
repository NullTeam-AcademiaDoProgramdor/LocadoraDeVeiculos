
namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasFisicas
{
    partial class TabelaPessoaFisicaControl
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
            this.gridPessoasFisicas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoasFisicas)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPessoasFisicas
            // 
            this.gridPessoasFisicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPessoasFisicas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPessoasFisicas.Location = new System.Drawing.Point(0, 0);
            this.gridPessoasFisicas.Name = "gridPessoasFisicas";
            this.gridPessoasFisicas.Size = new System.Drawing.Size(319, 321);
            this.gridPessoasFisicas.TabIndex = 0;
            // 
            // TabelaPessoaFisicaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridPessoasFisicas);
            this.Name = "TabelaPessoaFisicaControl";
            this.Size = new System.Drawing.Size(319, 321);
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoasFisicas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPessoasFisicas;
    }
}
