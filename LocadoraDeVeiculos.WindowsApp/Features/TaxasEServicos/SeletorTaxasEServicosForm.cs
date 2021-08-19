using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos
{
    public partial class SeletorTaxasEServicosForm : Form
    {
        private TaxaEServico[] taxaEServicos;
        public TaxaEServico[] TaxasEServicosSelecionados { get; set; }

        private SeletorTaxasEServicosForm()
        {
            InitializeComponent();
        }

        public SeletorTaxasEServicosForm(TaxaEServico[] taxasEServicos)
        {
            InitializeComponent();

            this.taxaEServicos = taxasEServicos;

            CriarTabelaDeCheckboxs();
        }

        public void SetarSelecionados(TaxaEServico[] taxaEServicosParaSelecionar)
        {
            var controlsList = tableTaxaEServicos.Controls;

            for (int i = 0; i < taxaEServicosParaSelecionar.Length; i++)
            {
                for (int j = 0; j < taxaEServicos.Length; j++)
                {
                    if (taxaEServicosParaSelecionar[i].Id == taxaEServicos[j].Id)
                    {
                        var check = controlsList[j] as CheckBox;
                        check.Checked = true;
                    }
                }
            }
            
        }

        private void CriarTabelaDeCheckboxs()
        {
            tableTaxaEServicos.Controls.Clear();
            tableTaxaEServicos.RowStyles.Clear();
            tableTaxaEServicos.RowCount = taxaEServicos.Length;

            for (int i = 0; i < taxaEServicos.Length; i++)
            {
                TaxaEServico taxaEServico = taxaEServicos[i];

                tableTaxaEServicos.RowStyles.Add(new RowStyle());

                tableTaxaEServicos.Controls.Add(
                    CriarCheckBox(taxaEServico.Nome, i),
                    0,
                    i
                );
            }
        }

        private CheckBox CriarCheckBox(string nome, int i)
        {
            CheckBox checkBox = new CheckBox();

            checkBox.AutoSize = true;
            checkBox.Name = $"checkBox{i}";
            checkBox.TabIndex = i;
            checkBox.Text = nome;
            checkBox.UseVisualStyleBackColor = true;

            return checkBox;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            var controlsList = tableTaxaEServicos.Controls;
            var tempTaxasEServicos = new List<TaxaEServico>();

            for (int i = 0; i < controlsList.Count; i++)
            {
                Control control = controlsList[i];

                if (!(control is CheckBox))
                    continue;

                CheckBox check = control as CheckBox;

                if (check.Checked)
                    tempTaxasEServicos.Add(this.taxaEServicos[i]);
            }

            this.TaxasEServicosSelecionados = tempTaxasEServicos.ToArray();
        }
    }
}
