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
                new DataGridViewTextBoxColumn {DataPropertyName = "PlanoDiario.PrecoDia", HeaderText = "Preço por dia (Plano Diario)"},
                new DataGridViewTextBoxColumn {DataPropertyName = "PlanoDiario.PrecoKm", HeaderText = "Preço por Km (Plano Diario)"},
                new DataGridViewTextBoxColumn {DataPropertyName = "PlanoKmControlado.PrecoDia", HeaderText = "Preço por Dia (Plano Controlado)"},
                new DataGridViewTextBoxColumn {DataPropertyName = "PlanoKmControlado.KmDisponiveis", HeaderText = "Km Disponiveis (Plano Controlado)"},
                new DataGridViewTextBoxColumn {DataPropertyName = "PlanoKmControlado.PrecoKmExtrapolado", HeaderText = "Preço Km Extrapolado (Plano Controlado)"},
                new DataGridViewTextBoxColumn {DataPropertyName = "PlanoKmLivre.PrecoDia", HeaderText = "Preço por dia (Plano Livre)"},
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
                    grupo.Nome,
                    grupo.PlanoDiario.PrecoDia,
                    grupo.PlanoDiario.PrecoKm,
                    grupo.PlanoKmControlado.PrecoDia,
                    grupo.PlanoKmControlado.KmDisponiveis,
                    grupo.PlanoKmControlado.PrecoKmExtrapolado,
                    grupo.PlanoKmLivre.PrecoDia
                );
            }
        }
    }
}
