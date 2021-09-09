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
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;

namespace LocadoraDeVeiculos.WindowsApp.Features.GruposAutomovel
{
    public partial class TabelaGrupoAutomovelControl : UserControl
    {
        public TabelaGrupoAutomovelControl()
        {
            InitializeComponent();

            gridGrupoAutomovel.ConfigurarGridZebrado();
            gridGrupoAutomovel.ConfigurarGridSomenteLeitura();

            gridGrupoAutomovel.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn {DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn {DataPropertyName = "Nome", HeaderText = "Nome"},
                
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridGrupoAutomovel.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<GrupoAutomovel> grupos)
        {
            gridGrupoAutomovel.Rows.Clear();

            foreach (GrupoAutomovel grupo in grupos)
            {
                gridGrupoAutomovel.Rows.Add(
                    grupo.Id,
                    grupo.Nome
                );
            }
        }
    }
}
