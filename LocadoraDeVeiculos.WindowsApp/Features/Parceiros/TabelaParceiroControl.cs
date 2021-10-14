using LocadoraDeVeiculos.Controladores.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
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

namespace LocadoraDeVeiculos.WindowsApp.Features.Parceiros
{
    public partial class TabelaParceiroControl : UserControl
    {
        ControladorParceiro controlador = new ControladorParceiro();
        public TabelaParceiroControl()
        {
            InitializeComponent();
            gridParceiros.ConfigurarGridZebrado();
            gridParceiros.ConfigurarGridSomenteLeitura();
            gridParceiros.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridParceiros.SelecionarId<int>();
        }
        public void AtualizarRegistros(List<Parceiro> parceiros)
        {
            CarregarTabela(parceiros);
        }
        private void CarregarTabela(List<Parceiro> parceiros)
        {
            gridParceiros.DataSource = parceiros;
        }
    }
}
