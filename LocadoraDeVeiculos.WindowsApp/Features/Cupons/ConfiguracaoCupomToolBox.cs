using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsApp.Features.Cupons
{
    class ConfiguracaoCupomToolBox : IConfiguracaoToolBox
    {
        public ConfiguracoesTooltip Tooltip
        {
            get
            {
                return new ConfiguracoesTooltip()
                {
                    TipoCadastro = "Cadastro de Cupom",
                    ToolTipAdicionar = "Cadastrar cupom",
                    ToolTipEditar = "Editar um cupom existente",
                    ToolTipExcluir = "Excluir um cupom existente",
                    ToolTipAgrupar = "Agrupar Cupons",
                    ToolTípDesagrupar = "Desagrupar Cupons",
                    ToolTipFiltrar = "Filtrar Cupons",

                };
            }
        }

        public ConfiguracoesBotoes Botoes
        {
            get
            {
                return new ConfiguracoesBotoes();
            }
        }
    }
}
