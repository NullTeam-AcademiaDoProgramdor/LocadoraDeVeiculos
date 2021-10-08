using LocadoraDeVeiculos.Controladores.TaxasEServicosModule;
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
        private List<TaxaEServico> taxasEServicos;
        public List<TaxaEServico> TaxasEServicos
        {
            get => taxasEServicos;
            set => taxasEServicos = value;
        }

        private List<TaxaEServico> taxasEServicosSelecionados = new List<TaxaEServico>();
        public List<TaxaEServico> TaxasEServicosSelecionados
        {
            get => taxasEServicosSelecionados;
            set
            {
                taxasEServicosSelecionados = value;
                GerarTextoDeSelecioandos(taxasEServicosSelecionados);
            }
        }

        public SeletorTaxasEServicosControl()
        {
            InitializeComponent();
        }

        private void btnSelecionarAdicionais_Click(object sender, EventArgs e)
        {
            SeletorTaxasEServicosForm tela
                = new SeletorTaxasEServicosForm(this.taxasEServicos);

            tela.SetarSelecionados(TaxasEServicosSelecionados);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                this.TaxasEServicosSelecionados = tela.TaxasEServicosSelecionados;
                GerarTextoDeSelecioandos(this.TaxasEServicosSelecionados);
            }
        }

        private void GerarTextoDeSelecioandos(List<TaxaEServico> taxasSelecioandas)
        {
            StringBuilder str = new StringBuilder();

            foreach (TaxaEServico taxa in taxasSelecioandas)
            {
                str.Append(taxa.Nome);
                str.Append(", ");
            }

            labelSelecionados.Text = str.ToString();
        }
    }
}
