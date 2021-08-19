using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WindowsApp.Shared;

namespace LocadoraDeVeiculos.WindowsApp.Features.LocacaoModule
{
    class ConfiguracaoLocacaoToolBox : IConfiguracaoToolBox
    {
        public ConfiguracoesTooltip Tooltip
        {
            get
            {
                return new ConfiguracoesTooltip()
                {
                    TipoCadastro = "Cadastro de Locação",
                    ToolTipAdicionar = "Abrir uma nova Locação",
                    ToolTipEditar = "Editar uma locação existente",
                    ToolTipExcluir = "Excluir uma locação existente",
                    ToolTipAgrupar = "Agrupar locações",
                    ToolTípDesagrupar = "Desagrupar locações",
                    ToolTipFiltrar = "Filtrar locações",

                };
            }
        }

        public ConfiguracoesBotoes Botoes
        {
            get
            {
                return new ConfiguracoesBotoes()
                {
                    BtnFiltrar = true
                };
            }
        }
    }
}
