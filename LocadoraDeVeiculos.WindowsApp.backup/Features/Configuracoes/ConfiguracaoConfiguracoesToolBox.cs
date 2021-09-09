using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsApp.Features.Configuracoes
{
    class ConfiguracaoConfiguracoesToolBox : IConfiguracaoToolBox
    {
        public ConfiguracoesTooltip Tooltip
        {
            get
            {
                return new ConfiguracoesTooltip()
                {
                    TipoCadastro = "Configurações"
                };
            }
        }

        public ConfiguracoesBotoes Botoes
        {
            get
            {
                return new ConfiguracoesBotoes()
                {
                    BtnAdicionar = false,
                    BtnEditar = false,
                    BtnExcluir = false
                };
            }
        }
    }
}
