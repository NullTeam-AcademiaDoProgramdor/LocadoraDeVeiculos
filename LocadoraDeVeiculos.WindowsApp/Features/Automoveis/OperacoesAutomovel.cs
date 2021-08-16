﻿using LocadoraDeVeiculos.Controladores.AutomovelModule;
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
                controlador.Excluir(id);

                List<Automovel> automoveis = controlador.SelecionarTodos();

                tabelaAutomovel.AtualizarRegistros(automoveis);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Automóvel: [{automovelSelecionado.Modelo}] removido com sucesso");
            }
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
                switch (telaOrdemAutomovel.TipoOrdem)
                {
                    case FiltroAutomovelEnum.AutomoveisPorGrupo:
                        tabelaAutomovel.AgruparAutomoveis("Grupo");
                        break;

                    case FiltroAutomovelEnum.AutomoveisSemOrdem:
                        DesagruparRegistros();
                        break;

                    default:
                        break;
                }
            }
        }

        public void DesagruparRegistros()
        {
            tabelaAutomovel.DesagruparCompromissos(controlador.SelecionarTodos());
        }

        public UserControl ObterTabela()
        {
            List<Automovel> automovels = controlador.SelecionarTodos();

            tabelaAutomovel.AtualizarRegistros(automovels);

            return tabelaAutomovel;
        }
    }
}
