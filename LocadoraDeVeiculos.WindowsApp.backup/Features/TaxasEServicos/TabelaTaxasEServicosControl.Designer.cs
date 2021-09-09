
namespace LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos
{
    partial class TabelaTaxasEServicosControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridTaxasEServicos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridTaxasEServicos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTaxasEServicos
            // 
            this.gridTaxasEServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTaxasEServicos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTaxasEServicos.Location = new System.Drawing.Point(0, 0);
            this.gridTaxasEServicos.Name = "gridTaxasEServicos";
            this.gridTaxasEServicos.Size = new System.Drawing.Size(532, 463);
            this.gridTaxasEServicos.TabIndex = 0;
            // 
            // TabelaTaxasEServicosControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridTaxasEServicos);
            this.Name = "TabelaTaxasEServicosControl";
            this.Size = new System.Drawing.Size(532, 463);
            ((System.ComponentModel.ISupportInitialize)(this.gridTaxasEServicos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTaxasEServicos;
    }
}
