using LocadoraDeVeículos.Aplicacao.PessoaJuridicaModule;
using LocadoraDeVeiculos.Controladores.PessoaJuridicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasJuridicas
{
    public class OperacoesPessoaJuridica : ICadastravel
    {
        //private readonly ControladorPessoaJuridica controlador = null;
        private readonly PessoaJuridicaAppService controlador = null;
        private readonly TabelaPessoaJuridicaControl tabelaPessoasJuridicas = null;

        public OperacoesPessoaJuridica(PessoaJuridicaAppService controlador)
        {
            this.controlador = controlador;
            this.tabelaPessoasJuridicas = new TabelaPessoaJuridicaControl();
        }

        public void InserirNovoRegistro()
        {
            TelaPessoaJuridicaForm tela = new TelaPessoaJuridicaForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.PessoaJuridica);

                List<PessoaJuridica> pessoasJuridicas = controlador.SelecionarTodos();

                tabelaPessoasJuridicas.AtualizarRegistros(pessoasJuridicas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Pessoa jurídica: [{tela.PessoaJuridica.Nome}] inserida com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaPessoasJuridicas.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma pessoa jurídica para poder editar!", "Edição de Pessoas Jurídicas",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            PessoaJuridica pessoaJuridicaSelecionada = controlador.SelecionarPorId(id);

            TelaPessoaJuridicaForm tela = new TelaPessoaJuridicaForm();

            tela.PessoaJuridica = pessoaJuridicaSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.PessoaJuridica);

                List<PessoaJuridica> pessoasJuridicas = controlador.SelecionarTodos();

                tabelaPessoasJuridicas.AtualizarRegistros(pessoasJuridicas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Pessoa jurídica: [{tela.PessoaJuridica.Nome}] editada com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaPessoasJuridicas.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma pessoa jurídica para poder excluir!", "Exclusão de pessoa jurídica",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            PessoaJuridica pessoaJuridicaSelecionada = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a pessoa jurídica: [{pessoaJuridicaSelecionada.Nome}] ?",
                "Exclusão de Pessoas Jurídicas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<PessoaJuridica> pessoasJuridicas = controlador.SelecionarTodos();

                tabelaPessoasJuridicas.AtualizarRegistros(pessoasJuridicas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Pessoa jurídica: [{pessoaJuridicaSelecionada.Nome}] removida com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public UserControl ObterTabela()
        {
            List<PessoaJuridica> pessoasJuridicas = controlador.SelecionarTodos();

            tabelaPessoasJuridicas.AtualizarRegistros(pessoasJuridicas);

            return tabelaPessoasJuridicas;
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
    }
}
