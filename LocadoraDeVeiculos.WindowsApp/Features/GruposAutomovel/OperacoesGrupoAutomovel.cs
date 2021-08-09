using LocadoraDeVeiculos.Controladores.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.GruposAutomovel
{
    class OperacoesGrupoAutomovel : ICadastravel
    {

        private readonly ControladorGrupoAutomovel controlador = null;
        private readonly TabelaGrupoAutomovelControl tabelaGrupoAutomovel = null;

        public OperacoesGrupoAutomovel(ControladorGrupoAutomovel controlador)
        {
            this.controlador = controlador;
            tabelaGrupoAutomovel = new TabelaGrupoAutomovelControl();
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
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

        public void InserirNovoRegistro()
        {
            throw new NotImplementedException();
        }

        public UserControl ObterTabela()
        {
            List<GrupoAutomovel> grupos = controlador.SelecionarTodos();

            tabelaGrupoAutomovel.AtualizarRegistros(grupos);

            return tabelaGrupoAutomovel;
        }
    }
}
