using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsApp.Shared
{
    interface IConfiguracaoToolBox
    {
        ConfiguracoesTooltip Tooltip { get; }

        ConfiguracoesBotoes Botoes { get; }
    }
}
