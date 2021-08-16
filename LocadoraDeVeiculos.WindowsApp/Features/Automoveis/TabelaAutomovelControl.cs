using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.WindowsApp.Shared;


namespace LocadoraDeVeiculos.WindowsApp.Features.Automoveis
{
    public partial class TabelaAutomovelControl : UserControl
    {
        Subro.Controls.DataGridViewGrouper grupperAutomoveis = 
            new Subro.Controls.DataGridViewGrouper();
        public TabelaAutomovelControl()
        {
            InitializeComponent();

            gridAutomovel.ConfigurarGridZebrado();
            gridAutomovel.ConfigurarGridSomenteLeitura();

            gridAutomovel.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn {DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn {DataPropertyName = "Modelo", HeaderText = "Modelo"},
                new DataGridViewTextBoxColumn {DataPropertyName = "Marca", HeaderText = "Marca"},
                new DataGridViewTextBoxColumn {DataPropertyName = "Placa", HeaderText = "Placa"},
                new DataGridViewTextBoxColumn {DataPropertyName = "Chassi", HeaderText = "Chassi"},
                new DataGridViewTextBoxColumn {DataPropertyName = "Grupo", HeaderText = "Grupo"},
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridAutomovel.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Automovel> automoveis)
        {
            gridAutomovel.DataSource = automoveis;

            grupperAutomoveis = new Subro.Controls.DataGridViewGrouper(gridAutomovel);
        }

        public void AgruparRegistrosPorGrupo()
        {
            DesagruparRegistros();

            grupperAutomoveis.SetGroupOn("Grupo");
            EsconderColuna("Grupo");
        }

        public void DesagruparRegistros()
        {
            grupperAutomoveis.RemoveGrouping();
            ExibirTodasColunas();
        }

        private void EsconderColuna(string nomeColuna)
        {
            foreach (DataGridViewColumn col in gridAutomovel.Columns)
            {
                if (col.DataPropertyName == nomeColuna)
                    col.Visible = false;
            }
        }

        private void ExibirTodasColunas()
        {
            foreach (DataGridViewColumn col in gridAutomovel.Columns)
            {
                col.Visible = true;
            }
        }

        internal void AgruparAutomoveis(string campo)
        {
            grupperAutomoveis.RemoveGrouping();
            grupperAutomoveis.SetGroupOn(campo);
            grupperAutomoveis.Options.ShowGroupName = false;

            foreach (DataGridViewColumn item in gridAutomovel.Columns)
                if (item.DataPropertyName == campo)
                    item.Visible = false;

            gridAutomovel.RowHeadersVisible = false;
            gridAutomovel.ClearSelection();
        }

        internal void DesagruparCompromissos(List<Automovel> automoveis)
        {
            var campos = new string[] { "Grupo" };

            grupperAutomoveis.RemoveGrouping();
            gridAutomovel.RowHeadersVisible = true;

            foreach (var campo in campos)
                foreach (DataGridViewColumn item in gridAutomovel.Columns)
                    if (item.DataPropertyName == campo)
                        item.Visible = true;
        }
    }
}
