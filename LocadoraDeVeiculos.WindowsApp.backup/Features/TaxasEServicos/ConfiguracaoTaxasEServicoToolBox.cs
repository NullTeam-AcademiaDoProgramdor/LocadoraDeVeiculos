using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WindowsApp.Shared;

namespace LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos
{
    class ConfiguracaoTaxasEServicoToolBox : IConfiguracaoToolBox
    {
        public ConfiguracoesTooltip Tooltip
        {
            get
            {
                return new ConfiguracoesTooltip()
                {
                    TipoCadastro = "Cadastro de Taxas e Serviços",
                    ToolTipAdicionar = "Adicionar uma nova Taxa ou Serviço",
                    ToolTipEditar = "Editar uma Taxa ou Serviço existente",
                    ToolTipExcluir = "Excluir uma Taxa ou Serviço existente"
                    
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
