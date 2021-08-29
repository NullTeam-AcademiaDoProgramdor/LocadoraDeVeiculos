
namespace LocadoraDeVeiculos.WindowsApp.Features.Cupons
{
    partial class TabelaCupomControl
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
            this.GridCupom = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridCupom)).BeginInit();
            this.SuspendLayout();
            // 
            // GridCupom
            // 
            this.GridCupom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridCupom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridCupom.Location = new System.Drawing.Point(0, 0);
            this.GridCupom.Name = "GridCupom";
            this.GridCupom.Size = new System.Drawing.Size(301, 294);
            this.GridCupom.TabIndex = 0;
            // 
            // TabelaCupomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridCupom);
            this.Name = "TabelaCupomControl";
            this.Size = new System.Drawing.Size(301, 294);
            ((System.ComponentModel.ISupportInitialize)(this.GridCupom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridCupom;
    }
}
