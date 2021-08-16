using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsApp.Features.Automoveis
{
    class ConfiguracaoAutomovelTooBox : IConfiguracaoToolBox
    {
       public ConfiguracoesTooltip Tooltip
       {
            get
            {
                return new ConfiguracoesTooltip()
                {
                    TipoCadastro = "Cadastro de Automoveis",
                    ToolTipAdicionar = "Adicionar um novo Automovel",
                    ToolTipEditar = "Editar um Automovel existente",
                    ToolTipExcluir = "Excluir um Automovel existente",
                    ToolTipAgrupar = "Agrupar Automoveis pelo seu Grupo",
                    ToolTípDesagrupar = "Mostrar todos os Automoveis",
                    ToolTipExibirInformacoes = "Visualizar Informações detalhadas" +
                    " de um Automóvel",
                };
            }
       }

        public ConfiguracoesBotoes Botoes
        {
            get
            {
                return new ConfiguracoesBotoes()
                {
                    BtnAgrupar = true,
                    btnExibirInformações = true
                };
            }
        }
    }
}
