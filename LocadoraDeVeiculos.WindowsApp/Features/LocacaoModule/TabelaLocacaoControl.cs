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
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Controladores.LocacaoModule;

namespace LocadoraDeVeiculos.WindowsApp.Features.LocacaoModule
{
    public partial class TabelaLocacaoControl : UserControl
    {
        ControladorLocacao controlador = null;

        public TabelaLocacaoControl()
        {
            InitializeComponent();
            gridLocacao.ConfigurarGridZebrado();
            gridLocacao.ConfigurarGridSomenteLeitura();

            gridLocacao.Columns.AddRange(ObterColunas());
            ConfigurarFormatacaoColunasDatas();

            controlador = new ControladorLocacao();
        }

        private void ConfigurarFormatacaoColunasDatas()
        {
            gridLocacao.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            gridLocacao.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Automovel", HeaderText = "Automóvel"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Funcionario", HeaderText = "Funcionario que locou"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataSaida", HeaderText = "Data de saída do veículo" },

                new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucaoEsperada", HeaderText = "Devolução planejada para", },

                new DataGridViewTextBoxColumn { DataPropertyName = "Situacao", HeaderText = "Situação"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridLocacao.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            CarregarTabela(locacoes);
        }

        private void CarregarTabela(List<Locacao> locacoes)
        {
            gridLocacao.DataSource = locacoes;            
        }

        internal void SetOnClick(EventHandler panelRegistros_Click)
        {
            gridLocacao.SelectionChanged += panelRegistros_Click;
        }
    }
}
