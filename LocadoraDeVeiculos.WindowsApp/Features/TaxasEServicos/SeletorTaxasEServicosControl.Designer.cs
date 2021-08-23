
namespace LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos
{
    partial class SeletorTaxasEServicosControl
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
            this.btnSelecionarAdicionais = new System.Windows.Forms.Button();
            this.labelSelecionados = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelecionarAdicionais
            // 
            this.btnSelecionarAdicionais.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSelecionarAdicionais.Location = new System.Drawing.Point(0, 0);
            this.btnSelecionarAdicionais.Name = "btnSelecionarAdicionais";
            this.btnSelecionarAdicionais.Size = new System.Drawing.Size(145, 29);
            this.btnSelecionarAdicionais.TabIndex = 16;
            this.btnSelecionarAdicionais.Text = "Selecionar adicionais";
            this.btnSelecionarAdicionais.UseVisualStyleBackColor = false;
            this.btnSelecionarAdicionais.Click += new System.EventHandler(this.btnSelecionarAdicionais_Click);
            // 
            // labelSelecionados
            // 
            this.labelSelecionados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelecionados.AutoEllipsis = true;
            this.labelSelecionados.Location = new System.Drawing.Point(3, 32);
            this.labelSelecionados.Name = "labelSelecionados";
            this.labelSelecionados.Size = new System.Drawing.Size(141, 13);
            this.labelSelecionados.TabIndex = 17;
            // 
            // SeletorTaxasEServicosControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSelecionados);
            this.Controls.Add(this.btnSelecionarAdicionais);
            this.Name = "SeletorTaxasEServicosControl";
            this.Size = new System.Drawing.Size(147, 48);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelecionarAdicionais;
        private System.Windows.Forms.Label labelSelecionados;
    }
}
