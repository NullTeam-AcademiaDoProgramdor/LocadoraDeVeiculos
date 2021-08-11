using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsApp.Features.FuncionarioModule
{
    class ConfiguacaoFuncionarioToolBox : IConfiguracaoToolBox
    {
        public ConfiguracoesTooltip Tooltip
        {
            get
            {
                return new ConfiguracoesTooltip()
                {
                    TipoCadastro = "Cadastro de Funcionários",
                    ToolTipAdicionar = "Adicionar um novo Funcionário",
                    ToolTipEditar = "Editar um Funcionário existente",
                    ToolTipExcluir = "Excluir um Funcionário existente"
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
