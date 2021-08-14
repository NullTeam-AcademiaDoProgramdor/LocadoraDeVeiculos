using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
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

namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasFisicas
{
    public partial class TabelaPessoaFisicaControl : UserControl
    {
        Subro.Controls.DataGridViewGrouper gridPessoasFisicasAgrupadas;
        ControladorPessoaFisica controlador = new ControladorPessoaFisica();
        public TabelaPessoaFisicaControl()
        {
            InitializeComponent();
            gridPessoasFisicas.ConfigurarGridZebrado();
            gridPessoasFisicas.ConfigurarGridSomenteLeitura();
            gridPessoasFisicas.Columns.AddRange(ObterColunas());
            gridPessoasFisicasAgrupadas = new Subro.Controls.DataGridViewGrouper();
            controlador = new ControladorPessoaFisica();
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CPF", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "RG", HeaderText = "RG"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CNH", HeaderText = "CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "VencimentoCNH", HeaderText = "Vencimento da CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"},

                new DataGridViewTextBoxColumn { Name = "PessoaJuridica", DataPropertyName = "PessoaJuridica", HeaderText = "Empresa"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridPessoasFisicas.SelecionarId<int>();
        }

        public void AtualizarRegistros()
        {
            var pessoasFisicas = controlador.SelecionarTodos();

            CarregarTabela(pessoasFisicas);
        }

        private void CarregarTabela(List<PessoaFisica> pessoasFisicas)
        {
            gridPessoasFisicas.DataSource = pessoasFisicas.ConvertAll(c => c as PessoaFisica);

            gridPessoasFisicasAgrupadas = new Subro.Controls.DataGridViewGrouper(gridPessoasFisicas);
        }

        public void AgruparPessoasJuridicas(string campo)
        {
            gridPessoasFisicasAgrupadas.RemoveGrouping();
            gridPessoasFisicasAgrupadas.SetGroupOn(campo);
            gridPessoasFisicasAgrupadas.Options.ShowGroupName = false;

            foreach (DataGridViewColumn item in gridPessoasFisicas.Columns)
                if (item.DataPropertyName == campo)
                    item.Visible = false;

            gridPessoasFisicas.RowHeadersVisible = false;
            gridPessoasFisicas.ClearSelection();
        }

        public void DesagruparContatos(List<PessoaFisica> pessoasFisicas)
        {
            var campos = new string[] { "PessoaJuridica" };

            gridPessoasFisicasAgrupadas.RemoveGrouping();
            gridPessoasFisicas.RowHeadersVisible = true;

            foreach (var campo in campos)
                foreach (DataGridViewColumn item in gridPessoasFisicas.Columns)
                    if (item.DataPropertyName == campo)
                        item.Visible = true;
        }

    }
}
