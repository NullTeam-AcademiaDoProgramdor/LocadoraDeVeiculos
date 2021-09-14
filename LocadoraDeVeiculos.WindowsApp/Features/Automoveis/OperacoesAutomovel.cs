using LocadoraDeVeículos.Aplicacao.AutomovelModule;
using LocadoraDeVeículos.Aplicacao.GrupoAutomovelModule;
using LocadoraDeVeiculos.Controladores.AutomovelModule;
using LocadoraDeVeiculos.Controladores.GrupoAutomovelModule;
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
        private readonly AutomovelAppService controlador = null;
        private readonly GrupoAutomovelAppService controladorGrupo = null;
        private readonly TabelaAutomovelControl tabelaAutomovel = null;

        public OperacoesAutomovel(AutomovelAppService controlador, GrupoAutomovelAppService controladorGrupo)
        {
            this.controlador = controlador;
            this.controladorGrupo = controladorGrupo;
            tabelaAutomovel = new TabelaAutomovelControl();
        }

        public void InserirNovoRegistro()
        {
            if (!PodeCadastrar())
                return;

            TelaAutomovelForm tela = new TelaAutomovelForm(controladorGrupo.SelecionarTodos());

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Automovel);

                List<Automovel> automoveis = controlador.SelecionarTodos();

                tabelaAutomovel.DesagruparRegistros();
                tabelaAutomovel.AtualizarRegistros(automoveis);
                tabelaAutomovel.AgruparRegistros();

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

            TelaAutomovelForm tela = new TelaAutomovelForm(controladorGrupo.SelecionarTodos());

            tela.Automovel = automovelSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Automovel);

                List<Automovel> automoveis = controlador.SelecionarTodos();

                tabelaAutomovel.DesagruparRegistros();
                tabelaAutomovel.AtualizarRegistros(automoveis);
                tabelaAutomovel.AgruparRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Automóvel: [{tela.Automovel.Modelo}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaAutomovel.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um automével para poder excluir!", "Exclusão de Automóveis",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Automovel automovelSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o automóvel: [{automovelSelecionado.Modelo}] ?",
                "Exclusão de Automóveis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool conseguiuExcluir = controlador.Excluir(id);

                if (conseguiuExcluir == false)
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Não foi possível excluir o automóvel [{automovelSelecionado.Modelo}] " +
                        $"por estar vinculado à uma locação.");
                    return;
                }
                List<Automovel> automoveis = controlador.SelecionarTodos();

                tabelaAutomovel.DesagruparRegistros();
                tabelaAutomovel.AtualizarRegistros(automoveis);
                tabelaAutomovel.AgruparRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Automóvel: [{automovelSelecionado.Modelo}] removido com sucesso");
            }
        }

        private bool PodeCadastrar()
        {
            if (controladorGrupo.SelecionarTodos().Count > 0)
                return true;
            else
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre um Grupo de Automóvel para poder cadastrar um Automóvel!");

            return false;
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void AgruparRegistros()
        {
            AgrupamentoAutomovelForm telaOrdemAutomovel = new AgrupamentoAutomovelForm();

            if (telaOrdemAutomovel.ShowDialog() == DialogResult.OK)
            {
                tabelaAutomovel.AgruparRegistros(telaOrdemAutomovel.TipoOrdem);
            }
        }

        public void DesagruparRegistros()
        {
            tabelaAutomovel.DesagruparRegistros();
        }

        public UserControl ObterTabela()
        {
            List<Automovel> automovels = controlador.SelecionarTodos();

            tabelaAutomovel.AtualizarRegistros(automovels);

            return tabelaAutomovel;
        }

        public void ExibirInformacoesDetalhadas()
        {
            int id = tabelaAutomovel.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Automóvel para poder visualizar seus detalhes!", "visualização de Automóvel",
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Automovel automovelSelecionado = controlador.SelecionarPorId(id);

            TelaInformaçõesAutomovelForm tela = 
                new TelaInformaçõesAutomovelForm(automovelSelecionado);
            tela.ShowDialog();
        }
    }
}
