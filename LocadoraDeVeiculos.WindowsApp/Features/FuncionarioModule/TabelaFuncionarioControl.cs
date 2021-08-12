using LocadoraDeVeiculos.Dominio.FuncionarioModule;
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

namespace LocadoraDeVeiculos.WindowsApp.Features
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
        {
            InitializeComponent();

            gridFuncionario.ConfigurarGridZebrado();
            gridFuncionario.ConfigurarGridSomenteLeitura();

            gridFuncionario.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn {DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn {DataPropertyName = "Nome", HeaderText = "Nome"},
                new DataGridViewTextBoxColumn {DataPropertyName = "Salario", HeaderText = "Salário"},
                new DataGridViewTextBoxColumn {DataPropertyName = "DataAdmissao", HeaderText = "Data de Admissão"},
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridFuncionario.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            gridFuncionario.Rows.Clear();

            foreach (Funcionario funcionario in funcionarios)
            {
                gridFuncionario.Rows.Add(
                    funcionario.Id,
                    funcionario.Nome,
                    "R$" + funcionario.Salario,
                    funcionario.DataAdmissao
                );
            }

        }
    }
}
