
namespace LocadoraDeVeiculos.WindowsApp.Features.Automoveis
{
    partial class TabelaAutomovelControl
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
            this.gridAutomovel = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridAutomovel)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAutomovel
            // 
            this.gridAutomovel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAutomovel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAutomovel.Location = new System.Drawing.Point(0, 0);
            this.gridAutomovel.Name = "gridAutomovel";
            this.gridAutomovel.Size = new System.Drawing.Size(378, 319);
            this.gridAutomovel.TabIndex = 0;
            // 
            // TabelaAutomovelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridAutomovel);
            this.Name = "TabelaAutomovelControl";
            this.Size = new System.Drawing.Size(378, 319);
            ((System.ComponentModel.ISupportInitialize)(this.gridAutomovel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridAutomovel;
    }
}
