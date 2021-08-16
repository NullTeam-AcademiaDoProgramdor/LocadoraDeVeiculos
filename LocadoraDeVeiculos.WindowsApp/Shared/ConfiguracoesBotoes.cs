using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsApp.Shared
{
    public class ConfiguracoesBotoes
    {
        public ConfiguracoesBotoes()
        {
            BtnAdicionar = true;
            BtnEditar = true;
            BtnExcluir = true;

            BtnAgrupar = false;
            BtnFiltrar = false;
            btnExibirInformações = false;
        }

        public bool BtnAdicionar { get; internal set; }
        public bool BtnEditar { get; internal set; }
        public bool BtnExcluir { get; internal set; }
        public bool BtnFiltrar { get; internal set; }
        public bool BtnAgrupar { get; internal set; }
        public bool btnExibirInformações { get; internal set; }
    }
}
