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
    public partial class SeletorTaxasEServicosControl : UserControl
    {
        private TaxaEServico[] taxasEServicos;
        public TaxaEServico[] TaxasEServicosSelecionados { get; private set; }
        private SeletorTaxasEServicosControl()
        {
            InitializeComponent();
        }

        public SeletorTaxasEServicosControl(TaxaEServico[] taxasEServicos)
        {
            InitializeComponent();

            this.taxasEServicos = taxasEServicos;
        }

        private void btnSelecionarAdicionais_Click(object sender, EventArgs e)
        {
            SeletorTaxasEServicosForm tela 
                = new SeletorTaxasEServicosForm(this.taxasEServicos);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                this.TaxasEServicosSelecionados = tela.TaxasEServicosSelecionados;
                GerarTextoDeSelecioandos(this.TaxasEServicosSelecionados);
            }
        }

        private void GerarTextoDeSelecioandos(TaxaEServico[] taxasSelecioandas)
        {
            StringBuilder str = new StringBuilder();

            foreach (var taxaESevico in taxasEServicos)
            {
                str.Append(taxaESevico.Nome);
                str.Append(", ");
            }

            labelSelecionados.Text = str.ToString();
        }
    }
}
