using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WindowsApp.Shared;
using LocadoraDeVeiculos.Dominio.LocacaoModule;


namespace LocadoraDeVeiculos.WindowsApp.Features.LocacaoModule
{
    class OperacoesLocacao : ICadastravel
    {
        private readonly ControladorPessoaFisica controlador = null;
        private readonly TabelaLocacao tabelaLocacao = null;

        public OperacoesPessoaFisica(ControladorPessoaFisica ctrl)
        {
            controlador = ctrl;
            tabelaLocacao = new TabelaLocacao();
        }


    }
}
