using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsApp.Features.GruposAutomovel
{
    class ConfiguracaoGrupoAutomovelToolBox : IConfiguracaoToolBox
    {
        public ConfiguracoesTooltip Tooltip
        {
            get
            {
                return new ConfiguracoesTooltip()
                {
                    TipoCadastro = "Cadastro de Grupo de Automovel",
                    ToolTipAdicionar = "Adicionar um novo Grupo de Automovel",
                    ToolTipEditar = "Editar um Grupo de Automovel existente",
                    ToolTipExcluir = "Excluir um Grupo de Automovel existente"
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
