using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsApp.Shared
{
    public class ConfiguracoesTooltip
    {
        public ConfiguracoesTooltip()
        {
            ToolTipAdicionar = "Não é possivel inserir este cadastro";
            ToolTipEditar = "Não é possivel editar este cadastro";
            ToolTipExcluir = "Não é possivel excluir este cadastro";
            ToolTipFiltrar = "Não é possivel filtrar este cadastro";
            ToolTipAgrupar = "Não é possivel agrupar este cadastro";
            ToolTípDesagrupar = "Não é possivel desagrupar este cadastro";
            ToolTipExibirInformacoes = "Não é possivel visualizar todas as" +
                " informações deste cadastro";
        }

        public string TipoCadastro { get; internal set; }
        public string ToolTipAdicionar { get; internal set; }
        public string ToolTipEditar { get; internal set; }
        public string ToolTipExcluir { get; internal set; }
        public string ToolTipFiltrar { get; internal set; }
        public string ToolTipAgrupar { get; internal set; }
        public string ToolTípDesagrupar { get; internal set; }
        public string ToolTipExibirInformacoes { get; internal set; }
    }
}
