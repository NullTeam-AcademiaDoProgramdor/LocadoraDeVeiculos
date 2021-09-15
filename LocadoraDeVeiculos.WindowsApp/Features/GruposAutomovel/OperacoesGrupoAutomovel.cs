using LocadoraDeVeículos.Aplicacao.GrupoAutomovelModule;
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

        private readonly GrupoAutomovelAppService controlador = null;
        private readonly TabelaGrupoAutomovelControl tabelaGrupoAutomovel = null;

        public OperacoesGrupoAutomovel(GrupoAutomovelAppService controlador)
        {
            this.controlador = controlador;
            tabelaGrupoAutomovel = new TabelaGrupoAutomovelControl();
        }
        public void InserirNovoRegistro()
        {
            TelaGrupoAutomovelForm tela = new TelaGrupoAutomovelForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.GrupoAutomovel);

                List<GrupoAutomovel> grupos = controlador.SelecionarTodos();

                tabelaGrupoAutomovel.AtualizarRegistros(grupos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo: [{tela.GrupoAutomovel.Nome}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaGrupoAutomovel.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Grupo para poder editar!", "Edição de Grupo de Automovel",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoAutomovel grupoSelecionado = controlador.SelecionarPorId(id);

            TelaGrupoAutomovelForm tela = new TelaGrupoAutomovelForm();

            tela.GrupoAutomovel = grupoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.GrupoAutomovel);

                List<GrupoAutomovel> grupos = controlador.SelecionarTodos();

                tabelaGrupoAutomovel.AtualizarRegistros(grupos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo: [{tela.GrupoAutomovel.Nome}] editado com sucesso");
            }
        }
        public void ExcluirRegistro()
        {
            int id = tabelaGrupoAutomovel.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Grupo para poder excluir!", "Exclusão de Grupo de Automovel",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoAutomovel grupoSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o grupo: [{grupoSelecionado.Nome}] ?",
                "Exclusão de Grupo de Automovel", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<GrupoAutomovel> grupos = controlador.SelecionarTodos();

                tabelaGrupoAutomovel.AtualizarRegistros(grupos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo: [{grupoSelecionado.Nome}] removido com sucesso");
            }
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
            List<GrupoAutomovel> grupos = controlador.SelecionarTodos();

            tabelaGrupoAutomovel.AtualizarRegistros(grupos);

            return tabelaGrupoAutomovel;
        }

        public void ExibirInformacoesDetalhadas()
        {
            int id = tabelaGrupoAutomovel.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Grupo para poder visualizar seus detalhes!", "visualização de Grupo de Automovel",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoAutomovel grupoSelecionado = controlador.SelecionarPorId(id);

            TelaInformacoesDetalhadasForm tela = new TelaInformacoesDetalhadasForm(grupoSelecionado);
            tela.ShowDialog();
        }
    }
}

