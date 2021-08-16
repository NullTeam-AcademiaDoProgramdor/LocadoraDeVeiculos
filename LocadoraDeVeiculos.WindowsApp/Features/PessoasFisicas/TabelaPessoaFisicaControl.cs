using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.WindowsApp.Features.PessoasJuridicas;
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
        private Subro.Controls.DataGridViewGrouper gridPessoasFisicasAgrupadas;
        ControladorPessoaFisica controlador = new ControladorPessoaFisica();
        private FiltroPessoaFisicaEnum filtroPFisicaCache = FiltroPessoaFisicaEnum.PessoaSemOrdem;
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
            gridPessoasFisicas.DataSource = pessoasFisicas;

            gridPessoasFisicasAgrupadas = new Subro.Controls.DataGridViewGrouper(gridPessoasFisicas);
        }

        public void AgruparRegistros(FiltroPessoaFisicaEnum filtroPFisica)
        {
            filtroPFisicaCache = filtroPFisica;

            switch (filtroPFisica)
            {
                case FiltroPessoaFisicaEnum.PessoaPorEmpresa:
                    AgruparPessoaFisicaPorEmpresa();
                    break;

                case FiltroPessoaFisicaEnum.PessoaSemOrdem:
                    DesagruparRegistros();
                    break;
            }
        }
        
        public void AgruparRegistros()
        {
            AgruparRegistros(filtroPFisicaCache);
        }

        private void AgruparPessoaFisicaPorEmpresa()
        {
            DesagruparRegistros();

            gridPessoasFisicasAgrupadas.SetGroupOn("PessoaJuridica");

            EsconderColuna("PessoaJuridica");
        }

        private void EsconderColuna(string campo)
        {
            foreach (DataGridViewColumn col in gridPessoasFisicas.Columns)
            {
                if (col.Name == campo)
                    col.Visible = false;
            }
        }

        public void DesagruparRegistros()
        {
            gridPessoasFisicasAgrupadas.RemoveGrouping();
            ExibirTodasColunas();
        }

        private void ExibirTodasColunas()
        {
            gridPessoasFisicasAgrupadas.RemoveGrouping();
            gridPessoasFisicas.RowHeadersVisible = true;

            foreach (DataGridViewColumn col in gridPessoasFisicas.Columns)
                if (col.DataPropertyName == "PessoaJuridica")
                    col.Visible = true;
        }
    }
}
