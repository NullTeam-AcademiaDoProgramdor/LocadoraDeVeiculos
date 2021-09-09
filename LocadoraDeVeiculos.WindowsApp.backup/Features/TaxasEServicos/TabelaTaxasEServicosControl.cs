using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.WindowsApp.Shared;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;

namespace LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos
{
    public partial class TabelaTaxasEServicosControl : UserControl
    {
        public TabelaTaxasEServicosControl()
        {
            InitializeComponent();

            gridTaxasEServicos.ConfigurarGridZebrado();
            gridTaxasEServicos.ConfigurarGridSomenteLeitura();

            gridTaxasEServicos.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn {DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn {DataPropertyName = "Nome", HeaderText = "Nome"},
                new DataGridViewTextBoxColumn {DataPropertyName = "Preco", HeaderText = "Preço"},
                new DataGridViewTextBoxColumn {DataPropertyName = "EhFixo", HeaderText = "Tipo de Taxa/Serviço"}
            };
            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridTaxasEServicos.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<TaxaEServico> taxas)
        {
            gridTaxasEServicos.Rows.Clear();

            foreach (TaxaEServico taxaOuServico in taxas)
            {
                gridTaxasEServicos.Rows.Add(
                    taxaOuServico.Id,
                    taxaOuServico.Nome,
                    "R$" + taxaOuServico.Preco,
                    (taxaOuServico.EhFixo)? "Taxa fixa":"Taxa por dia"

                );
            }
        }
    }
}
