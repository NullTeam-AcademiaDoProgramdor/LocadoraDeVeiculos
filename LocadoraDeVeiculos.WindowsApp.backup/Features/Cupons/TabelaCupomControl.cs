using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.Cupons
{
    public partial class TabelaCupomControl : UserControl
    {
        public TabelaCupomControl()
        {
            InitializeComponent();
            GridCupom.ConfigurarGridZebrado();
            GridCupom.ConfigurarGridSomenteLeitura();

            GridCupom.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Código"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Parceiro", HeaderText = "Parceiro"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo", HeaderText = "Tipo" },

                new DataGridViewTextBoxColumn { DataPropertyName = "DataVencimento", HeaderText = "Data de Vencimento"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return GridCupom.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Cupom> cupons)
        {
            CarregarTabela(cupons);
        }

        private void CarregarTabela(List<Cupom> cupons)
        {
            GridCupom.DataSource = cupons;
        }
    }
}
