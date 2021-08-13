using LocadoraDeVeiculos.Controladores.AutomovelModule;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.Automoveis
{
    class OperacoesAutomovel : ICadastravel
    {
        private readonly ControladorAutomovel controlador = null;
        private readonly TabelaAutomovelControl tabelaAutomovel = null;

        public OperacoesAutomovel(ControladorAutomovel controlador)
        {
            this.controlador = controlador;
            tabelaAutomovel = new TabelaAutomovelControl();
        }

        public void InserirNovoRegistro()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            throw new NotImplementedException();
        }

        public void ExcluirRegistro()
        {
            throw new NotImplementedException();
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            throw new NotImplementedException();
        }

        public UserControl ObterTabela()
        {
            List<Automovel> automovels = controlador.SelecionarTodos();

            tabelaAutomovel.AtualizarRegistros(automovels);

            return tabelaAutomovel;
        }
    }
}
