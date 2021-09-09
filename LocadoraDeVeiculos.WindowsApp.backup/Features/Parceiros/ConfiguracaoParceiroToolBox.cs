using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsApp.Features.Parceiros
{
    public class ConfiguracaoParceiroToolBox : IConfiguracaoToolBox
    {
        public ConfiguracoesTooltip Tooltip
        {
            get
            {
                return new ConfiguracoesTooltip()
                {
                    TipoCadastro = "Cadastro de Parceiro",
                    ToolTipAdicionar = "Adicionar um Parceiro",
                    ToolTipEditar = "Editar um Parceiro existente",
                    ToolTipExcluir = "Excluir um Parceiro existente",

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
