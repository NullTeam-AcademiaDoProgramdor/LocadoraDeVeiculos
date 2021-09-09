
namespace LocadoraDeVeiculos.WindowsApp.Features.Parceiros
{
    partial class TabelaParceiroControl
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
            this.gridParceiros = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridParceiros)).BeginInit();
            this.SuspendLayout();
            // 
            // gridParceiros
            // 
            this.gridParceiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridParceiros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridParceiros.Location = new System.Drawing.Point(0, 0);
            this.gridParceiros.Name = "gridParceiros";
            this.gridParceiros.Size = new System.Drawing.Size(253, 263);
            this.gridParceiros.TabIndex = 0;
            // 
            // TabelaParceiroControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridParceiros);
            this.Name = "TabelaParceiroControl";
            this.Size = new System.Drawing.Size(253, 263);
            ((System.ComponentModel.ISupportInitialize)(this.gridParceiros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridParceiros;
    }
}
