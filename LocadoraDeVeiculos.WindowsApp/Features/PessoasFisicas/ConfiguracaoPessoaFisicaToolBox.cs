using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasFisicas
{
    public class ConfiguracaoPessoaFisicaToolBox : IConfiguracaoToolBox
    {
        public ConfiguracoesTooltip Tooltip
        {
            get
            {
                return new ConfiguracoesTooltip()
                {
                    TipoCadastro = "Cadastro de Pessoa Física",
                    ToolTipAdicionar = "Adicionar uma nova Pessoa Física",
                    ToolTipEditar = "Editar uma Pessoa Física existente",
                    ToolTipExcluir = "Excluir uma Pessoa Física existente",
                    ToolTipAgrupar = "Agrupar Pessoas Físicas",
                    ToolTípDesagrupar = "Desagrupar Pessoas Físicas",
                    ToolTipExibirInformacoes = "Visualizar Informações detalhadas de uma Pessoa Física",
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
