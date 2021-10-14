using LocadoraDeVeiculos.Controladores.PessoaJuridicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
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

namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasJuridicas
{
    public partial class TabelaPessoaJuridicaControl : UserControl
    {
        Subro.Controls.DataGridViewGrouper gridPessoasJuridicasAgrupadas = new Subro.Controls.DataGridViewGrouper();
        ControladorPessoaJuridica controlador = new ControladorPessoaJuridica();
        public TabelaPessoaJuridicaControl()
        {
            InitializeComponent();
            gridPessoasJuridicas.ConfigurarGridZebrado();
            gridPessoasJuridicas.ConfigurarGridSomenteLeitura();
            gridPessoasJuridicas.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cnpj", HeaderText = "CNPJ"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "E-mail"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridPessoasJuridicas.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<PessoaJuridica> pessoasJuridicas)
        {
            CarregarTabela(pessoasJuridicas);
        }
        private void CarregarTabela(List<PessoaJuridica> pessoasJuridicas)
        {
            gridPessoasJuridicas.DataSource = pessoasJuridicas;

            gridPessoasJuridicasAgrupadas = new Subro.Controls.DataGridViewGrouper(gridPessoasJuridicas);
        }
    }
}
