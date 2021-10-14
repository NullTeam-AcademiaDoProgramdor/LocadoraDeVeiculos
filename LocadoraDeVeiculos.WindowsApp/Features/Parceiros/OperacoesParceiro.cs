using LocadoraDeVeículos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Controladores.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.Parceiros
{
    public class OperacoesParceiro : ICadastravel
    {

        //private readonly ControladorParceiro controlador = null;
        private readonly TabelaParceiroControl tabelaParceiro = null;
        private readonly ParceiroAppService controlador = null;

        public OperacoesParceiro(ParceiroAppService controlador)
        {
            this.controlador = controlador;
            this.tabelaParceiro = new TabelaParceiroControl();
        }

        public void InserirNovoRegistro()
        {
            TelaParceiroForm tela = new TelaParceiroForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Parceiro);

                tabelaParceiro.AtualizarRegistros(controlador.SelecionarTodos());

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro.Nome}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaParceiro.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Parceiro para poder editar!", "Edição de Parceiros",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Parceiro parceiroEncontrado = controlador.SelecionarPorId(id);

            TelaParceiroForm tela = new TelaParceiroForm();

            tela.Parceiro = parceiroEncontrado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Parceiro);

                tabelaParceiro.AtualizarRegistros(controlador.SelecionarTodos());

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro.Nome}] editado com sucesso");
            }
        }


        public void ExcluirRegistro()
        {
            int id = tabelaParceiro.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Parceiro para poder excluir!", "Exclusão de Parceiros",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Parceiro parceiroEncontrado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o parceiro: [{parceiroEncontrado.Nome}] ?",
                "Exclusão de Parceiro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<Parceiro> parceiros = controlador.SelecionarTodos();

                tabelaParceiro.AtualizarRegistros(parceiros);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{parceiroEncontrado.Nome}] removido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Parceiro> parceiros = controlador.SelecionarTodos();

            tabelaParceiro.AtualizarRegistros(parceiros);

            return tabelaParceiro;
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            throw new NotImplementedException();
        }


        public void ExibirInformacoesDetalhadas()
        {
            throw new NotImplementedException();
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
