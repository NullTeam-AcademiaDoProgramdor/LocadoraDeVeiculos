
namespace LocadoraDeVeiculos.WindowsApp.Features.GruposAutomovel
{
    partial class TabelaGrupoAutomovelControl
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
            this.gridGrupoAutomovel = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoAutomovel)).BeginInit();
            this.SuspendLayout();
            // 
            // gridGrupoAutomovel
            // 
            this.gridGrupoAutomovel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGrupoAutomovel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGrupoAutomovel.Location = new System.Drawing.Point(0, 0);
            this.gridGrupoAutomovel.Name = "gridGrupoAutomovel";
            this.gridGrupoAutomovel.Size = new System.Drawing.Size(406, 355);
            this.gridGrupoAutomovel.TabIndex = 0;
            // 
            // TabelaGrupoAutomovelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridGrupoAutomovel);
            this.Name = "TabelaGrupoAutomovelControl";
            this.Size = new System.Drawing.Size(406, 355);
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoAutomovel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridGrupoAutomovel;
    }
}
