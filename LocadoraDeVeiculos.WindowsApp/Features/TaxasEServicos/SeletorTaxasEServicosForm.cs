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
        private List<TaxaEServico> taxaEServicos;
        public List<TaxaEServico> TaxasEServicosSelecionados { get; set; }

        private SeletorTaxasEServicosForm()
        {
            InitializeComponent();
        }

        public SeletorTaxasEServicosForm(List<TaxaEServico> taxasEServicos)
        {
            InitializeComponent();

            this.taxaEServicos = taxasEServicos;

            CriarTabelaDeCheckboxs();
        }

        public void SetarSelecionados(List<TaxaEServico> taxaEServicosParaSelecionar)
        {
            var controlsList = tableTaxaEServicos.Controls;

            for (int i = 0; i < taxaEServicosParaSelecionar.Count; i++)
            {
                for (int j = 0; j < taxaEServicos.Count; j++)
                {
                    if (taxaEServicosParaSelecionar[i].Id == taxaEServicos[j].Id)
                    {
                        var check = controlsList[(j+1) * 3] as CheckBox;
                        check.Checked = true;
                        break;
                    }
                }
            }
            
        }

        private void CriarTabelaDeCheckboxs()
        {
            //TODO: Trocar para CheckListBox para aumentar o desempenho
            tableTaxaEServicos.Controls.Clear();
            tableTaxaEServicos.RowStyles.Clear();
            tableTaxaEServicos.RowCount = taxaEServicos.Count;

            tableTaxaEServicos.Controls.Add(
                    new Label()
                    {
                        Text = "Nome"
                    },
                    0,
                    0
                 );

            tableTaxaEServicos.Controls.Add(
                   new Label()
                   {
                       Text = "Preço"
                   },
                   1,
                   0
                );

            tableTaxaEServicos.Controls.Add(
                   new Label()
                   {
                       Text = "Tipo"
                   },
                   2,
                   0
                );

            for (int i = 0; i < taxaEServicos.Count; i++)
            {
                TaxaEServico taxaEServico = taxaEServicos[i];

                tableTaxaEServicos.RowStyles.Add(new RowStyle());

                tableTaxaEServicos.Controls.Add(
                    CriarCheckBox(taxaEServico.Nome, i),
                    0,
                    i+1
                );

                tableTaxaEServicos.Controls.Add(
                    new Label()
                    {
                        Text = "R$" + taxaEServico.Preco
                    },

                    1,
                    i+1
                 );
                    
                tableTaxaEServicos.Controls.Add(
                    new Label()
                    {
                        Text = (taxaEServico.EhFixo) ? "(Fixo)" : "(Por dia)",
                    },

                    2,
                    i+1
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

            for (int i = 0; i < controlsList.Count; i += 3)
            {
                Control control = controlsList[i];

                if (!(control is CheckBox))
                    continue;

                CheckBox check = control as CheckBox;

                if (check.Checked)
                    tempTaxasEServicos.Add(this.taxaEServicos[(i / 3) - 1]);
            }

            this.TaxasEServicosSelecionados = tempTaxasEServicos.ToList();
        }
    }
}
