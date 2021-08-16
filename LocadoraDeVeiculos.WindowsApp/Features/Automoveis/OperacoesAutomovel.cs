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
            TelaAutomovelForm tela = new TelaAutomovelForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Automovel);

                List<Automovel> automoveis = controlador.SelecionarTodos();

                tabelaAutomovel.AtualizarRegistros(automoveis);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Automóvel: [{tela.Automovel.Modelo}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaAutomovel.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um automóvel para poder editar!", "Edição de Automóveis",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Automovel automovelSelecionado = controlador.SelecionarPorId(id);

            TelaAutomovelForm tela = new TelaAutomovelForm();

            tela.Automovel = automovelSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Automovel);

                List<Automovel> automoveis = controlador.SelecionarTodos();

                tabelaAutomovel.AtualizarRegistros(automoveis);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Automóvel: [{tela.Automovel.Modelo}] editado com sucesso");
            }
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
