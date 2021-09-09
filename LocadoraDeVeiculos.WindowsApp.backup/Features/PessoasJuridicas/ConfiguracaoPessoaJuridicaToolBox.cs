using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasJuridicas
{
    public class ConfiguracaoPessoaJuridicaToolBox : IConfiguracaoToolBox
    {
        public ConfiguracoesTooltip Tooltip
        {
            get
            {
                return new ConfiguracoesTooltip()
                {
                    TipoCadastro = "Cadastro de Pessoa Jurídica",
                    ToolTipAdicionar = "Adicionar uma nova Pessoa Jurídica",
                    ToolTipEditar = "Editar uma Pessoa Jurídica existente",
                    ToolTipExcluir = "Excluir uma Pessoa Jurídica existente",

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
